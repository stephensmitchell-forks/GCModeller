﻿#Region "Microsoft.VisualBasic::15063cd70ae87a46e12958a0e1910c8c, ..\GCModeller\core\Bio.Assembly\Assembly\DOOR\Operon.vb"

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

Imports SMRUCC.genomics.ComponentModel.Loci
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic

Namespace Assembly.DOOR

    ''' <summary>
    ''' <see cref="Operon.Genes">操纵子中的基因</see>在构造函数之中已经进行过按照转录方向排序操作了的
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Operon : Inherits KeyValuePairObject(Of String, GeneBrief())
        Implements sIdEnumerable
        Implements IReadOnlyDictionary(Of String, GeneBrief)

        ''' <summary>
        ''' OperonId value.(操纵子的Door编号)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Property Key As String Implements sIdEnumerable.Identifier
            Get
                Return MyBase.Key
            End Get
            Set(value As String)
                MyBase.Key = value
            End Set
        End Property

        ''' <summary>
        ''' Door数据库之中的操纵子编号
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property OperonID As String
            Get
                Return MyBase.Key
            End Get
        End Property

        ''' <summary>
        ''' Structure genes.
        ''' (这个操纵子对象之中的结构基因，请注意<see cref="Genes"/>属性和这个属性一样，都是可以返回当前的这个Operon里面的所有的结构基因，
        ''' 只不过本属性是没有经过排序的，而<see cref="Genes"/>属性里面的对象都是按照基因组上下文的顺序进行排序操作了的)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Property Value As GeneBrief()
            Get
                Return MyBase.Value
            End Get
            Set(value As GeneBrief())
                MyBase.Value = value
                SortedIdList = (From Gene In value Select Gene.Synonym).ToArray
            End Set
        End Property

        ''' <summary>
        ''' 这个列表的<see cref="GeneBrief.Synonym">对象</see>顺序与<see cref="Operon.Value"></see>之中的列表对象的顺序一致
        ''' </summary>
        ''' <remarks></remarks>
        Dim SortedIdList As String()

        ''' <summary>
        ''' 在比较差异的时候，Operon编号没有意义，再这里使用操纵子内部的基因的编号的字符串来进行相互比较，基因号进行升序排序
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property TestGuid As String
            Get
                Dim ID = (From s_ID As String In SortedIdList Select s_ID Order By s_ID Ascending).ToArray
                Return String.Join(", ", ID)
            End Get
        End Property

        Public ReadOnly Property Strand As Strands
            Get
                Return Value.First.Location.Strand
            End Get
        End Property

        Sub New(OperonId As String, Genes As GeneBrief())
            Me.Key = OperonId
            Me.Value = Genes

            If Me.InitialX.Location.Strand = Strands.Forward Then  '按照转录的方向进行排序
                Me.Value = (From g As GeneBrief
                            In Me.Value
                            Select g
                            Order By g.Location.Left Ascending).ToArray
            Else
                Value = (From GeneObject In Value Select GeneObject Order By GeneObject.Location.Right Descending).ToArray
            End If
        End Sub

        ''' <summary>
        ''' 这个Operon里面的所有的结构基因的基因号的集合
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property lstLocus As IEnumerable(Of String) Implements IReadOnlyDictionary(Of String, GeneBrief).Keys
            Get
                Return SortedIdList.ToArray
            End Get
        End Property

        ''' <summary>
        ''' 依照Operon的方向，获取<paramref name="GeneId">目标基因对象</paramref>之后的所有基因
        ''' </summary>
        ''' <param name="GeneId">假若本参数值为操纵子的<see cref="InitialX">启动子基因</see>的话，则会返回整个操纵子，
        ''' 反之为操纵子之中的最后一个基因的话，则返回最后一个基因，
        ''' 若为中间的一个基因的话，则返回该基因以及其后面的所有基因，“后面”是依照<see cref="ComponentModel.Loci.NucleotideLocation.Strand">转录方向</see>来判定的</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetLast(GeneId As String) As GeneBrief()
            Dim p As Integer = Array.IndexOf(SortedIdList, GeneId)

            If p = SortedIdList.Length - 1 Then
                Return New GeneBrief() {Value.Last}
            End If

            If p > -1 Then
                Return Value.Skip(p).ToArray
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Get the operon initial structure (promoter) gene base on its transcript direction.
        ''' (根据转录方向来选取目标操纵子的启动子基因，如果转录方向为正向，则取最前面的基因，反之取最后面的基因)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property InitialX As GeneBrief
            Get
                If Value.First.Location.Strand = Strands.Forward Then
                    Return (From g As GeneBrief In MyBase.Value
                            Select g
                            Order By g.Location.Left Ascending).First
                Else
                    Return (From g As GeneBrief In MyBase.Value
                            Select g
                            Order By g.Location.Right Descending).First
                End If
            End Get
        End Property

        ''' <summary>
        ''' 获取本操纵子对象之中的最后一个基因
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property LastGene As GeneBrief
            Get
                If Value.First.Location.Strand = Strands.Forward Then
                    Return (From Gene In MyBase.Value Select Gene Order By Gene.Location.Left Ascending).Last
                Else
                    Return (From Gene In MyBase.Value Select Gene Order By Gene.Location.Left Descending).Last
                End If
            End Get
        End Property

        ''' <summary>
        ''' 查看目标基因是否是本操纵子之中的结构基因
        ''' </summary>
        ''' <param name="GeneId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IndexOf(GeneId As String) As Integer
            Return Array.IndexOf(SortedIdList, GeneId)
        End Function

        Public Overrides Function ToString() As String
            Return String.Format("[OperonId:={0}]  {1}", MyBase.Key, InitialX.ToString)
        End Function

        ''' <summary>
        ''' 将目标Door操纵子对象转换为Csv格式的数据
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ConvertToCsvData() As Assembly.DOOR.CsvModel.Operon
            Dim Direction As String = Value.First.Location.Strand.GetBriefCode
            Dim structs As String() = (From GeneObject As GeneBrief
                                       In Me.Value
                                       Select GeneObject.Synonym).ToArray
            Return New Assembly.DOOR.CsvModel.Operon With {
                .DoorId = Me.Key,
                .NumOfGenes = Me.Value.Length,
                .Genes = structs,
                .Direction = Direction
            }
        End Function

        Public Iterator Function GetEnumerator() As IEnumerator(Of KeyValuePair(Of String, GeneBrief)) _
                    Implements IEnumerable(Of KeyValuePair(Of String, GeneBrief)).GetEnumerator

            For Each Item As GeneBrief In Genes
                Yield New KeyValuePair(Of String, GeneBrief)(Item.Synonym, Item)
            Next
        End Function

        ''' <summary>
        ''' 这个操纵子里面的结构基因的数目
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property NumOfGenes As Integer Implements IReadOnlyCollection(Of KeyValuePair(Of String, GeneBrief)).Count
            Get
                Return Value.Length
            End Get
        End Property

        ''' <summary>
        ''' Has the gene with specific locusId in this operon?
        ''' </summary>
        ''' <param name="locusId"></param>
        ''' <returns></returns>
        Public Function HaveGene(locusId As String) As Boolean Implements IReadOnlyDictionary(Of String, GeneBrief).ContainsKey
            Dim LQuery = (From g As GeneBrief In Value Where String.Equals(g.Synonym, locusId) Select g).FirstOrDefault
            Return Not LQuery Is Nothing
        End Function

        Default Public ReadOnly Property Item(key As String) As GeneBrief Implements IReadOnlyDictionary(Of String, GeneBrief).Item
            Get
                Dim LQuery = (From Gene In Value Where String.Equals(Gene.Synonym, key) Select Gene).ToArray
                If LQuery.IsNullOrEmpty Then
                    Return Nothing
                Else
                    Return LQuery.First
                End If
            End Get
        End Property

        Public Function TryGetValue(key As String, ByRef value As GeneBrief) As Boolean _
                    Implements IReadOnlyDictionary(Of String, GeneBrief).TryGetValue

            Dim Gene = Item(key)
            value = Gene
            Return Not Gene Is Nothing
        End Function

        ''' <summary>
        ''' 这个属性会返回本Operon里面的一组基因，基因的位置和其在基因组上面的位置相关，并且与链的方向相关
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Genes As IEnumerable(Of GeneBrief) Implements IReadOnlyDictionary(Of String, GeneBrief).Values
            Get
                Return Value
            End Get
        End Property

        Public Iterator Function GetEnumerator1() As IEnumerator Implements IEnumerable.GetEnumerator
            Yield GetEnumerator()
        End Function
    End Class
End Namespace
