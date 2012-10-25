
'
' Written by : OGURA_Daiki
'    Date    : 2012-10-23
'   Remarks  :
'
Option Strict On
Option Infer On
Option Explicit On

Namespace Models

    Public Class DecimalColumn
        Inherits BaseColumn(Of Double)

        Private ReadOnly length_under_point As Integer

        Public Sub New(length As Integer, Optional len_under_point As Integer = 0)
            MyBase.New(length)
            length_under_point = len_under_point
        End Sub


        Public Overrides Function checkDefinition() As Boolean
            If Length = 0 Then Return True

            If Not checkUnderpoint() Then Return False
            Dim var = New String(Me.Value.ToString.TakeWhile(Function(c) c <> "."c).ToArray)
            Return var.Count <= Me.Length
        End Function

        ''' <summary> 小数点以下も調べる </summary>
        Private Function checkUnderpoint() As Boolean
            If length_under_point = 0 Then Return True
            Dim var = New String(Me.Value.ToString.SkipWhile(Function(c) c <> "."c).ToArray)

            Return var.Count <= length_under_point
        End Function
    End Class
End Namespace
