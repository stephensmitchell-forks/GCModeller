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

Namespace ComparativeGenomics

    Public Class DrawingDevice

        <DataFrameColumn> Dim Margin As Integer = 20
        <DataFrameColumn> Dim Type2Arrow As Boolean = False

        Public Function InvokeDrawing(Model As DrawingModel) As Image
            Dim gdi = Graphics2D.CreateDevice(New Size(15024, 1000))
            Dim Left, Height As Integer
            Dim gDrawHeight As Integer = 85

            If Model.Genome1 Is Nothing OrElse Model.Genome2 Is Nothing Then
                Call Console.WriteLine()
            End If

            Dim ID_ConflictedRegion As MapLabelLayout
            Dim Font As Font = New Font("Ubuntu", 12, FontStyle.Bold)
            Dim IDDown As Boolean = False
            Dim __invokeDrawing = Function(Models As GenomeModel) As Dictionary(Of String, Rectangle)
                                      Dim gDrawRECT As New Dictionary(Of String, Rectangle)

                                      Models.genes = (From gene As GeneObject
                                                            In Models.genes
                                                      Select gene
                                                      Order By gene.Left Ascending).ToArray
                                      Dim rect As New Rectangle With {
                                          .Location = New Point(Margin, Height + 0.2 * gDrawHeight),
                                          .Size = New Size(gdi.Width - 2 * Margin, gDrawHeight - 0.4 * gDrawHeight)
                                      }

                                      Call gdi.Graphics.FillRectangle(Brushes.LightGray, rect)
                                      Dim cF As Double = (gdi.Width - 2 * Margin) / Models.Length
                                      Left += Models.First.Left * cF

                                      '绘制基本图形
                                      For i As Integer = 0 To Models.Count - 2
                                          Dim gene As GeneObject = Models(i)
                                          gene.Height = gDrawHeight
                                          Dim nextGene As GeneObject = Models(i + 1)
                                          Dim r As Rectangle

                                          Left = gene.InvokeDrawing(
                                            gdi.Graphics, New Point(Left, Height),
                                            NextLeft:=nextGene.Left,
                                            convertFactor:=cF,
                                            arrowRect:=r,
                                            IdGrawingPositionDown:=IDDown, Font:=Font,
                                            AlternativeArrowStyle:=Type2Arrow, ID_conflictLayout:=ID_ConflictedRegion)

                                          Call gDrawRECT.Add(gene.locus_tag, r)
                                      Next

                                      Dim rr As Rectangle
                                      Call Models.Last.InvokeDrawing(gdi.Graphics, New Point(Left, Height), NextLeft:=Models.Length, convertFactor:=cF,
                                                                           arrowRect:=rr, IdGrawingPositionDown:=IDDown,
                                                                           Font:=Font, AlternativeArrowStyle:=Type2Arrow,
                                                                           ID_conflictLayout:=ID_ConflictedRegion)
                                      Call gDrawRECT.Add(Models.Last.locus_tag, rr)

                                      Return gDrawRECT
                                  End Function

            Dim titleFont As New Font("Microsoft YaHei", 20)
            Dim size As SizeF = gdi.Graphics.MeasureString(Model.Genome1.Title, titleFont)
            Call gdi.Graphics.DrawString(Model.Genome1.Title, titleFont, Brushes.Black, New Point((gdi.Width - size.Width) / 2, 10))
            Height = 100
            Left = Margin
            Dim RegionData1 = __invokeDrawing(Model.Genome1)

            size = gdi.Graphics.MeasureString(Model.Genome2.Title, titleFont)
            Call gdi.Graphics.DrawString(Model.Genome2.Title, titleFont, Brushes.Black, New Point((gdi.Width - size.Width) / 2, gdi.Height - 100))

            IDDown = True
            Height = 650
            Left = Margin
            Dim RegionData2 = __invokeDrawing(Model.Genome2)

            Dim G1 = Model.Genome1.ToDictionary(Function(g) g.locus_tag), G2 = Model.Genome2.ToDictionary(Function(g) g.locus_tag)
            Dim cl As SolidBrush

            '绘制连接信息
            For Each Link In Model.Links
                Dim r1 As Rectangle = RegionData1(Link.genome1)
                Dim r2 As Rectangle = RegionData2(Link.genome2)
                Dim drModel As New GraphicsPath

                Dim p1, p2, p3, p4 As Point
                p1 = New Point(r1.Location.X, r1.Location.Y + r1.Height + 3)
                p2 = New Point(r1.Right, r1.Top + r1.Height + 3)

                If G1(Link.genome1).Direction < 0 Then
                    Call p1.SwapWith(p2)
                End If

                p3 = New Point(r2.Right, r2.Top - 3)
                p4 = New Point(r2.Location.X, r2.Location.Y - 3)

                If G2(Link.genome2).Direction < 0 Then
                    Call p3.SwapWith(p4)
                End If

                cl = New SolidBrush(If(Link.Color = Nothing, Color.Brown, Link.Color))

                Call drModel.AddLine(p1, p2)
                Call drModel.AddLine(p2, p3)
                Call drModel.AddLine(p3, p4)
                Call drModel.AddLine(p4, p1)
                Call gdi.Graphics.FillPath(cl, drModel)
            Next

            Return gdi.ImageResource
        End Function
    End Class
End Namespace
