﻿Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel.Ranges.Model
Imports Microsoft.VisualBasic.Language

Namespace NeuralNetwork.StoreProcedure

    ''' <summary>
    ''' 进行所输入的样本数据的归一化的矩阵
    ''' </summary>
    Public Class NormalizeMatrix

        Public Property matrix As DoubleRange()
        Public Property names As String()

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Function NormalizeInput(sample As Sample) As Double()
            Static normalRange As DoubleRange = {0, 1}

            Return sample.status _
                .Select(Function(x, i) matrix(i).ScaleMapping(x, normalRange)) _
                .ToArray
        End Function

        Public Function CreateFromSamples(samples As IEnumerable(Of Sample), names As IEnumerable(Of String)) As NormalizeMatrix
            With samples.ToArray
                Dim len% = .First.status.Length
                Dim index%
                Dim matrix As New List(Of DoubleRange)

                For i As Integer = 0 To len - 1
                    index = i
                    matrix += .Select(Function(sample) sample.status(index)).Range
                Next

                Return New NormalizeMatrix With {
                    .matrix = matrix,
                    .names = names.ToArray
                }
            End With
        End Function
    End Class
End Namespace