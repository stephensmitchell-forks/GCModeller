﻿#Region "Microsoft.VisualBasic::76b5dfedc68cffd68d20152167f0f57f, GSEA\GSEA\KnowledgeBase\Imports.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xie (genetics@smrucc.org)
    '       xieguigang (xie.guigang@live.com)
    ' 
    ' Copyright (c) 2018 GPL3 Licensed
    ' 
    ' 
    ' GNU GENERAL PUBLIC LICENSE (GPL3)
    ' 
    ' 
    ' This program is free software: you can redistribute it and/or modify
    ' it under the terms of the GNU General Public License as published by
    ' the Free Software Foundation, either version 3 of the License, or
    ' (at your option) any later version.
    ' 
    ' This program is distributed in the hope that it will be useful,
    ' but WITHOUT ANY WARRANTY; without even the implied warranty of
    ' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    ' GNU General Public License for more details.
    ' 
    ' You should have received a copy of the GNU General Public License
    ' along with this program. If not, see <http://www.gnu.org/licenses/>.



    ' /********************************************************************************/

    ' Summaries:

    ' Module [Imports]
    ' 
    ' 
    '     Delegate Function
    ' 
    '         Function: CreateCluster, getTermInternal, GOClusters, ImportsUniProt, KEGGClusters
    '                   KEGGMapRelation, UniProtGetGOTerms, UniProtGetKOTerms
    ' 
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Text.Xml.Models
Imports SMRUCC.genomics.Assembly.KEGG.WebServices
Imports SMRUCC.genomics.Assembly.Uniprot.XML
Imports SMRUCC.genomics.Data.GeneOntology.DAG
Imports SMRUCC.genomics.Data.GeneOntology.OBO

