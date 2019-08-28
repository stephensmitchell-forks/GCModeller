﻿#Region "Microsoft.VisualBasic::a596d68f21ddfe88f4f2dacfb45376f7, Microsoft.VisualBasic.Core\ApplicationServices\Terminal\InteractiveIODevice\Shell.vb"

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

    '     Class Shell
    ' 
    '         Properties: History, Quite
    ' 
    '         Constructor: (+1 Overloads) Sub New
    '         Sub: Run
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports Microsoft.VisualBasic.Language.UnixBash

Namespace Terminal

    ''' <summary>
    ''' Shell model for console.
    ''' </summary>
    Public Class Shell

        ReadOnly ps1 As PS1
        ReadOnly shell As Action(Of String)

        ''' <summary>
        ''' Command text for exit the shell loop 
        ''' </summary>
        ''' <returns></returns>
        Public Property Quite As String = ":q"
        Public Property History As String = ":h"

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ps1">The commandline prompt prefix headers.</param>
        ''' <param name="exec">How to execute the command line input.</param>
        Sub New(ps1 As PS1, exec As Action(Of String))
            Me.ps1 = ps1
            Me.shell = exec
        End Sub

        Public Sub Run()
            Dim cli As String

            Do While True
                Call Console.Write(ps1.ToString)

                cli = Console.ReadLine

                If String.Equals(cli, Quite) Then
                    Exit Do
                End If

                Call shell(cli)
            Loop
        End Sub
    End Class
End Namespace
