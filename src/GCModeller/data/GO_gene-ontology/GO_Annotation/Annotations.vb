﻿#Region "Microsoft.VisualBasic::ef36f2141674ae9feb5fc7fee35f8b2d, GO_gene-ontology\GO_Annotation\Annotations.vb"

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

' Module Annotations
' 
'     Function: LoadSBHMaps, PfamAssign
' 
' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Language
Imports SMRUCC.genomics.Data.Xfam.Pfam.PfamString
Imports SMRUCC.genomics.Data.Xfam.Pfam.Pipeline.LocalBlast

Public Module Annotations

    <Extension>
    Public Function PfamAssign(pfamhits As IEnumerable(Of PfamHit), pfam2GO As Dictionary(Of String, toGO())) As AnnotationClusters
        Dim mapstoGO As New Dictionary(Of String, (desc$, go As List(Of String)))
        Dim go As toGO()

        For Each hit As PfamHit In pfamhits
            If Not mapstoGO.ContainsKey(hit.QueryName) Then
                mapstoGO(hit.QueryName) = (hit.description, New List(Of String))

                Call $"{hit.QueryName}: {hit.description}".__DEBUG_ECHO
            End If

            go = pfam2GO.TryGetValue(hit.pfamID)

            If Not go Is Nothing Then
                Call mapstoGO(hit.QueryName).go.AddRange(go.Select(Function(g) g.map2GO_id))
            End If
        Next

        Dim annotations As ProteinAnnotation() = mapstoGO _
            .Select(Function(prot)
                        Return New ProteinAnnotation With {
                            .proteinID = prot.Key,
                            .description = prot.Value.desc,
                            .GO = prot.Value _
                                .go _
                                .Distinct _
                                .ToArray
                        }
                    End Function) _
            .ToArray

        Return New AnnotationClusters With {
            .proteins = annotations
        }
    End Function

    <Extension>
    Public Function PfamAssign(annotations As IEnumerable(Of PfamString), pfam2GO As Dictionary(Of String, toGO())) As AnnotationClusters
        Throw New NotImplementedException
    End Function
End Module
