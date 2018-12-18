﻿#Region "Microsoft.VisualBasic::2bc2c61d21cb6be70028f2342af63972, Data_science\DataMining\Microsoft.VisualBasic.DataMining.Framework\Kernel\Neuron.vb"

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

'     Class Neuron
' 
'         Properties: Length, OutputFunction, W
' 
'         Constructor: (+1 Overloads) Sub New
'         Function: Output, ToString, Train
'         Class Entity
' 
'             Properties: Properties, Width, Y
' 
'             Function: ToString
' 
' 
' 
' 
' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Linq

Namespace Kernel.Classifier

    Public Delegate Function ActiveFunction(weights As Double(), properties As Double()) As Double

    ''' <summary>
    ''' 朴素神经元分类器
    ''' </summary>
    Public Class Neuron

        Public Property W As Double()

        ''' <summary>
        ''' Weights, Entity, OutputValue
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property OutputFunction As ActiveFunction

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Function Output(Entity As Double()) As Double
            Return OutputFunction()(W, Entity)
        End Function

        Public ReadOnly Property Length As Integer
            Get
                Return W.Count
            End Get
        End Property

        Sub New(Length As Integer, Output As ActiveFunction)
            W = ComponentModel.Vector.Randomize(Length).ToArray
            OutputFunction = Output
        End Sub

        Public Overrides Function ToString() As String
            Return W.ToString
        End Function

        Public Shared Function Train(neuron As Neuron, entities As IEnumerable(Of NeuronEntity), Optional Sigma As Double = 0.5, Optional Lambda As Double = 1.5) As Double()
            Dim errList As New List(Of Double)
            Dim training = entities.SafeQuery.ToArray

            Do Until (From sgm In errList Where sgm <= Sigma Select 1).Count / training.Length > 0.9
                For Each Entity As NeuronEntity In training
                    Dim y1 = neuron.Output(Entity.Properties)
                    Dim d As Double = Entity.Y - y1

                    For i As Integer = 0 To neuron.Length - 1
                        neuron.W(i) = neuron.W(i) + Lambda * d * Entity.Properties(i)
                    Next

                    Call errList.Add(d)
                Next
            Loop

            Return errList.ToArray
        End Function
    End Class
End Namespace
