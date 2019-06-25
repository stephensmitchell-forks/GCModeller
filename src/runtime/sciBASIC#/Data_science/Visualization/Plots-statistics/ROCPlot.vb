﻿#Region "Microsoft.VisualBasic::f78171b16b18b4e55437b84dd033d40d, Data_science\Visualization\Plots-statistics\ROCPlot.vb"

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

' Module ROCPlot
' 
'     Function: CreateSerial, Plot
' 
' /********************************************************************************/

#End Region

Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Data.ChartPlots.Graphic.Legend
Imports Microsoft.VisualBasic.Data.csv.IO
Imports Microsoft.VisualBasic.DataMining
Imports Microsoft.VisualBasic.Imaging
Imports Microsoft.VisualBasic.Imaging.Drawing2D
Imports Microsoft.VisualBasic.Imaging.Driver
Imports Microsoft.VisualBasic.Language

Public Module ROCPlot

    <Extension>
    Public Function CreateSerial(test As IEnumerable(Of Validation)) As SerialData
        Dim points As New List(Of PointData)
        Dim testData As Validation() = test.ToArray
        Dim AUC As Double = Validation.AUC(testData)

        points += New PointData(0, 0)
        points += testData _
            .Select(Function(pct)
                        Dim x! = (100 - pct.Specificity) / 100
                        Dim y! = pct.Sensibility / 100

                        Return New PointData(x, y)
                    End Function)
        points += New PointData(1, 1)

        Return New SerialData With {
            .color = Color.Black,
            .lineType = DashStyle.Solid,
            .PointSize = 5,
            .Shape = LegendStyles.Triangle,
            .pts = points _
                .OrderBy(Function(p) p.pt.X) _
                .ToArray,
            .title = AUC
        }
    End Function

    <Extension>
    Public Function CreateSerial(test As IEnumerable(Of DataSet)) As SerialData
        Dim data As DataSet() = test.ToArray
        Dim specificity = data(Scan0).Properties.Keys.First(Function(key) key.TextEquals(NameOf(Validation.Specificity)))
        Dim sensibility = data(Scan0).Properties.Keys.First(Function(key) key.TextEquals(NameOf(Validation.Sensibility)))

        Return data _
            .Select(Function(d)
                        Return New Validation With {
                            .Specificity = d(specificity),
                            .Sensibility = d(sensibility),
                            .Threshold = Val(d.ID)
                        }
                    End Function) _
            .CreateSerial
    End Function

    Public Function Plot(roc As SerialData,
                         Optional size$ = "2300,2100",
                         Optional margin$ = g.DefaultUltraLargePadding,
                         Optional bg$ = "white",
                         Optional lineWidth! = 10,
                         Optional fillAUC As Boolean = True,
                         Optional AUCfillColor$ = "skyblue",
                         Optional showReference As Boolean = False) As GraphicsData

        Dim reference As New SerialData With {
            .color = AUCfillColor.TranslateColor,
            .lineType = DashStyle.Dash,
            .PointSize = 5,
            .width = lineWidth,
            .pts = {New PointData(0, 0), New PointData(1, 1)},
            .Shape = LegendStyles.Circle
        }

        roc.width = lineWidth
        roc.color = AUCfillColor.TranslateColor

        Dim input As SerialData()

        If showReference Then
            input = {reference, roc}
        Else
            input = {roc}
        End If

        Dim img = Scatter.Plot(
            input,
            size:=size,
            padding:=margin,
            bg:=bg,
            interplot:=Splines.B_Spline,
            xaxis:="0,1", yaxis:="0,1",
            showLegend:=False,
            fill:=fillAUC,
            Xlabel:="1 - Specificity",
            Ylabel:="Sensibility",
            drawAxis:=True,
            htmlLabel:=False,
            title:=$"ROC (AUC={roc.title})"
        )

        Return img
    End Function
End Module
