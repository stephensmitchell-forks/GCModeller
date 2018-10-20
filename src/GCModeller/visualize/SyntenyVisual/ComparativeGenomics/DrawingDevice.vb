﻿#Region "Microsoft.VisualBasic::92083a29d3c4d02ecff9866f25c7edf2, visualize\visualizeTools\ComparativeGenomics\DrawingDevice.vb"

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

'     Class DrawingDevice
' 
'         Function: InvokeDrawing
' 
' 
' /********************************************************************************/

#End Region

Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel.SchemaMaps
Imports Microsoft.VisualBasic.Imaging
Imports Microsoft.VisualBasic.Imaging.Drawing2D
Imports Microsoft.VisualBasic.MIME.Markup.HTML.CSS
Imports Microsoft.VisualBasic.Scripting.Runtime

Namespace ComparativeGenomics

    Public Class DrawingDevice

        <DataFrameColumn> Public Property Type2Arrow As Boolean = False
        <DataFrameColumn> Public Property gDrawHeight As Integer = 100
        <DataFrameColumn> Public Property Font As Font = New Font("Ubuntu", 12, FontStyle.Bold)
        <DataFrameColumn> Public Property titleFont As New Font("Microsoft YaHei", 20)
        <DataFrameColumn> Public Property DistanceHeight As Integer = 800

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="gdi"></param>
        ''' <param name="models"></param>
        ''' <param name="height%"></param>
        ''' <param name="left%"></param>
        ''' <param name="IDDown">ID绘制的位置，对于query，位于图上部分，不需要绘制在下面，对于ref则需要绘制于下方</param>
        ''' <returns></returns>
        Private Function drawBasicGenomeLayout(gdi As Graphics2D, models As GenomeModel,
                                               ByRef height%,
                                               ByRef left%,
                                               IDDown As Boolean,
                                               padding As Padding) As Dictionary(Of String, Rectangle)

            Dim geneLayouts As New Dictionary(Of String, Rectangle)
            Dim overlapRegion As MapLabelLayout

            models.genes = (
                From gene As GeneObject
                In models.genes
                Select gene
                Order By gene.Left Ascending
            ).ToArray

            Dim rect As New Rectangle With {
                .Location = New Point(padding.Left, height + 0.2 * gDrawHeight),
                .Size = New Size(gdi.Width - padding.Horizontal, gDrawHeight - 0.4 * gDrawHeight)
            }

            Call gdi.FillRectangle(Brushes.LightGray, rect)

            Dim scaleFactor As Double = (gdi.Width - padding.Horizontal) / models.Length
            left += models.First.Left * scaleFactor

            '绘制基本图形
            For i As Integer = 0 To models.Count - 2
                Dim gene As GeneObject = models(i)
                gene.Height = gDrawHeight
                Dim nextGene As GeneObject = models(i + 1)
                Dim r As Rectangle

                left = gene.InvokeDrawing(
                    gdi.Graphics, New Point(left, height),
                    NextLeft:=nextGene.Left,
                    scaleFactor:=scaleFactor,
                    arrowRect:=r,
                    IdDrawPositionDown:=IDDown,
                    Font:=Font,
                    AlternativeArrowStyle:=Type2Arrow,
                    overlapLayout:=overlapRegion)

                Call geneLayouts.Add(gene.locus_tag, r)
            Next

            Dim rr As Rectangle

            Call models.Last.InvokeDrawing(gdi.Graphics, New Point(left, height),
                                           NextLeft:=models.Length,
                                           scaleFactor:=scaleFactor,
                                           arrowRect:=rr,
                                           IdDrawPositionDown:=IDDown,
                                           Font:=Font,
                                           AlternativeArrowStyle:=Type2Arrow,
                                           overlapLayout:=overlapRegion)

            Call geneLayouts.Add(models.Last.locus_tag, rr)

            Return geneLayouts
        End Function

        Public Function InvokeDrawing(model As DrawingModel, Optional canvasSize$ = "15024,1000", Optional margin$ = "padding: 300px 50px 300px 50px") As Image
            Dim left, height As Integer
            Dim title$
            Dim size As SizeF
            Dim padding As Padding = margin

            If model.Genome1 Is Nothing OrElse model.Genome2 Is Nothing Then
                Call Console.WriteLine()
            End If

            Using g As Graphics2D = Graphics2D.CreateDevice(canvasSize.SizeParser)
                title = model.Genome1.Title
                size = g.MeasureString(title, titleFont)
                g.DrawString(title, titleFont, Brushes.Black, New Point((g.Width - size.Width) / 2, 10))
                height = 100
                left = padding.Left

                Dim layoutQuery = drawBasicGenomeLayout(g, model.Genome1, height, left, False, padding)

                title = model.Genome2.Title
                size = g.MeasureString(title, titleFont)
                g.DrawString(title, titleFont, Brushes.Black, New Point((g.Width - size.Width) / 2, g.Height - 100))
                height += DistanceHeight
                left = padding.Left

                Dim layoutRef = drawBasicGenomeLayout(g, model.Genome2, height, left, True, padding)

                Call drawHomologousRibbon(g, model, layoutQuery, layoutRef)

                Return g.ImageResource
            End Using
        End Function

        ''' <summary>
        ''' 绘制由于同源所产生的链接信息
        ''' </summary>
        Private Sub drawHomologousRibbon(gdi As Graphics2D, model As DrawingModel,
                                         layoutQuery As Dictionary(Of String, Rectangle),
                                         layoutRef As Dictionary(Of String, Rectangle))

            Dim genome1 = model.Genome1.ToDictionary(Function(g) g.locus_tag)
            Dim genome2 = model.Genome2.ToDictionary(Function(g) g.locus_tag)
            Dim color As SolidBrush

            For Each link As GeneLink In model.Links
                Dim r1 As Rectangle = layoutQuery(link.genome1)
                Dim r2 As Rectangle = layoutRef(link.genome2)
                Dim path2D As New GraphicsPath
                Dim p1, p2, p3, p4 As Point

                p1 = New Point(r1.Location.X, r1.Location.Y + r1.Height + 3)
                p2 = New Point(r1.Right, r1.Top + r1.Height + 3)

                If genome1(link.genome1).Direction < 0 Then
                    Call p1.SwapWith(p2)
                End If

                p3 = New Point(r2.Right, r2.Top - 3)
                p4 = New Point(r2.Location.X, r2.Location.Y - 3)

                If genome2(link.genome2).Direction < 0 Then
                    Call p3.SwapWith(p4)
                End If

                color = New SolidBrush(link.Color Or defaultColor)

                Call path2D.AddLine(p1, p2)
                Call path2D.AddLine(p2, p3)
                Call path2D.AddLine(p3, p4)
                Call path2D.AddLine(p4, p1)

                Call gdi.FillPath(color, path2D)
            Next
        End Sub
    End Class
End Namespace
