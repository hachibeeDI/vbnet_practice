
'
' Written by : OGURA_Daiki
'    Date    : 2012-10-23
'   Remarks  :
'
Option Strict On
Option Infer On
Option Explicit On

Namespace Models
    Public Class IntColumn
        Inherits BaseColumn(Of Integer)

        Public Sub New(Optional length As Integer = 0)
            MyBase.New(Length)
        End Sub

        Public Overrides Function checkDefinition() As Boolean
            If Length = 0 Then Return True

            Return Me.Value.ToString.Count >= Me.Length
        End Function
    End Class

End Namespace
