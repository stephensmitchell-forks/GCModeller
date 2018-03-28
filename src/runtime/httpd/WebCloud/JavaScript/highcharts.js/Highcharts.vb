﻿#Region "Microsoft.VisualBasic::2efc82dfa44c1cd366d474cc0e081eca, WebCloud\SMRUCC.WebCloud.highcharts\Highcharts.vb"

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

' Class Highcharts
' 
'     Properties: chart, credits, legend, plotOptions, responsiveOptions
'                 series, subtitle, title, tooltip, xAxis
'                 yAxis
' 
' Class Highcharts3D
' 
'     Properties: zAxis
' 
' /********************************************************************************/

#End Region

Imports Microsoft.VisualBasic.ApplicationServices.Debugging
Imports Microsoft.VisualBasic.Text.Xml

''' <summary>
''' The abstract ``highcharts.js`` data model
''' </summary>
''' <typeparam name="T"></typeparam>
Public MustInherit Class Highcharts(Of T)
    Implements IVisualStudioPreviews

    Protected Friend reference As New List(Of String) From {
        "https://code.highcharts.com/highcharts.src.js"
    }

    ''' <summary>
    ''' The charting options
    ''' </summary>
    ''' <returns></returns>
    Public Property chart As chart
    Public Property title As title
    Public Property subtitle As title
    Public Property yAxis As Axis
    Public Property xAxis As Axis
    Public Property tooltip As tooltip
    Public Property plotOptions As plotOptions
    Public Property legend As legendOptions
    Public Property series As T()
    Public Property responsiveOptions As responsiveOptions
    Public Property credits As credits

    ''' <summary>
    ''' HTML Debug view in VisualStudio
    ''' </summary>
    ''' <returns></returns>
    Protected ReadOnly Property Preview As String Implements IVisualStudioPreviews.Previews
        Get
            Return sprintf(<html>
                               <head>
                                   <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
                                   <meta name="viewport" content="width=device-width, initial-scale=1"/>

                                   <title>Highcharts VisualStudio Previews</title>

                                   <style type="text/css">
                                   </style>

                                   <script type="text/javascript" src="https://code.highcharts.com/highcharts.src.js"></script>
                               </head>
                               <body>
                                   <div id="container" style="min-width: 310px; max-width: 400px; height: 400px; margin: 0 auto">
                                   </div>
                                   <script type="text/javascript">
                                       %s
                                   </script>
                               </body>
                           </html>, Javascript.WriteJavascript("container", Me))
        End Get
    End Property

End Class

Public MustInherit Class Highcharts3D(Of T) : Inherits Highcharts(Of T)

    ''' <summary>
    ''' The Z- axis in a 3D zone space.
    ''' </summary>
    ''' <returns></returns>
    Public Property zAxis As Axis

End Class