''' <summary>
''' 进行富集计算分析所需要的基因组背景模型的导入模块
''' </summary>
Public Module [Imports]

    ''' <summary>
    ''' [geneID => [clusterID, name, description]]
    ''' </summary>
    ''' <param name="geneID"></param>
    ''' <returns></returns>
    Public Delegate Function GetClusterTerms(geneID As String) As NamedValue(Of String)()

    <Extension>
    Public Function KEGGMapRelation(maps As IEnumerable(Of Map)) As Dictionary(Of String, String())
        Return maps.Select(Function(m)
                               Return m.shapes.Select(Function(a) a.IDVector) _
                                   .IteratesALL _
                                   .Where(Function(id) id.IsPattern("K\d+")) _
                                   .Distinct _
                                   .Select(Function(id)
                                               Return (mapID:=m.ID, KO:=id)
                                           End Function)
                           End Function) _
                   .IteratesALL _
                   .GroupBy(Function(ko) ko.KO) _
                   .ToDictionary(Function(g) g.Key,
                                   Function(g)
                                       Return g.Select(Function(t) t.mapID) _
                                               .Distinct _
                                               .ToArray
                                   End Function)
    End Function

    <Extension>
    Public Function KEGGClusters(maps As IEnumerable(Of Map)) As GetClusterTerms
        Dim mapsList = maps.ToDictionary(Function(m) m.ID)
        Dim clusters = mapsList.Values.KEGGMapRelation

        Return Function(id)
                   If clusters.ContainsKey(id) Then
                       Return Iterator Function() As IEnumerable(Of NamedValue(Of String))
                                  For Each mapID As String In clusters(id)
                                      Yield New NamedValue(Of String) With {
                                          .Name = mapID,
                                          .Value = mapsList(mapID).Name,
                                          .Description = mapsList(mapID).URL
                                      }
                                  Next
                              End Function().ToArray
                   Else
                       Return {}
                   End If
               End Function
    End Function

    <Extension>
    Public Function GOClusters(GO_terms As IEnumerable(Of Term)) As GetClusterTerms
        Dim table As Dictionary(Of String, Term) = GO_terms.ToDictionary(Function(t) t.id)
        Dim parentPopulator = Iterator Function(termID As String) As IEnumerable(Of NamedValue(Of String))
                                  Dim GO_term = table.TryGetValue(termID)

                                  If GO_term Is Nothing Then
                                      Call $"Missing GO term: {termID}, this go term may be obsolete or you needs update the GO obo database to the latest version.".Warning
                                  Else
                                      Dim info As Definition = Definition.Parse(GO_term)

                                      ' 一个GO term类似于一个cluster
                                      ' 其所有基于is_a关系派生出来的子类型都是当前的这个term的cluster成员
                                      ' 在计算的时候会需要根据这个关系来展开计算
                                      Yield New NamedValue(Of String) With {
                                          .Name = GO_term.id,
                                          .Value = GO_term.name,
                                          .Description = info.definition
                                      }
                                  End If
                              End Function

        Return Function(termID)
                   Return parentPopulator(termID).ToArray
               End Function
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="db">从UniProt数据库之中下载的基因组Xml文件的迭代器</param>
    ''' <param name="genomeName$"></param>
    ''' <param name="define">Functional cluster define function</param>
    ''' <returns></returns>
    <Extension>
    Public Function ImportsUniProt(db As IEnumerable(Of entry),
                                   getTerm As Func(Of entry, String()),
                                   define As GetClusterTerms,
                                   Optional genomeName$ = Nothing,
                                   Optional outputAll As Boolean = False) As Background

        Dim clusters As New Dictionary(Of String, List(Of BackgroundGene))
        Dim clusterNotes As New Dictionary(Of String, NamedValue(Of String))
        Dim genomeSize%
        Dim taxonomy As String = Nothing

        For Each protein As entry In db
            Dim terms = getTerm(protein)
            Dim clusterNames As NamedValue(Of String)()

            genomeSize += 1

            If terms.IsNullOrEmpty Then
                clusterNames = {}
            Else
                clusterNames = terms.Select(Function(geneID) define(geneID)) _
                                    .IteratesALL _
                                    .ToArray
            End If

            If taxonomy.StringEmpty Then
                taxonomy = protein.organism.lineage.taxonlist.JoinBy("; ")
            End If

            For Each clusterID As NamedValue(Of String) In clusterNames
                If Not clusters.ContainsKey(clusterID.Name) Then
                    Call clusters.Add(clusterID.Name, New List(Of BackgroundGene))
                    Call clusterNotes.Add(clusterID.Name, clusterID)
                End If

                clusters(clusterID.Name) += New BackgroundGene With {
                    .accessionID = protein.accessions(Scan0),
                    .[alias] = protein.accessions,
                    .name = protein.name,
                    .locus_tag = Function() As NamedValue
                                     Dim tag$ = .accessionID

                                     If protein.xrefs.ContainsKey("KEGG") Then
                                         tag = protein.xrefs("KEGG").First.id
                                     End If

                                     Return New NamedValue With {
                                         .name = tag,
                                         .text = protein.protein.fullName
                                     }
                                 End Function(),
                    .term_id = terms
                }
            Next
        Next

        Return New Background With {
            .name = genomeName,
            .build = Now,
            .clusters = clusters _
                .Where(Function(c)
                           If outputAll Then
                               Return True
                           Else
                               Return c.Value.Count > 0
                           End If
                       End Function) _
                .Select(Function(c)
                            Dim geneIDs As IEnumerable(Of BackgroundGene) = c.Value
                            Dim note = clusterNotes(c.Key)

                            Return geneIDs.CreateCluster(c.Key, note)
                        End Function) _
                .ToArray,
            .size = genomeSize,
            .comments = taxonomy
        }
    End Function

    <Extension>
    Public Function CreateCluster(members As IEnumerable(Of BackgroundGene), clusterID$, note As NamedValue(Of String)) As Cluster
        Return New Cluster With {
            .ID = clusterID,
            .members = members.ToArray,
            .description = note.Description,
            .names = note.Value
        }
    End Function

    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Public Function UniProtGetKOTerms() As Func(Of entry, String())
        Return getTermInternal("KO")
    End Function

    Private Function getTermInternal(type As String) As Func(Of entry, String())
        Return Function(protein)
                   If protein.xrefs.ContainsKey(type) Then
                       Return protein.xrefs(type) _
                           .Select(Function(ref) ref.id) _
                           .ToArray
                   Else
                       Return {}
                   End If
               End Function
    End Function

    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Public Function UniProtGetGOTerms() As Func(Of entry, String())
        Return getTermInternal("GO")
    End Function
End Module
