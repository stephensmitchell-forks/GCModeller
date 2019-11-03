﻿Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel.Collection
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Data.visualize.Network.FileStream
Imports Microsoft.VisualBasic.Linq
Imports SMRUCC.genomics.Assembly.KEGG.WebServices

Namespace PathwayMaps

    Public Module ReferenceMap

        Private Function getCompoundsInMap(map As Map) As IEnumerable(Of NamedValue(Of String))
            Return map.shapes _
                .Select(Function(a) a.Names) _
                .IteratesALL _
                .Where(Function(term)
                           Return term.Name.IsPattern("C\d+")
                       End Function) _
                .Select(Function(c)
                            Return New NamedValue(Of String) With {
                                .Name = c.Name,
                                .Value = c.Value,
                                .Description = map.id
                            }
                        End Function)
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        <Extension>
        Private Function getCompoundIndex(reactionVector As ReactionTable(), getIds As Func(Of ReactionTable, String())) As Dictionary(Of String, ReactionTable())
            Return reactionVector _
                .Select(Function(r)
                            Return getIds(r).Select(Function(cid) (cid, r))
                        End Function) _
                .IteratesALL _
                .GroupBy(Function(t) t.cid) _
                .ToDictionary(Function(c) c.Key,
                              Function(g)
                                  Return g.Select(Function(r) r.r).ToArray
                              End Function)
        End Function

        <Extension>
        Private Function createNodeTable(compounds As IGrouping(Of String, NamedValue(Of String))()) As Dictionary(Of String, Node)
            Dim nodes As New Dictionary(Of String, Node)
            Dim node As Node
            Dim mapList$

            For Each compound In compounds
                mapList = compound.Select(Function(map) map.Description).JoinBy("|")
                node = New Node With {
                    .ID = compound.Key,
                    .NodeType = "compound",
                    .Properties = New Dictionary(Of String, String) From {
                        {"label", compound.First.Value},
                        {"maps", mapList}
                    }
                }

                Call nodes.Add(compound.Key, node)
            Next

            Return nodes
        End Function

        ReadOnly ignores As Index(Of String) = {
            "C00001", ' H2O
            "C00007", ' O2
            "C00011"  ' CO2
        }

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="maps">
        ''' <see cref="MapRepository.ScanMaps(String)"/>
        ''' </param>
        ''' <param name="reactions">
        ''' <see cref="ReactionTable.Load(String)"/>
        ''' </param>
        ''' <returns></returns>
        Public Function BuildNetworkModel(maps As IEnumerable(Of Map), reactions As IEnumerable(Of ReactionTable)) As NetworkTables
            Dim mapsVector = maps.ToArray
            Dim reactionVector As ReactionTable() = reactions.ToArray
            Dim compounds = mapsVector _
                .Select(AddressOf getCompoundsInMap) _
                .IteratesALL _
                .GroupBy(Function(c) c.Name) _
                .Where(Function(c) Not c.Key Like ignores) _
                .ToArray

            Dim reactantIndex = reactionVector.getCompoundIndex(Function(r) r.substrates)
            Dim productIndex = reactionVector.getCompoundIndex(Function(r) r.products)

            Dim nodes As Dictionary(Of String, Node) = compounds.createNodeTable
            Dim edges As New List(Of NetworkEdge)
            Dim edge As NetworkEdge

            ' 下面的两个for循环产生的是从reactant a到products b的反应过程边连接
            For Each a In compounds
                Dim forwards = reactantIndex.TryGetValue(a.Key)

                If forwards.IsNullOrEmpty Then
                    Continue For
                End If

                Dim producs As Dictionary(Of String, Integer) = forwards _
                    .Select(Function(r) r.products) _
                    .IteratesALL _
                    .GroupBy(Function(cid) cid) _
                    .ToDictionary(Function(c) c.Key,
                                  Function(g)
                                      Return g.Count
                                  End Function)

                For Each b In compounds.Where(Function(c) c.Key <> a.Key AndAlso producs.ContainsKey(c.Key))
                    edge = New NetworkEdge With {
                        .fromNode = a.Key,
                        .toNode = b.Key,
                        .interaction = "forward",
                        .value = producs(b.Key)
                    }

                    edges += edge
                Next
            Next

            Return New NetworkTables(nodes.Values, edges)
        End Function
    End Module
End Namespace