﻿#Region "Microsoft.VisualBasic::8bff54219538e2ffdbd10e9e07d33bd0, ..\visualbasic_App\www\Microsoft.VisualBasic.NETProtocol\IPv4\IPUtils.vb"

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

Imports System.Runtime.CompilerServices

Public Module IPUtils

    ''' <summary>
    ''' ``\A(25[0-5]|2[0-4]\d|[0-1]?\d?\d)(\.(25[0-5]|2[0-4]\d|[0-1]?\d?\d)){3}\z``
    ''' </summary>
    Const RegexIPAddress As String = "\A(25[0-5]|2[0-4]\d|[0-1]?\d?\d)(\.(25[0-5]|2[0-4]\d|[0-1]?\d?\d)){3}\z"

    <Extension>
    Public Function ValidateIPAddress(IPAddress As String) As Boolean
        If IPAddress.StartsWith("0") Then
            Return False
        End If

        If IPAddress.Length = 0 Then
            Return False
        End If

        If IPAddress.Matches(RegexIPAddress) Then
            Return True
        End If

        Return False
    End Function

    ''' <summary>
    ''' IPv4 address to long
    ''' </summary>
    ''' <param name="IPAddress"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' > http://www.codeproject.com/Articles/28363/How-to-convert-IP-address-to-country-name
    ''' 
    ''' #### How do I convert an IP address to an IP number?
    ''' 
    ''' IP address (IPV4) is divided into four sub-blocks. Each sub-block has a different weight number, 
    ''' each powered by 256. The IP number is being used in the database because it is efficient to search 
    ''' between a range of numbers in the database.
    ''' 
    ''' The beginning IP number and the ending IP number are calculated based on the following formula:
    ''' 
    ''' ```
    ''' IP Number = 16777216*w + 65536*x + 256*y + z (1)
    ''' ```
    ''' 
    ''' where:
    ''' 
    ''' ```
    ''' IP Address = w.x.y.z
    ''' ```
    ''' 
    ''' For example, if the IP address is ``202.186.13.4``, then its IP number is ``3401190660`` based on the above formula.
    ''' 
    ''' ```
    ''' IP Address = 202.186.13.4
    ''' ```
    ''' 
    ''' So, ``w = 202, x = 186, y = 13`` and ``z = 4``
    ''' 
    ''' ```
    ''' IP Number = 16777216*202 + 65536*186 + 256*13 + 4
    '''           = 3388997632 + 12189696 + 3328 + 4
    '''           = 3401190660
    ''' ```
    ''' 
    ''' To reverse the IP number to the IP address:
    ''' 
    ''' ```
    ''' w = int ( IP Number / 16777216 ) % 256
    ''' x = int ( IP Number / 65536 ) % 256
    ''' y = int ( IP Number / 256 ) % 256
    ''' z = int ( IP Number ) % 256
    ''' ```
    ''' 
    ''' where, ``%`` is the mod operator and int returns the integer part of the division.
    ''' </remarks>
    Public Function GetGeoAddress(IPAddress As String) As Integer
        Dim DotTedIPTokens As String() = IPAddress.Split("."c)
        Dim Dot2LongIP As Integer

        For i As Integer = 0 To 4 - 1
            Dim Num As Integer = CInt(Val(DotTedIPTokens(i)))
            Dot2LongIP = ((Num Mod 256) * (256 ^ (4 - i))) + Dot2LongIP
        Next

        Return Dot2LongIP
    End Function
End Module

