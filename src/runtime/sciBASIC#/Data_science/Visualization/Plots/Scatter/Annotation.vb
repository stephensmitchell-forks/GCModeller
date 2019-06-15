﻿#Region "Microsoft.VisualBasic::7de94b10646552feceba79ca090b50d5, Data_science\Visualization\Plots\Scatter\Annotation.vb"

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

    ' Structure Annotation
    ' 
    '     Function: ToString
    ' 
    '     Sub: Draw
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic.Data.ChartPlots.Graphic
Imports Microsoft.VisualBasic.Data.ChartPlots.Graphic.Legend
Imports Microsoft.VisualBasic.Imaging
Imports Microsoft.VisualBasic.Imaging.Drawing2D
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.MIME.Markup.HTML.CSS
Imports Microsoft.VisualBasic.Serialization.JSON

Public Structure Annotation

    ''' <summary>
    ''' [<see cref="PointF.X"/>] from <see cref="SerialData.pts"/>::<see cref="PointData.pt"/>
    ''' </summary>
    Public X As Single
    Public Text As String
    ''' <summary>
    ''' Font style for <see cref="Text"/>, which can be generated by <see cref="CSSFont"/>
    ''' </summary>
    Public Font As String
    Public Legend As LegendStyles
    ''' <summary>
    ''' Size region for <see cref="Legend"/> Drawing
    ''' </summary>
    Public size As SizeF
    Public color As String

    ''' <summary>
    ''' The target annotation data point is null!
    ''' </summary>
    Const PointNull$ = "The target annotation data point is null!"

    Public Sub Draw(ByRef g As IGraphics, scaler As DataScaler, s As SerialData, r As GraphicsRegion)
        Dim pt As PointData = s.GetPointByX(X)

        If pt.pt.IsEmpty Then
            Call PointNull.PrintException
            Return
        Else
            If size.IsEmpty Then
                size = New SizeF(120, 45)
            End If
        End If

        ' 得到转换坐标
        Dim point As PointF
        Dim color$

        With s.color
            color = Me.color Or $"rgb({ .R},{ .G},{ .B})".AsDefault
        End With

        With pt.pt
            point = scaler.Translate(.X, .Y)
            ' 将坐标置于区域大小的中间
            point = New PointF With {
                .X = point.X - size.Width / 2,
                .Y = point.Y - size.Height / 2
            }
        End With

        Dim legend As New Legend With {
            .color = color,
            .fontstyle = Font,
            .style = Me.Legend,
            .title = Text
        }
        Dim border As New Stroke With {
            .fill = "Black",
            .dash = DashStyle.Solid,
            .width = 3
        }

        Call DrawLegend(
            g,
            New Point(point.X, point.Y),
            size,
            legend,
            border)
    End Sub

    Public Overrides Function ToString() As String
        Return Me.GetJson
    End Function
End Structure
