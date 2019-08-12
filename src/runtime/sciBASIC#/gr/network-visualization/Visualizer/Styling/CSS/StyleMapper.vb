﻿#Region "Microsoft.VisualBasic::392828c353de2633593a5cc21f0fb40b, gr\network-visualization\Visualizer\Styling\CSS\StyleMapper.vb"

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

    '     Structure StyleMapper
    ' 
    '         Function: FromCSS
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.MIME.Markup.HTML.CSS.Parser

Namespace Styling.CSS

    ''' <summary>
    ''' Network object visualize styling object model, the network render css file parser
    ''' </summary>
    Public Structure StyleMapper

        Dim nodeStyles As StyleCreator()
        Dim edgeStyles As StyleCreator()

        ''' <summary>
        ''' node label styling
        ''' </summary>
        Dim labelStyles As StyleCreator()

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Shared Function FromCSS(css As CSSFile) As StyleMapper
            Return css.ParseCSSStyles
        End Function
    End Structure
End Namespace
