﻿#Region "Microsoft.VisualBasic::ab95250b748b7bf6235a85eae1e84094, Data_science\MachineLearning\MachineLearning\Darwinism\GeneticAlgorithm\EnvironmentDriver.vb"

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

'     Class EnvironmentDriver
' 
'         Properties: AutoAdjustMutationRate, Iterations, Threshold
' 
'         Constructor: (+1 Overloads) Sub New
' 
'         Function: CreateReport
' 
'         Sub: Terminate, Train
' 
'     Structure outPrint
' 
'         Properties: chromosome, fit, iter, MutationRate
' 
'         Function: ToString
' 
'         Sub: PrintTitle
' 
' 
' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.MachineLearning.Darwinism.GAF.Helper
Imports Microsoft.VisualBasic.MachineLearning.Darwinism.Models

Namespace Darwinism.GAF

    ''' <summary>
    ''' 发生种群进化所需要的环境压力产生器
    ''' </summary>
    ''' <typeparam name="Chr"></typeparam>
    Public Class EnvironmentDriver(Of Chr As {Class, Chromosome(Of Chr)}) : Inherits IterationReporter(Of GeneticAlgorithm(Of Chr))

        Dim core As GeneticAlgorithm(Of Chr)
        Dim terminated As Boolean = False
        Dim takeBestSnapshot As Action(Of Chr, Double)

        ''' <summary>
        ''' 需要运行的总的迭代次数
        ''' </summary>
        ''' <returns></returns>
        Public Property Iterations As Integer
        Public Property Threshold As Double

        ''' <summary>
        ''' 创建一个新的环境压力驱动程序,用来驱动模型的进化学习
        ''' </summary>
        ''' <param name="ga"></param>
        Sub New(ga As GeneticAlgorithm(Of Chr), takeBestSnapshot As Action(Of Chr, Double))
            Me.core = ga
            Me.takeBestSnapshot = takeBestSnapshot
        End Sub

        Public Overrides Sub Train(Optional parallel As Boolean = False)
            Dim errStatSize As Integer = 50
            Dim errors As New Queue(Of Double)(capacity:=errStatSize)
            Dim previousErrAverage As Double = Double.MaxValue

            ' 如果这个队列中的误差值全部都是一样的话
            ' 则将当前的种群销毁
            ' 将best突变一个位点后，自动重新初始化
            For i As Integer = 0 To errStatSize
                Call errors.Enqueue(Long.MaxValue)
            Next

            terminated = False

            For i As Integer = 0 To Iterations
                If terminated Then
                    Exit For
                Else
                    Call core.Evolve()
                End If

                With core.GetFitness(core.Best)
                    If Not reporter Is Nothing Then
                        Call reporter(i, .ByRef, core)
                    End If

                    ' NaN的结果值与阈值相比较也是小于零的
                    ' 在这里跳过NaN值的测试
                    If Not .IsNaNImaginary AndAlso .CompareTo(Threshold) < 0 Then
                        Exit For
                    Else
                        Call errors.Enqueue(.ByRef)
                        Call errors.Dequeue()

                        Dim firstError# = errors.First

                        If Math.Abs(firstError - Threshold) > 0.01 AndAlso errors.All(Function(e) e = firstError) Then
                            ' 因为已经很长时间没有变化误差了
                            ' 所以最佳的个体肯定已经陷入了局部最优
                            Dim bestSeed As Chr = core.Best
                            Dim seed As Chr = bestSeed _
                                .Mutate _
                                .With(Sub(c) c.MutationRate = core.Best.MutationRate)
                            Dim newPop As Population(Of Chr) = core.Best.InitialPopulation(core.population.initialSize, parallel:=True)
                            Dim newCore As New GeneticAlgorithm(Of Chr)(newPop, core.GetRawFitnessModel, core.popStrategy.type, core.seeds)

                            core = newCore

                            Call "GA module do RE-seeding as local optimal solution was found...".Warning
                            Call takeBestSnapshot(bestSeed, .ByRef)
                        End If
                    End If
                End With
            Next
        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <example>
        ''' ' If fitness is satisfying - we can stop Genetic algorithm
        ''' 
        ''' If bestFit &lt;= Threshold Then
        '''     Call ga.Terminate()
        ''' End If
        ''' </example>
        Public Sub Terminate()
            Me.terminated = True
        End Sub

        Public Shared Function CreateReport(iteration%, fitness#, ga As GeneticAlgorithm(Of Chr)) As outPrint
            Dim best As Chr = ga.Best
            Dim bestFit As Double = ga.GetFitness(best)

            ' Listener prints best achieved solution
            Return New outPrint With {
                .iter = iteration,
                .fit = bestFit,
                .chromosome = best.ToString,
                .MutationRate = best.MutationRate
            }
        End Function
    End Class

    Public Structure outPrint

        Public Property iter%
        Public Property fit#
        Public Property chromosome$
        Public Property MutationRate#

        Public Shared Sub PrintTitle()
            ' just for pretty print
            Console.WriteLine($"{NameOf(outPrint.iter)}{vbTab}{NameOf(outPrint.fit)}{vbTab}{NameOf(outPrint.chromosome)}({NameOf(outPrint.MutationRate)})")
        End Sub

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Overrides Function ToString() As String
            Return $"{iter}{vbTab}{fit}{vbTab}{chromosome}({MutationRate})"
        End Function
    End Structure
End Namespace
