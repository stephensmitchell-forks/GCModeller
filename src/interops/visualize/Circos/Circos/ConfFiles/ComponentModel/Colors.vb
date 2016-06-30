﻿#Region "Microsoft.VisualBasic::b26fd976aac5751f25af5aec4fc4f923, ..\Circos\Circos\ConfFiles\ComponentModel\Colors.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
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

Imports System.Text
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Serialization
Imports Microsoft.VisualBasic.Serialization.JSON

Namespace Configurations

    ''' <summary>
    ''' Use ``<see cref="Circos.chromosomes_color"/>`` to change
    ''' the color Of the ideograms. This approach works well When the only
    ''' thing you want To Do Is change the color Of the segments. 
    '''
    ''' Another way To achieve this Is To actually redefine the colors which
    ''' are used To color the ideograms. The benefit Of doing this Is that
    ''' whenever you refer To the color (which you can use by Using the name
    ''' Of the chromosome), you Get the custom value.
    '''
    ''' If you Then look In the human karyotype file linked To above, you'll see
    ''' that Each chromosome's color is ``chrN`` where N is the number of the
    ''' chromosome. Thus, hs1 has color chr1, hs2 has color chr2, And so
    ''' On. For convenience, a color can be referenced Using 'chr' and 'hs'
    ''' prefixes (chr1 And hs1 are the same color).
    '''
    ''' Colors are redefined by overwriting color definitions, which are
    ''' found In the ``&lt;colors>`` block. This block Is included below from the
    ''' colors_fonts_patterns.conf file, which contains all the Default
    ''' definitions. To overwrite colors, use a "*" suffix And provide a New
    ''' value, which can be a lookup To another color.
    ''' </summary>
    Public Class OverwritesColors : Inherits CircosDistributed

        Public Property colors As Dictionary(Of NamedValue(Of String))

        Sub New()
            Call MyBase.New("", "colors")
        End Sub

        Public Overrides Function ToString() As String
            Return Me.GetJson
        End Function

        Protected Overrides Function GenerateDocument(IndentLevel As Integer) As String
            Dim sb As New StringBuilder

            Call sb.AppendLine("<colors>")

            For Each x As NamedValue(Of String) In colors.Values
                Call sb.AppendLine($"  {x.Name} = {x.x}")
            Next

            Call sb.AppendLine("</colors>")

            Return sb.ToString
        End Function
    End Class
End Namespace