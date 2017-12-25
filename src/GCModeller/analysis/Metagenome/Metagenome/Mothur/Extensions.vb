﻿#Region "Microsoft.VisualBasic::111e963f3f7b9e96bfcd737c84bce88b, ..\GCModeller\analysis\Metagenome\Metagenome\Mothur\Extensions.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
    '       xie (genetics@smrucc.org)
    ' 
    ' Copyright (c) 2018 GPL3 Licensed
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

Imports Microsoft.VisualBasic.Data.csv.IO
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Text
Imports r = System.Text.RegularExpressions.Regex

Public Module Extensions

    Public Function SummaryTable(summary As String) As DataSet()
        Dim table As String()() = r _
            .Split(summary, "summary\.seqs\(.+?\)", RegexICSng) _
            .Last _
            .lTokens _
            .Skip(4) _
            .Take(9) _
            .Select(Function(line) line.Split(ASCII.TAB)) _
            .ToArray
        Dim headers = table.First.Skip(2).ToArray
        Dim tsv As DataSet() = table _
            .Skip(1) _
            .Select(Function(row)
                        Return New DataSet With {
                            .ID = row(0).Trim(":"c),
                            .Properties = headers _
                                .SeqIterator(offset:=1) _
                                .ToDictionary(Function(key) key.value,
                                              Function(i) Val(row.ElementAtOrDefault(i)))
                        }
                    End Function) _
            .ToArray

        Return tsv
    End Function
End Module

