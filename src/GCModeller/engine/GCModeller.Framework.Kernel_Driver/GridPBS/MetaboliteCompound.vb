﻿#Region "Microsoft.VisualBasic::ff53d06ab9349609725620b10f531b95, engine\GCModeller.Framework.Kernel_Driver\GridPBS\MetaboliteCompound.vb"

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

    '     Structure MetaboliteCompound
    ' 
    '         Properties: Handle, Identifier, Quantity
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports Microsoft.VisualBasic.ComponentModel
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic

Namespace GridPBS

    ''' <summary>
    ''' 仅用于数据交换的对象
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure MetaboliteCompound
        Implements IAddressOf
        Implements INamedValue

        Public Property Handle As Integer Implements IAddressOf.Address
        Public Property Identifier As String Implements INamedValue.Key
        Public Property Quantity As Double

    End Structure
End Namespace
