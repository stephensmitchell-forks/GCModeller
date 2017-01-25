﻿#Region "Microsoft.VisualBasic::5feb6bc8c207550724ccce32610c8367, ..\GCModeller\core\Bio.Assembly\Assembly\NCBI\Database\GenBank\GBK\Keywords\Features\CDS.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
    '       xie (genetics@smrucc.org)
    ' 
    ' Copyright (c) 2016 GPL3 Licensed
    ' 
    ' 
    ' GNU GENERAL PUBLIC LICENSE (GPL3)
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

#End Region

Namespace Assembly.NCBI.GenBank.GBFF.Keywords.FEATURES

    ''' <summary>
    ''' 为CDS字段记录所特化的对象
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CDS : Inherits Feature

        Public Property db_xref_GI As String
        Public Property db_xref_GO As String
        Public Property db_xref_InterPro As String()
        Public Property db_xref_UniprotKBSwissProt As String
        Public Property db_xref_UniprotKBTrEMBL As String

        Public Property DBLinks As MetaCyc.Schema.DBLinkManager

        ''' <summary>
        ''' The cds feature
        ''' </summary>
        ''' <param name="cds"></param>
        Sub New(cds As Feature)

            Call cds.CopyTo(Me.__innerList)

            With Me
                .KeyName = cds.KeyName
                .gb = cds.gb
                .Location = cds.Location

                Dim groups = From str As String
                             In Me.QueryDuplicated("db_xref")
                             Let tokens As String() = str.Split(":"c)
                             Select Key = tokens.First, value = tokens.Last
                             Group By Key Into Group
                Dim tmp As String() = Nothing
                Dim db_xref = groups.ToDictionary(
                    Function(k) k.Key,
                    Function(a) (From o In a.Group Select o.value).ToArray)

                Call db_xref.TryGetValue("GI", tmp) : If Not tmp.IsNullOrEmpty Then db_xref_GI = tmp.First
                Call db_xref.TryGetValue("GOA", tmp) : If Not tmp.IsNullOrEmpty Then db_xref_GO = tmp.First
                Call db_xref.TryGetValue("UniProtKB/Swiss-Prot", tmp) : If Not tmp.IsNullOrEmpty Then db_xref_UniprotKBSwissProt = tmp.First
                Call db_xref.TryGetValue("UniProtKB/TrEMBL", tmp) : If Not tmp.IsNullOrEmpty Then db_xref_UniprotKBTrEMBL = tmp.First
                Call db_xref.TryGetValue("InterPro", db_xref_InterPro)
            End With
        End Sub
    End Class
End Namespace
