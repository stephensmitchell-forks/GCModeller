﻿Imports System.Drawing
Imports Microsoft.VisualBasic.ComponentModel.Collection
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Data.visualize.Network.FileStream.Generic
Imports Microsoft.VisualBasic.Data.visualize.Network.Graph

Public Class CompoundNodeTable

    ReadOnly nodes As Dictionary(Of Node)

    Public ReadOnly Property values As IEnumerable(Of Node)
        Get
            Return nodes.Values
        End Get
    End Property

    Default Public ReadOnly Property getNode(id As String) As Node
        Get
            Return nodes(id)
        End Get
    End Property

    Sub New(compounds As IEnumerable(Of NamedValue(Of String)), cpdGroups As Dictionary(Of String, String()), color As Brush)
        nodes = compounds _
            .Where(Function(cpd) Not cpd.Name Like commonIgnores) _
            .Select(Function(cpd As NamedValue(Of String))
                        Return createCompoundNode(cpd, cpdGroups, color)
                    End Function) _
            .ToDictionary
    End Sub

    Public Function containsKey(nodeLabelId As String) As Boolean
        Return nodes.ContainsKey(nodeLabelId)
    End Function

    Private Shared Function createCompoundNode(cpd As NamedValue(Of String), cpdGroups As Dictionary(Of String, String()), color As Brush) As Node
        Dim type$

        If cpdGroups.ContainsKey(cpd.Name) Then
            type = cpdGroups(cpd.Name) _
                .JoinBy(Delimiter)
        Else
            type = "KEGG Compound"
        End If

        Return New Node With {
            .label = cpd.Name,
            .data = New NodeData With {
                .label = cpd.Name,
                .origID = cpd.Value,
                .color = color,
                .Properties = New Dictionary(Of String, String) From {
                    {"name", cpd.Value},
                    {NamesOf.REFLECTION_ID_MAPPING_NODETYPE, type}
                }
            }
        }
    End Function

    Public Shared Operator +(table As CompoundNodeTable, compoundNode As Node) As CompoundNodeTable
        Call table.nodes.Add(compoundNode)
        Return table
    End Operator
End Class
