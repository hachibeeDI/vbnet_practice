
'
' Written by : OGURA_Daiki
'    Date    : 2012-10-23
'   Remarks  :
'
Option Strict On
Option Infer On
Option Explicit On

Namespace Models

    Public Class DateTimeColumn
        Inherits BaseColumn(Of DateTime)
        Public Sub New()
        End Sub

        Public Overrides Function checkDefinition() As Boolean
            Return True
        End Function
    End Class
End Namespace
