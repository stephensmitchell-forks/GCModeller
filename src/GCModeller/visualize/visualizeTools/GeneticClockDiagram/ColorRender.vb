﻿#Region "Microsoft.VisualBasic::1457178d8b23c6d78e756be274845b2c, ..\GCModeller\visualize\visualizeTools\GeneticClockDiagram\ColorRender.vb"

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

Imports SMRUCC.genomics.InteractionModel
Imports Microsoft.VisualBasic

Namespace GeneticClock

    ''' <summary>
    ''' 获取值大小梯度颜色
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ColorRender

        Public Structure ColorProfile
            Dim TagValue As String
            Dim Profiles As KeyValuePair(Of Double, System.Drawing.Color)()

            Public ReadOnly Property Average As Double
                Get
                    Return (From item In Profiles Select item.Key).ToArray.Average
                End Get
            End Property

            Public ReadOnly Property Max As Double
                Get
                    Return (From item In Profiles Select item.Key).ToArray.Max
                End Get
            End Property

            Public Function GetValue(d As Double) As System.Drawing.Color
                For i As Integer = 0 To Profiles.Count - 2
                    Dim x As Double = Profiles(i).Key
                    Dim y As Double = Profiles(i + 1).Key
                    If d <= y AndAlso d >= x Then
                        Return Profiles(i).Value
                    End If
                Next

                Return Profiles.Last.Value
            End Function

            Public Overrides Function ToString() As String
                Return TagValue
            End Function

            ''' <summary>
            ''' 
            ''' </summary>
            ''' <param name="Gr"></param>
            ''' <param name="ref">参考位置</param>
            ''' <remarks></remarks>
            Public Sub DrawingDensityRule(ByRef Gr As Graphics, ref As Point, DrawingFont As Font, ImageWidth As Integer)
                Dim DensityRule = Me
                Dim y = ref.Y
                Dim x = ref.X
                Dim ImageOffset As Integer = ref.X

                y += 20 + Gr.MeasureString("0", DrawingFont).Height

                Dim RuleHeight = 10
                Dim RuleWidth = ImageWidth / DensityRule.Profiles.Count

                For i As Integer = 0 To DensityRule.Profiles.Count - 1
                    Dim Model = New Rectangle(New Point(x, y), New Size(RuleWidth, RuleHeight))
                    Call Gr.FillRectangle(New SolidBrush(DensityRule.Profiles(i).Value), Model)
                    x += RuleWidth
                Next

                DrawingFont = New Font("Ubuntu", 5)

                y += RuleHeight + 5
                Call Gr.DrawLine(Pens.Black, New Point(ImageOffset, y), New Point(x, y))
                y += 2
                Call Gr.DrawString(CInt(DensityRule.Profiles.First.Key), DrawingFont, Brushes.Black, New Point(ImageOffset - Gr.MeasureString(CInt(DensityRule.Profiles.First.Key), DrawingFont).Width / 2, y))
                Call Gr.DrawString(CInt(DensityRule.Profiles.Last.Key), DrawingFont, Brushes.Black, New Point(x - Gr.MeasureString(CInt(DensityRule.Profiles.Last.Key), DrawingFont).Width / 2, y))
            End Sub
        End Structure

        Dim _MinValue As Double()
        Dim _MaxValue As Double()
        Dim _Delta As Double()
        Dim _DataSet As SerialsData()
        Dim _Avg As Double()

        Dim isGlobal As Boolean

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="DataSet"></param>
        ''' <param name="Global">颜色的梯度计算是否为全局性的，默认为全局性的</param>
        ''' <remarks></remarks>
        Sub New(DataSet As SerialsData(), Optional [Global] As Boolean = True)
            If [Global] Then
                Call InternalGlobalCalculation(DataSet)
            Else
                Call InternalLocalCalculation(DataSet)
            End If

            isGlobal = [Global]
        End Sub

        ''' <summary>
        ''' 单条的每一个样品数据都有自己的映射
        ''' </summary>
        ''' <param name="DataSet"></param>
        ''' <remarks></remarks>
        Private Sub InternalLocalCalculation(DataSet As SerialsData())
            _MinValue = (From item In DataSet Let MinValue As Double = item.ChunkBuffer.Min Select MinValue).ToArray
            _MaxValue = (From item In DataSet Let MaxValue As Double = item.ChunkBuffer.Max Select MaxValue).ToArray
            _Delta = (From i As Integer In _MinValue.Sequence Select (_MaxValue(i) - _MinValue(i)) / 255).ToArray
            _DataSet = DataSet
            _Avg = (From i As Integer In _MinValue.Sequence Select (_MaxValue(i) + _MinValue(i)) / 2).ToArray
        End Sub

        ''' <summary>
        ''' 全局的值就只有一个
        ''' </summary>
        ''' <param name="DataSet"></param>
        ''' <remarks></remarks>
        Private Sub InternalGlobalCalculation(DataSet As SerialsData())
            Dim Min As Double = (From item In DataSet Let MinValue As Double = item.ChunkBuffer.Min Select MinValue).ToArray.Min
            Dim Max As Double = (From item In DataSet Let MaxValue As Double = item.ChunkBuffer.Max Select MaxValue).ToArray.Max

            _MinValue = {Min}
            _MaxValue = {Max}
            _Delta = {(_MaxValue(0) - _MinValue(0)) / 255}
            _DataSet = DataSet
            _Avg = {(_MaxValue(0) + _MinValue(0)) / 2}
        End Sub

        ''' <summary>
        ''' 获取和数值大小相关的密度颜色
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetColorRenderingProfiles() As ColorProfile()
            Dim LQuery = (From idx As Integer In _DataSet.Sequence
                          Let Item As SerialsData = _DataSet(idx)
                          Let profiles = If(isGlobal, InternalRenderColor(Item, _MinValue(0), _Delta(0), _Avg(0)), InternalRenderColor(Item, _MinValue(idx), _Delta(idx), _Avg(idx)))
                          Select profiles).ToArray
            Return LQuery
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="counts"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDesityRule(counts As Integer) As ColorProfile
            Return GetDesityRule(_MinValue(0), _MaxValue(0), counts)
        End Function

        Public Shared Function GetDesityRule(MinValue As Double, MaxValue As Double, Counts As Integer) As ColorProfile
            Dim ChunkList As List(Of KeyValuePair(Of Double, System.Drawing.Color)) = New List(Of KeyValuePair(Of Double, System.Drawing.Color))
            Dim _Delta = (MaxValue - MinValue) / 255
            Dim _Avg = (MaxValue + MinValue) / 2

            For d As Double = MinValue To MaxValue Step (MaxValue - MinValue) / Counts
                Dim R = (d - MinValue) / _Delta
                Dim G = System.Math.Abs(d - _Avg) / _Delta
                Dim B = 255 - (d - MinValue) / _Delta
                Call ChunkList.Add(New KeyValuePair(Of Double, System.Drawing.Color)(d, System.Drawing.Color.FromArgb(R, G, B)))
            Next

            Return New ColorProfile With {.Profiles = ChunkList.ToArray, .TagValue = "Density"}
        End Function

        Public Shared Function GetDesityRule(data As Double(), Counts As Integer) As ColorProfile
            Return GetDesityRule(data.Min, data.Max, Counts)
        End Function

        Private Shared Function InternalRenderColor(DataChunk As SerialsData, _MinValue As Double, _Delta As Double, _Avg As Double) As ColorProfile
            If _Avg = 0.0R Then
                Return New ColorProfile With {.TagValue = DataChunk.Tag, .Profiles = (From item In DataChunk.ChunkBuffer Select New KeyValuePair(Of Double, System.Drawing.Color)(0.0R, Color.Black)).ToArray}
            End If

            Dim LQuery = (From d As Double In DataChunk.ChunkBuffer
                          Let R = (d - _MinValue) / _Delta
                          Let G = System.Math.Abs(d - _Avg) / _Delta
                          Let B = 255 - (d - _MinValue) / _Delta
                          Select New KeyValuePair(Of Double, System.Drawing.Color)(d, System.Drawing.Color.FromArgb(R, G, B))).ToArray
            Return New ColorProfile With {.TagValue = DataChunk.Tag, .Profiles = LQuery}
        End Function

        ''' <summary>
        ''' 对数据进行平均插值
        ''' </summary>
        ''' <param name="data"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function Interpolate(data As Double()) As Double()
            Dim ChunkBuffer As List(Of Double) = New List(Of Double)
            Dim PreValue As Double = data.First

            Call ChunkBuffer.Add(PreValue)

            For Each n In data.Skip(1)
                Dim value As Double = (n + PreValue) / 2
                Call ChunkBuffer.Add(value)
                Call ChunkBuffer.Add(n)
                PreValue = n
            Next

            Return ChunkBuffer.ToArray
        End Function

        Public Shared ReadOnly Property RandomColor(Optional alpha As Integer = 190) As Color
            Get
                Dim R = 255 * RandomDouble(), G = 255 * RandomDouble(), B = 255 * RandomDouble()
                Return Color.FromArgb(alpha, baseColor:=Color.FromArgb(R, G, B))
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return String.Format("{0}  -->  {1}", _MinValue, _MaxValue)
        End Function
    End Class
End Namespace
