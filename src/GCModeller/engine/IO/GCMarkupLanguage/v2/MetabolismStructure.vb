﻿#Region "Microsoft.VisualBasic::8719379f6d1332b64fa428c4e9422b95, IO\GCMarkupLanguage\v2\MetabolismStructure.vb"

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

    '     Class MetabolismStructure
    ' 
    '         Properties: compounds, enzymes, maps, reactions
    ' 
    '         Function: GetAllFluxID
    ' 
    '     Class Compound
    ' 
    '         Properties: ID, name, otherNames
    ' 
    '     Class Reaction
    ' 
    '         Properties: Equation, ID, is_enzymatic, name
    ' 
    '         Function: ToString
    ' 
    '     Class FunctionalCategory
    ' 
    '         Properties: category, pathways
    ' 
    '         Function: ToString
    ' 
    '     Class Pathway
    ' 
    '         Properties: enzymes, ID, name
    ' 
    '         Function: ToString
    ' 
    '     Class Enzyme
    ' 
    '         Properties: catalysis, geneID, KO
    ' 
    '         Function: ToString
    ' 
    '     Class Catalysis
    ' 
    '         Properties: coefficient, comment, reaction
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel.Repository
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Text.Xml.Models

Namespace v2

    <XmlType("metabolome", [Namespace]:=VirtualCell.GCMarkupLanguage)>
    Public Class MetabolismStructure

        <XmlArray("compounds")> Public Property compounds As Compound()
        ''' <summary>
        ''' 在这个属性之中包含有所有的代谢反应过程的定义
        ''' </summary>
        ''' <returns></returns>
        <XmlElement("reactions")> Public Property reactions As ReactionGroup

        ''' <summary>
        ''' 在这个属性里面只会出现具有KO分类编号的蛋白序列，如果需要找所有基因的数据，可以
        ''' 读取<see cref="Genome.replicons"/>里面的基因的数据
        ''' </summary>
        ''' <returns></returns>
        <XmlArray("enzymes")> Public Property enzymes As Enzyme()

        <XmlArray("pathwayMaps")>
        Public Property maps As FunctionalCategory()

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Function GetAllFluxID() As String()
            Return reactions _
                .SafeQuery _
                .Select(Function(r) r.ID) _
                .ToArray
        End Function
    End Class

    Public Class ReactionGroup : Implements IList(Of Reaction)

        <XmlAttribute>
        Public Property size As Integer Implements IList(Of Reaction).size
            Get
                Return enzymatic.Length + etc.Length
            End Get
            Set(value As Integer)
                ' do nothing
            End Set
        End Property

        Public Property enzymatic As Reaction()
        Public Property etc As Reaction()

        Public Iterator Function GenericEnumerator() As IEnumerator(Of Reaction) Implements Enumeration(Of Reaction).GenericEnumerator
            For Each reaction In enzymatic
                Yield reaction
            Next
            For Each reaction In etc
                Yield reaction
            Next
        End Function

        Public Iterator Function GetEnumerator() As IEnumerator Implements Enumeration(Of Reaction).GetEnumerator
            Yield GenericEnumerator()
        End Function

        Public Shared Widening Operator CType(reactions As Reaction()) As ReactionGroup
            Dim twoGroup = reactions _
                .GroupBy(Function(r) r.is_enzymatic) _
                .ToDictionary(Function(g) g.Key.ToString,
                              Function(g)
                                  Return g.ToArray
                              End Function)

            Return New ReactionGroup With {
                .enzymatic = twoGroup.TryGetValue(True.ToString, [default]:={}),
                .etc = twoGroup.TryGetValue(False.ToString, [default]:={})
            }
        End Operator
    End Class

    <XmlType("compound", [Namespace]:=VirtualCell.GCMarkupLanguage)>
    Public Class Compound : Implements INamedValue

        <XmlAttribute> Public Property ID As String Implements IKeyedEntity(Of String).Key
        <XmlAttribute> Public Property name As String

        <XmlArray>
        Public Property otherNames As String()

    End Class

    <XmlType("reaction", [Namespace]:=VirtualCell.GCMarkupLanguage)>
    Public Class Reaction : Implements INamedValue

        <XmlAttribute> Public Property ID As String Implements IKeyedEntity(Of String).Key
        <XmlAttribute> Public Property name As String
        ''' <summary>
        ''' 这个反应模型是否是需要酶促才会发生了生化反应过程？
        ''' </summary>
        ''' <returns></returns>
        <XmlAttribute> Public Property is_enzymatic As Boolean
        ''' <summary>
        ''' [forward, reverse]
        ''' </summary>
        ''' <returns></returns>
        <XmlAttribute> Public Property bounds As Double()

        <XmlText>
        Public Property Equation As String

        Public Overrides Function ToString() As String
            Return name
        End Function

    End Class

    Public Class FunctionalCategory

        <XmlAttribute>
        Public Property category As String
        <XmlElement("pathway")>
        Public Property pathways As Pathway()

        Public Overrides Function ToString() As String
            Return category
        End Function

    End Class

    <XmlType("pathway", [Namespace]:=VirtualCell.GCMarkupLanguage)>
    Public Class Pathway : Implements INamedValue

        <XmlAttribute> Public Property ID As String Implements IKeyedEntity(Of String).Key
        <XmlAttribute> Public Property name As String

        ''' <summary>
        ''' 属性的值含义如下：
        ''' 
        ''' + <see cref="[Property].name"/>: protein_id
        ''' + <see cref="[Property].value"/>: KO number
        ''' + <see cref="[Property].Comment"/>: gene locus_tag
        ''' </summary>
        ''' <returns></returns>
        <XmlElement("enzyme")>
        Public Property enzymes As [Property]()

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Overrides Function ToString() As String
            Return $"[{ID}] {name} with {enzymes.Length} enzymes"
        End Function

    End Class

    <XmlType("enzyme", [Namespace]:=VirtualCell.GCMarkupLanguage)>
    Public Class Enzyme : Implements INamedValue

        <XmlAttribute> Public Property geneID As String Implements IKeyedEntity(Of String).Key
        <XmlAttribute> Public Property KO As String

        <XmlElement>
        Public Property catalysis As Catalysis()

        Public Overrides Function ToString() As String
            Return geneID
        End Function

    End Class

    <XmlType("catalysis", [Namespace]:=VirtualCell.GCMarkupLanguage)>
    Public Class Catalysis

        ''' <summary>
        ''' The reaction id
        ''' </summary>
        ''' <returns></returns>
        <XmlAttribute> Public Property reaction As String
        <XmlAttribute> Public Property coefficient As Double

        <XmlText>
        Public Property comment As String

    End Class
End Namespace
