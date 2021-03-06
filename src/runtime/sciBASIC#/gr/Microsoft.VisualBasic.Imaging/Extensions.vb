﻿#Region "Microsoft.VisualBasic::3ff3a6ba29d153d2d58e058f80a0eef4, gr\Microsoft.VisualBasic.Imaging\Extensions.vb"

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

    ' Module Extensions
    ' 
    '     Function: AsGDIImage, AsSVG
    ' 
    '     Sub: (+4 Overloads) FillCircles
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Imaging.Driver
Imports Microsoft.VisualBasic.Imaging.Math2D
Imports Microsoft.VisualBasic.Linq

<HideModuleName> Public Module Extensions

    <Extension>
    Public Function AsSVG(img As GraphicsData, Optional comment$ = Nothing) As SVGData
        Dim svg As SVGData = DirectCast(img, SVGData)
        svg.XmlComment = comment
        Return svg
    End Function

    ''' <summary>
    ''' 假若目标图像是svg类型，则会被合成为gdi图像，如果是gdi图像，则会被直接转换
    ''' </summary>
    ''' <param name="img"></param>
    ''' <returns></returns>
    <Extension> Public Function AsGDIImage(img As GraphicsData) As Image
        If img.Driver = Drivers.GDI Then
            Return DirectCast(img, ImageData).Image
        Else
            ' 将svg矢量图合成为gdi图像
            Return DirectCast(img, SVGData).Render
        End If
    End Function

    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    <Extension>
    Public Sub FillCircles(ByRef g As IGraphics, brush As Brush, points As Point(), radius#)
        Call g.FillCircles(brush, points.Select(Function(p) p.PointF).ToArray, radius)
    End Sub

    <Extension>
    Public Sub FillCircles(ByRef g As IGraphics, brush As Brush, points As PointF(), radius#)
        Dim size As New Size(radius * 2, radius * 2)
        Dim offset = -radius

        For Each point As PointF In points
            Dim rect As New RectangleF(point.OffSet2D(offset, offset), size)
            Call g.FillEllipse(brush, rect)
        Next
    End Sub

    <Extension>
    Public Sub FillCircles(ByRef g As IGraphics, points As Point(), fill As Func(Of Integer, Point, Brush), radius#)
        Dim fillHandler As Func(Of Integer, PointF, Brush) = Function(i%, p As PointF) fill(i, p.ToPoint)
        Call g.FillCircles(points.PointF, fillHandler, radius)
    End Sub

    <Extension>
    Public Sub FillCircles(ByRef g As IGraphics, points As PointF(), fill As Func(Of Integer, PointF, Brush), radius#)
        Dim size As New Size(radius * 2, radius * 2)
        Dim offset = -radius

        For Each point As SeqValue(Of PointF) In points.SeqIterator
            Dim rect As New RectangleF((+point).OffSet2D(offset, offset), size)
            Call g.FillEllipse(fill(point, point), rect)
        Next
    End Sub
End Module
