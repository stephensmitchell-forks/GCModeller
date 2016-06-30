﻿Imports LANS.SystemsBiology.Assembly.KEGG.DBGET
Imports LANS.SystemsBiology.AnalysisTools.DataVisualization.Interaction.Cytoscape.GCModeller.FileSystem
Imports LANS.SystemsBiology.AnalysisTools.DataVisualization.Interaction.Cytoscape.GCModeller.FileSystem.KEGG.Directories
Imports LANS.SystemsBiology.ComponentModel.EquaionModel.DefaultTypes
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.DataVisualization.Network
Imports LANS.SystemsBiology.Assembly.KEGG.Archives.Xml
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports LANS.SystemsBiology.Assembly.KEGG.Archives.Xml.Nodes

Namespace NetworkModel.KEGG

    ''' <summary>
    ''' 反应过程对象之间构成网络
    ''' </summary>
    <PackageNamespace("Cytoscape.Reaction.NET")>
    Public Module ReactionNET

        <ExportAPI("Reaction.Loads")>
        Public Function LoadObjects(Optional source As String = "") As bGetObject.Reaction()
            Dim files = FileIO.FileSystem.GetFiles(TryGetSource(source, AddressOf GetReactions),
                                                   FileIO.SearchOption.SearchAllSubDirectories,
                                                   "*.xml")
            Dim LQuery = (From xml As String
                          In files.AsParallel
                          Let model As bGetObject.Reaction = xml.LoadXml(Of bGetObject.Reaction)
                          Where Not model Is Nothing
                          Select model).ToArray
            Return LQuery
        End Function

        ''' <summary>
        ''' 转换为代谢物和反应的关系
        ''' </summary>
        ''' <param name="source"></param>
        ''' <returns></returns>
        ''' 
        <ExportAPI("Hash.Compounds")>
        Public Function BuildCompoundHash(source As IEnumerable(Of bGetObject.Reaction)) As Dictionary(Of String, bGetObject.Reaction())
            Dim preCache = (From x As bGetObject.Reaction
                            In source.AsParallel
                            Let LDM As Equation = x.ReactionModel
                            Select (From cp As CompoundSpecieReference
                                    In LDM.GetMetabolites
                                    Select cp.Identifier,
                                        rxn = x)).MatrixAsIterator
            Dim hash = (From x In preCache
                        Select x
                        Group x By x.Identifier Into Group) _
                             .ToDictionary(Function(x) x.Identifier,
                                           Function(x) x.Group.ToArray(Function(xx) xx.rxn))
            Return hash
        End Function

        ''' <summary>
        ''' 这个函数可能会加载数据库中的全部的资源数据
        ''' </summary>
        ''' <param name="source"></param>
        ''' <returns></returns>
        ''' 
        <ExportAPI("NET.Build")>
        Public Function BuildNET(source As String) As FileStream.Network
            Return BuildNET(LoadObjects(source))
        End Function

        ''' <summary>
        ''' 这个函数则可以从细菌模型之中选择性的构建网络
        ''' </summary>
        ''' <param name="source"></param>
        ''' <returns></returns>
        ''' 
        <ExportAPI("NET.Build")>
        Public Function BuildNET(source As IEnumerable(Of bGetObject.Reaction)) As FileStream.Network
            Dim cpHash = BuildCompoundHash(source)
            Dim nodes As New List(Of FileStream.Node)
            Dim nodeTmp As FileStream.Node() = source.ToArray(Function(x) New FileStream.Node With {.Identifier = x.Entry, .NodeType = "Flux"})
            Call nodes.AddRange(nodeTmp)
            nodeTmp = cpHash.ToArray(Function(x) New FileStream.Node With {
                                         .Identifier = x.Key,
                                         .NodeType = "Metabolite",
                                         .Properties = New Dictionary(Of String, String) From {{"associate", x.Value.Length}}})
            Call nodes.AddRange(nodeTmp)

            Dim edges As FileStream.NetworkEdge() = cpHash.ToArray(Function(x) __buildNET(x.Key, x.Value), Parallel:=True).MatrixToVector

            Return New FileStream.Network With {
                .Edges = edges.ToArray,
                .Nodes = nodes.ToArray
            }
        End Function

        <ExportAPI("NET.Build")>
        Public Function ModelNET(model As XmlModel, Optional sourceDIR As String = "") As FileStream.Network
            Dim maps As EC_Mapping() = model.EC_Mappings
            Dim source As Dictionary(Of String, bGetObject.Reaction()) = (From x As bGetObject.Reaction
                                                                          In LoadObjects(sourceDIR)
                                                                          Select x
                                                                          Group x By x.Entry Into Group) _
                                                                                .ToDictionary(Function(x) x.Entry,
                                                                                              Function(x) x.Group.ToArray)
            Dim mapsSource = (From x As String
                              In maps.ToArray(Function(xx) xx.ECMaps.ToArray(Function(xxx) xxx.Reactions)).MatrixAsIterator.MatrixAsIterator
                              Where source.ContainsKey(x)
                              Select source(x)).MatrixAsIterator
            Dim rxns = (From x In source.Values.MatrixAsIterator
                        Where StringHelpers.IsNullOrEmpty(x.ECNum)
                        Select x).Join(mapsSource).ToArray
            Dim net As FileStream.Network = BuildNET(rxns)
            Return net
        End Function

        Private Function __buildNET(met As String, rxn As bGetObject.Reaction()) As FileStream.NetworkEdge()
            Dim LQuery = (From x In rxn
                          Let ldm = x.ReactionModel
                          Let s As Double = ldm.GetCoEfficient(met)
                          Let from As String = If(s < 0, met, x.Entry)
                          Let toNode As String = If(s < 0, x.Entry, met)
                          Let itr As String = If(ldm.Reversible, "Reversible", "Directed")
                          Select New FileStream.NetworkEdge With {
                              .FromNode = from,
                              .ToNode = toNode,
                              .InteractionType = itr,
                              .Confidence = s,
                              .Properties = New Dictionary(Of String, String) From {{"def", x.Equation}}}).ToArray
            Return LQuery
        End Function
    End Module
End Namespace