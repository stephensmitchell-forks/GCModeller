﻿Namespace Model

    ''' <summary>
    ''' @author Ralf Wondratschek
    ''' </summary>
    Public Class Line : Implements ICloneable

        Public ReadOnly Property Increase As Double
            Get
                Return NormalVector.W1 * -1 / NormalVector.W2
            End Get
        End Property

        Public ReadOnly Property Offset As Double
        Public ReadOnly Property NormalVector As NormalVector

        Public Sub New(startX As Double, startY As Double, endX As Double, endY As Double)
            Dim m As Double = (endY - startY) / (endX - startX)

            NormalVector = New NormalVector(-1 * m, 1)
            Offset = startY - m * startX
        End Sub

        Public Sub New(vector As NormalVector, offset As Double)
            Me.NormalVector = vector
            Me.Offset = offset
        End Sub

        ''' <summary>
        ''' 进行函数运算，通过<paramref name="x"/>计算出函数值，这个函数值即为分类结果
        ''' </summary>
        ''' <param name="x"></param>
        ''' <returns></returns>
        Public Function CalcY(x As Double) As Double
            Return Increase * x + Offset
        End Function

        ''' <summary>
        ''' 从<paramref name="y"/>通过函数计算反推x
        ''' </summary>
        ''' <param name="y"></param>
        ''' <returns></returns>
        Public Function GetX(y As Double) As Double
            Return (y - Offset) / Increase
        End Function

        Public Overrides Function ToString() As String
            Return "y = " & Math.Round(Increase * 100) / 100.0R & " * x + " & Math.Round(Offset * 100) / 100.0R
        End Function

        Public Overrides Function Equals(o As Object) As Boolean
            If TypeOf o Is Line Then
                Dim line As Line = DirectCast(o, Line)

                Dim offset1 As Integer = CInt(Fix(line.Offset * 1000))
                Dim offset2 As Integer = CInt(Fix(Offset * 1000))

                Return line.NormalVector.Equals(NormalVector) AndAlso offset1 = offset2
            End If

            Return MyBase.Equals(o)
        End Function

        Public Function Clone() As Line
            Return New Line(New NormalVector(NormalVector.W1, NormalVector.W2), Offset)
        End Function

        Private Function ICloneable_Clone() As Object Implements ICloneable.Clone
            Return Clone()
        End Function
    End Class

    ''' <summary>
    ''' Helper for creates the <see cref="Line"/> model
    ''' </summary>
    Public Class LineBuilder

        Public ReadOnly Property Length As Double
            Get
                If StartX = EndX AndAlso StartY = EndY Then
                    Return 0
                End If

                Dim d = (StartX - EndX) ^ 2 + (StartY - EndY) ^ 2
                d = Math.Sqrt(d)
                Return d
            End Get
        End Property

        Public Property StartX As Single
        Public Property EndX As Single
        Public Property StartY As Single
        Public Property EndY As Single

        Public Sub New(startX As Single, startY As Single, endX As Single, endY As Single)
            startX = startX
            endX = endX
            startY = startY
            endY = endY
        End Sub

        Public Function UpdateEndPoint(x As Single, y As Single) As LineBuilder
            EndX = x
            EndY = y
            Return Me
        End Function

        Public Function Build() As Line
            Return New Line(StartX, StartY, EndX, EndY)
        End Function

        Public Overrides Function ToString() As String
            Return Build.ToString
        End Function

        Public Sub FlipPoints()
            Dim val As Single = StartX
            StartX = EndX
            EndX = val

            val = StartY
            StartY = EndY
            EndY = val
        End Sub
    End Class
End Namespace