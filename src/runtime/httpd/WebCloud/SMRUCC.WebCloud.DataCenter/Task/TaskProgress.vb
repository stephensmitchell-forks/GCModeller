﻿#Region "Microsoft.VisualBasic::278440cac88fdc4fcf66bb53c2ee7430, ..\httpd\WebCloud\SMRUCC.WebCloud.DataCenter\Task\TaskProgress.vb"

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

Imports Microsoft.VisualBasic.Serialization.JSON

Namespace Platform

    ''' <summary>
    ''' JSON result data of the task progress.(用于在网页上面显示任务进度的返回值)
    ''' </summary>
    Public Class TaskProgress

        ''' <summary>
        ''' 当前的任务至今阶段的编号
        ''' </summary>
        ''' <returns></returns>
        Public Property current As Integer
        ''' <summary>
        ''' 任务的内容描述
        ''' </summary>
        ''' <returns></returns>
        Public Property progress As String()

        Sub New()
        End Sub

        Sub New(current%)
            Me.current = current
        End Sub

        Public Overrides Function ToString() As String
            Return Me.GetJson
        End Function
    End Class
End Namespace
