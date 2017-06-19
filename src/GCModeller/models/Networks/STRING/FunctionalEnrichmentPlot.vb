﻿Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel.DataStructures
Imports Microsoft.VisualBasic.Data.visualize.Network
Imports Microsoft.VisualBasic.Data.visualize.Network.FileStream
Imports Microsoft.VisualBasic.Data.visualize.Network.Graph
Imports Microsoft.VisualBasic.Data.visualize.Network.Layouts
Imports Microsoft.VisualBasic.Imaging
Imports Microsoft.VisualBasic.Imaging.Drawing2D.Math2D.ConvexHull
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports SMRUCC.genomics.Assembly.KEGG.WebServices
Imports SMRUCC.genomics.Assembly.Uniprot.XML
Imports SMRUCC.genomics.Data.STRING
Imports NetGraph = Microsoft.VisualBasic.Data.visualize.Network.FileStream.Network
Imports NetNode = Microsoft.VisualBasic.Data.visualize.Network.FileStream.Node
Imports GraphLayout = Microsoft.VisualBasic.Data.visualize.Network.Layouts

''' <summary>
''' 功能富集网络
''' </summary>
Public Module FunctionalEnrichmentPlot

    ''' <summary>
    ''' Using string-db ID as the uniprot data index key
    ''' </summary>
    ''' <param name="uniprot"></param>
    ''' <returns></returns>
    <Extension> Public Function StringUniprot(uniprot As UniprotXML) As Dictionary(Of String, entry)
        Return uniprot _
            .entries _
            .Where(Function(protein) protein.Xrefs.ContainsKey(InteractExports.STRING)) _
            .Select(Function(protein) protein.Xrefs(InteractExports.STRING) _
            .Select(Function(id) (id, protein))) _
            .IteratesALL _
            .GroupBy(Function(id) id.Item1.id) _
            .ToDictionary(Function(x) x.Key,
                          Function(proteins) proteins.First.Item2)
    End Function

    Const delimiter$ = " === "

    <Extension>
    Public Function BuildModel(interacts As IEnumerable(Of InteractExports), uniprot As Dictionary(Of String, entry)) As NetGraph
        Dim KOCatagory = PathwayMapping.DefaultKOTable
        Dim name2STRING = interacts _
            .Select(Function(x) {
                (x.node1, x.node1_external_id),
                (x.node2, x.node2_external_id)
            }) _
            .IteratesALL _
            .GroupBy(Function(x) x.Item1) _
            .ToDictionary(Function(x) x.Key,
                          Function(stringID) stringID.First.Item2)
        Dim nodes = interacts _
            .NodesID _
            .Select(Function(stringID$)
                        Dim pathways$()
                        Dim KO$()
                        Dim uniprotID$()
                        Dim name$ = stringID

                        stringID = name2STRING(name)

                        If uniprot.ContainsKey(stringID) Then
                            With uniprot(stringID)
                                KO = .Xrefs.TryGetValue("KO") _
                                     .SafeQuery _
                                     .Select(Function(x) x.id) _
                                     .ToArray
                                pathways = KO _
                                    .Where(Function(ID) KOCatagory.ContainsKey(ID)) _
                                    .Select(Function(ID) KOCatagory(ID).Parent.Description) _
                                    .Distinct _
                                    .ToArray
                                uniprotID = .accessions
                            End With
                        Else
                            KO = {}
                            pathways = {}
                            uniprotID = {}
                        End If

                        Dim data As New Dictionary(Of String, String)

                        data!KO = KO.JoinBy("|")
                        data!uniprotID = uniprotID.JoinBy("|")
                        data!STRING_ID = stringID

                        Return New NetNode(name) With {
                            .NodeType = pathways.JoinBy(FunctionalEnrichmentPlot.delimiter),
                            .Properties = data
                        }
                    End Function) _
            .ToDictionary
        Dim links = interacts _
            .Select(Function(l)
                        Dim a = nodes(l.node1)
                        Dim b = nodes(l.node2)
                        Dim pa = Strings.Split(a.NodeType, FunctionalEnrichmentPlot.delimiter)
                        Dim pb = Strings.Split(b.NodeType, FunctionalEnrichmentPlot.delimiter)
                        Dim type$

                        If pa.Where(Function(pathway) pb.IndexOf(pathway) > -1).Count > 0 Then
                            type = "pathway_internal"
                        ElseIf pa.IsNullOrEmpty AndAlso pb.IsNullOrEmpty Then
                            type = "Unknown"
                        Else
                            type = "pathway_outbounds"
                        End If

                        Return New NetworkEdge With {
                            .FromNode = l.node1,
                            .ToNode = l.node2,
                            .Interaction = type,
                            .value = l.combined_score
                        }
                    End Function).ToArray

        Return New NetGraph(links, nodes.Values)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="model">是以STRING的蛋白编号为标识符的，所以在这里还需要使用uniprot的数据进行转换</param>
    ''' <param name="DEGs">uniprot蛋白编号</param>
    ''' <param name="colors"></param>
    ''' <returns></returns>
    ''' 
    <Extension>
    Public Function RenderDEGsColor(ByRef model As NetGraph,
                                    DEGs As (up As String(), down As String()),
                                    colors As (up$, down$),
                                    Optional nonDEPcolor$ = "gray") As NetGraph

        Dim up = DEGs.up.Indexing
        Dim down = DEGs.down.Indexing

        For Each node As NetNode In model.Nodes
            Dim id$ = node!STRING_ID

            If up.IndexOf(id) > -1 Then
                node!color = colors.up
            ElseIf down.IndexOf(id) > -1 Then
                node!color = colors.down
            Else
                node!color = nonDEPcolor
            End If
        Next

        Return model
    End Function

    ''' <summary>
    ''' 这个函数需要编写一个网络布局生成函数的参数配置文件
    ''' </summary>
    ''' <param name="model"></param>
    ''' <returns></returns>
    <Extension>
    Public Function VisualizeKEGG(model As NetGraph, Optional layouts As Coordinates() = Nothing, Optional colorSchema$ = "Set1:c10") As Image
        Dim graph = model.CreateGraph(nodeColor:=Function(n) (n!color).GetBrush)

        If layouts.IsNullOrEmpty Then
            Dim parameters As ForceDirectedArgs = GraphLayout.Parameters.Load

            ' 生成layout信息               
            Call graph.doRandomLayout
            Call graph.doForceLayout(showProgress:=True, parameters:=parameters)
        Else
            ' 直接使用所提供的布局信息
            Dim layoutTable = layouts.ToDictionary(Function(x) x.node)

            For Each node In graph.nodes
                With layoutTable(node.ID)
                    Dim point As New FDGVector2(.x_position * 1000, .y_position * 1000)
                    node.Data.initialPostion = point
                End With
            Next
        End If

        Dim graphNodes = graph.nodes.ToDictionary
        Dim nodeGroups = model.Nodes _
            .Select(Function(n)
                        Return Strings _
                            .Split(n.NodeType, delimiter) _
                            .Select(Function(path) (path, n))
                    End Function) _
            .IteratesALL _
            .GroupBy(Function(x) x.Item1) _
            .Where(Function(g) (Not g.Key.StringEmpty) AndAlso g.Count > 3) _
            .ToDictionary(Function(g) g.Key,
                          Function(nodes)
                              Return nodes _
                                  .Select(Function(x)
                                              Return graphNodes(x.Item2.ID)
                                          End Function) _
                                  .ToArray
                          End Function)
        Dim nodePoints As Dictionary(Of Graph.Node, Point) = Nothing
        Dim colors As New LoopArray(Of Color)(GDIColors.ChartColors)

        Call $"{colors.Length} colors --> {nodeGroups.Count} KEGG pathways".__DEBUG_ECHO

        Using g As Graphics2D = graph _
            .DrawImage(canvasSize:="5000,4500", scale:=3, nodePoints:=nodePoints) _
            .AsGDIImage _
            .CreateCanvas2D(directAccess:=True)

            For Each pathway In nodeGroups.SeqIterator
                Dim nodes = (+pathway).Value
                Dim name$ = (+pathway).Key
                Dim polygon As Point() = nodePoints.Selects(nodes)

                polygon = ConvexHull.GrahamScan(polygon)

                With colors.Next
                    Dim pen As New Pen(.ref, 10)
                    Dim fill As New SolidBrush(Color.FromArgb(40, .ref))

                    Call g.DrawPolygon(pen, polygon)
                    Call g.FillPolygon(fill, polygon)
                End With
            Next

            Return g.ImageResource
        End Using
    End Function
End Module
