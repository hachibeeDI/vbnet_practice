'
' Written by : OGURA_Daiki
'    Date    : 2012-10-23
'   Remarks  :
'
Option Strict On
Option Infer On
Option Explicit On

Namespace Models

    Public Class VarCharColumn
        Inherits BaseColumn(Of String)

        Public Sub New(length As Integer)
            MyBase.New(length)

            If length = 0 Then
                Throw New InvalidOperationException("char型は固定長のカラムです")
            End If
        End Sub

        Public Overrides Function checkDefinition() As Boolean
            Return Me.Value.Count <= Length
        End Function
    End Class
End Namespace
