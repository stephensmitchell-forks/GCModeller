﻿#Region "Microsoft.VisualBasic::fc14776c5a52de74fa2efbc838e59e2e, ..\visualbasic_App\Data_science\Mathematical\Math\LP\Data\ObjectiveFunction.vb"

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

Namespace LP

    Public Structure ObjectiveFunction

        Dim type As OptimizationType
        Dim xyz#()
        Dim Z#

        Public Overrides Function ToString() As String
            Dim eq As New Equation With {
                .c = Z,
                .xyz = xyz
            }
            Return $"{type.ToString}( {eq.ToString} )"
        End Function
    End Structure
End Namespace