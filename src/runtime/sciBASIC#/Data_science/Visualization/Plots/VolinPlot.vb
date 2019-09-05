﻿Imports System.Drawing
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.ComponentModel.Ranges.Model
Imports Microsoft.VisualBasic.Data.ChartPlots.Graphic
Imports Microsoft.VisualBasic.Data.ChartPlots.Graphic.Axis
Imports Microsoft.VisualBasic.Data.csv.IO
Imports Microsoft.VisualBasic.Imaging
Imports Microsoft.VisualBasic.Imaging.Drawing2D
Imports Microsoft.VisualBasic.Imaging.Drawing2D.Colors
Imports Microsoft.VisualBasic.Imaging.Driver
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Math
Imports Microsoft.VisualBasic.Math.Interpolation
Imports Microsoft.VisualBasic.Math.Quantile
Imports Microsoft.VisualBasic.MIME.Markup.HTML.CSS
Imports Microsoft.VisualBasic.Scripting.Runtime
Imports Microsoft.VisualBasic.Serialization.JSON

''' <summary>
''' ## 小提琴图
''' 
''' + 高度为数据的分布位置
''' + 宽度为对应的百分位上的数据点的数量
''' + 长度为最小值与最大值之间的差值
''' </summary>
Public Module VolinPlot

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dataset">数据集中的样本数据可以不必等长</param>
    ''' <param name="size"></param>
    ''' <param name="margin"></param>
    ''' <param name="bg"></param>
    ''' <param name="colorset"></param>
    ''' <returns></returns>
    Public Function Plot(dataset As IEnumerable(Of DataSet),
                         Optional size$ = "3100,2700",
                         Optional margin$ = g.DefaultPadding,
                         Optional bg$ = "white",
                         Optional colorset$ = DesignerTerms.TSFShellColors,
                         Optional Ylabel$ = "y axis",
                         Optional yLabelFontCSS$ = CSSFont.PlotSubTitle,
                         Optional ytickFontCSS$ = CSSFont.PlotSmallTitle) As GraphicsData
        With dataset.ToArray
            Return .PropertyNames _
                   .Select(Function(label)
                               Return New NamedCollection(Of Double)(label, .Vector(label))
                           End Function) _
                   .DoCall(Function(data)
                               Return VolinPlot.Plot(
                                   dataset:=data,
                                   size:=size,
                                   margin:=margin,
                                   bg:=bg,
                                   colorset:=colorset,
                                   Ylabel:=Ylabel,
                                   yLabelFontCSS:=yLabelFontCSS,
                                   ytickFontCSS:=ytickFontCSS
                               )
                           End Function)
        End With
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dataset">数据集中的样本数据可以不必等长</param>
    ''' <param name="size"></param>
    ''' <param name="margin"></param>
    ''' <param name="bg"></param>
    ''' <param name="colorset"></param>
    ''' <returns></returns>
    Public Function Plot(dataset As IEnumerable(Of NamedCollection(Of Double)),
                         Optional size$ = "3100,2700",
                         Optional margin$ = Canvas.Resolution2K.PaddingWithTopTitleAndBottomLegend,
                         Optional bg$ = "white",
                         Optional colorset$ = DesignerTerms.TSFShellColors,
                         Optional Ylabel$ = "y axis",
                         Optional yLabelFontCSS$ = CSSFont.PlotSubTitle,
                         Optional ytickFontCSS$ = CSSFont.PlotSmallTitle) As GraphicsData

        ' 进行数据分布统计计算
        Dim matrix As NamedCollection(Of Double)() = dataset _
            .Select(Function(d)
                        Dim quartile = d.Quartile
                        Dim normals = d.AsVector _
                            .Outlier(quartile) _
                            .normal

                        Return New NamedCollection(Of Double) With {
                            .name = d.name,
                            .value = normals
                        }
                    End Function) _
            .ToArray
        'Dim quantiles = matrix _
        '    .Select(Function(data)
        '                Return New NamedValue(Of QuantileEstimationGK) With {
        '                    .Name = data.name,
        '                    .Value = data.GKQuantile
        '                }
        '            End Function) _
        '    .ToArray

        ' 用来构建Y坐标轴的总体数据
        Dim alldata = matrix _
            .Select(Function(d) d.AsEnumerable) _
            .IteratesALL _
            .ToArray
        Dim yticks = alldata.Range.CreateAxisTicks
        Dim yTickFont As Font = CSSFont.TryParse(ytickFontCSS)
        Dim colors = Designer.GetColors(colorset, matrix.Length)

        Dim plotInternal =
            Sub(ByRef g As IGraphics, region As GraphicsRegion)
                Dim plotRegion As Rectangle = region.PlotRegion
                Dim Y = d3js.scale.linear.domain(yticks).range(integers:={plotRegion.Top, plotRegion.Bottom})
                Dim yScale As New YScaler(False) With {
                    .region = plotRegion,
                    .Y = Y
                }

                Call Axis.DrawY(g, Pens.Black, Ylabel, yScale, 0, yticks, YAxisLayoutStyles.Left, Nothing, yLabelFontCSS, yTickFont, htmlLabel:=False)

                Dim maxWidth = plotRegion.Width / (matrix.Length + 1)
                Dim semiWidth = maxWidth / 2
                Dim groupInterval = (plotRegion.Width / matrix.Length - maxWidth) / matrix.Length
                Dim X As Single = plotRegion.Left + groupInterval + semiWidth
                Dim index As i32 = Scan0

                For Each group As NamedCollection(Of Double) In matrix
                    ' Dim q = quantiles(group)
                    Dim upper = plotRegion.Bottom - Y(group.Max)
                    Dim lower = plotRegion.Bottom - Y(group.Min)
                    ' 计算数据分布的密度之后，进行左右对称的线条的生成
                    Dim line_l As New List(Of PointF)
                    Dim line_r As New List(Of PointF)
                    Dim q0 = group.Min
                    Dim dy = (group.Max - group.Min) / 100
                    Dim outliers As New List(Of PointF)

                    For p As Integer = 10 To 100 Step 10
                        Dim q1 = q0 + dy
                        Dim range As DoubleRange = {q0, q1}
                        Dim density = group.Count(AddressOf range.IsInside)

                        line_l += New PointF With {.X = density, .Y = lower - p * dy}
                        line_r += New PointF With {.X = density, .Y = lower - p * dy}
                        q0 = q1
                    Next

                    Call $"{group.name} = {New Double() {group.Min, group.Max}.GetJson}".__DEBUG_ECHO

                    ' 进行宽度伸缩映射
                    Dim maxDensity As DoubleRange = line_l.X
                    Dim densityWidth As Single

                    For i As Integer = 0 To line_r.Count - 1
                        densityWidth = (line_l(i).X - maxDensity.Min) / maxDensity.Length * semiWidth

                        line_l(i) = New PointF With {.X = X - densityWidth, .Y = line_l(i).Y}
                        line_r(i) = New PointF With {.X = X + densityWidth, .Y = line_r(i).Y}
                    Next

                    line_l = line_l.BSpline
                    line_r = line_r.BSpline

                    ' 需要插值么？
                    ' 生成多边形
                    Dim polygon As New List(Of PointF)

                    ' 左下 -> 左上
                    polygon += line_l
                    ' 左上 -> 右上
                    polygon += line_r.Last
                    ' 右上 -> 右下
                    polygon += line_r.ReverseIterator.Skip(1)
                    ' 最后 右下 -> 左下会自动封闭

                    ' 绘制当前的这个多边形
                    Call g.DrawPolygon(Pens.LightGray, polygon)
                    Call g.FillPolygon(New SolidBrush(colors(++index)), polygon)

                    ' 绘制X坐标轴分组标签
                    Call g.DrawString(group.name, CSSFont.TryParse(yLabelFontCSS), Brushes.Black, New PointF With {.X = X, .Y = plotRegion.Bottom + 10})

                    X += semiWidth + groupInterval + semiWidth
                Next
            End Sub

        Return g.GraphicsPlots(size.SizeParser, margin, bg, plotInternal)
    End Function
End Module
