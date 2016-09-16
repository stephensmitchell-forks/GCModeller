﻿Imports System.Web.Script.Serialization
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.Serialization.JSON
Imports RDotNET.Extensions.VisualBasic.SymbolBuilder

''' <summary>
''' The R runtime variable.(当隐式转换为字符串的时候，返回的是变量名)
''' </summary>
''' 
Public Class var

    Public ReadOnly Property Name As String

    Public ReadOnly Property type As String
        Get
            Return $"typeof({Name})".__call _
                .AsCharacter _
                .ToArray _
                .FirstOrDefault
        End Get
    End Property

    <ScriptIgnore>
    Public ReadOnly Property RValue As SymbolicExpression
        Get
            Return R.Evaluate(Name)
        End Get
    End Property

    Dim _expr As String

    Public Property Expression As String
        Get
            Return _expr
        End Get
        Set(value As String)
            _expr = value
            Call __setValue()
        End Set
    End Property

    Private Sub __setValue()
        Call $"{Name} <- {_expr}".__call
    End Sub

    Sub New()
        Name = App.NextTempName
    End Sub

    Sub New(expr As String)
        Call Me.New
        Me._expr = expr
        Call __setValue()
    End Sub

    Sub New(name As String, expr As String)
        Me.Name = name
        Me._expr = expr
        Call __setValue()
    End Sub

    ''' <summary>
    ''' <see cref="out"/>
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <returns></returns>
    Public Function [As](Of T)() As T
        Throw New NotImplementedException
    End Function

    Public Overloads Shared Operator <=(x As var, expr As String) As String
        x.Expression = expr
        Return expr
    End Operator

    Public Overloads Shared Operator >=(x As var, expr As String) As String
        Throw New NotImplementedException
    End Operator

    Public Overrides Function ToString() As String
        Return Me.GetJson(simpleDict:=False)
    End Function

    ''' <summary>
    ''' 返回R环境之中的变量名
    ''' </summary>
    ''' <param name="var"></param>
    ''' <returns></returns>
    Public Shared Narrowing Operator CType(var As var) As String
        Return var.Name
    End Operator

    Public Shared Widening Operator CType(expr As String) As var
        Return New var(expr)
    End Operator

    Public Shared Widening Operator CType(expr As Integer) As var
        Return New var(expr)
    End Operator

    Public Shared Widening Operator CType(expr As Double) As var
        Return New var(expr)
    End Operator

    Public Shared Widening Operator CType(expr As Long) As var
        Return New var(expr)
    End Operator

    Public Shared Widening Operator CType(expr As Single) As var
        Return New var(expr)
    End Operator

    Public Shared Widening Operator CType(expr As Boolean) As var
        Return New var(Rbool(expr))
    End Operator

    Public Shared Widening Operator CType(expr As String()) As var
        Return New var(expr:=$"c({expr.Select(AddressOf Rstring).JoinBy(", ")})")
    End Operator

    Public Shared Widening Operator CType(expr As Integer()) As var
        Return New var(c(expr))
    End Operator

    Public Shared Widening Operator CType(expr As Double()) As var
        Return New var(c(expr))
    End Operator

    Public Shared Widening Operator CType(expr As Boolean()) As var
        Return New var(c(expr))
    End Operator

    Public Shared Widening Operator CType(expr As Long()) As var
        Return New var(c(expr))
    End Operator

    Public Shared Widening Operator CType(expr As Single()) As var
        Return New var(c(expr))
    End Operator

    Public Shared Widening Operator CType(expr As var()) As var
        Return New var($"c({expr.Select(Function(x) x.Name).JoinBy(", ")})")
    End Operator

    Public Shared Widening Operator CType(expr As Microsoft.VisualBasic.Language.Value) As var
        Return New var(Scripting.ToString(expr.value, NULL))
    End Operator
End Class