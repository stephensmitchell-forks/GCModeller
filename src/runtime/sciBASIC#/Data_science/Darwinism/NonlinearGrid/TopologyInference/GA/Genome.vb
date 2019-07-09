﻿Imports Microsoft.VisualBasic.MachineLearning.Darwinism.GAF.Helper
Imports Microsoft.VisualBasic.MachineLearning.Darwinism.Models
Imports Microsoft.VisualBasic.Math
Imports randf = Microsoft.VisualBasic.Math.RandomExtensions

Public Class Genome : Implements Chromosome(Of Genome)

    ReadOnly A As Double() = {-1, 0, 1}
    ReadOnly chromosome As GridSystem

    ''' <summary>
    ''' Number of system variables.
    ''' </summary>
    ReadOnly width As Integer

    Sub New(chr As GridSystem)
        chromosome = chr
        width = chr.A.Dim
    End Sub

    Public Iterator Function Crossover(another As Genome) As IEnumerable(Of Genome) Implements Chromosome(Of Genome).Crossover
        Dim a = Me.chromosome.Clone
        Dim b = another.chromosome.Clone

        SyncLock randf.seeds
            If FlipCoin() Then
                ' crossover A
                randf.seeds.Crossover(a.A.Array, b.A.Array)
            Else
                ' dim(A) is equals to dim(C) and is equals to dim(X)
                Dim i As Integer = randf.NextInteger(upper:=width)
                Dim j As Integer = randf.NextInteger(upper:=width)

                ' crossover C
                randf.seeds.Crossover(a.C(i).B.Array, b.C(j).B.Array)
            End If
        End SyncLock

        Yield New Genome(a)
        Yield New Genome(b)
    End Function

    Public Function Mutate() As Genome Implements Chromosome(Of Genome).Mutate
        Dim clone As New Genome(Me.chromosome.Clone)
        Dim chromosome = clone.chromosome
        ' dim(A) is equals to dim(C) and is equals to dim(X)
        Dim i As Integer = randf.NextInteger(upper:=width)

        If FlipCoin(40) Then
            ' mutate one bit in A vector
            ' A only have -1, 0, 1
            chromosome.A(i) = A(randf.NextInteger(upper:=3))
        Else
            ' mutate one bit in C vector
            chromosome.C(i).B.Array.Mutate(randf.seeds)
        End If

        Return clone
    End Function
End Class
