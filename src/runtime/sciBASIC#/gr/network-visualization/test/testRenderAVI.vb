﻿#Region "Microsoft.VisualBasic::dd5adaa7cce7ab3b998dd2cc7c445e13, gr\network-visualization\test\testRenderAVI.vb"

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

    ' Module testRenderAVI
    ' 
    '     Sub: Main
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.Data.visualize.Network.Canvas
Imports Microsoft.VisualBasic.Data.visualize.Network.FileStream
Imports Microsoft.VisualBasic.Data.visualize.Network.Layouts

Module testRenderAVI

    Sub Main()
        Dim graph = CytoscapeExportAsGraph(
            App.HOME & "\Resources\xcb-main-Edges.csv",
            App.HOME & "\Resources\xcb-main-Nodes.csv")

        Dim video = AVI.DoRenderVideo(graph, {1024, 768}, render3D:=True, drawFrames:=512)

        Call video.WriteBuffer("D:\network.avi")
    End Sub
End Module

