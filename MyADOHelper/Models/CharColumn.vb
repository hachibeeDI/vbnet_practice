
'
' Written by : OGURA_Daiki
'    Date    : 2012-10-23
'   Remarks  :
'
Option Strict On
Option Infer On
Option Explicit On

Imports System.Text.RegularExpressions

Namespace Models
    ''' <summary> 固定長。半角文字のみ。面倒かつ無意味なので半角カタカナも許可しない </summary>
    ''' <remarks></remarks>
    Public Class CharColumn
        Inherits BaseColumn(Of String)

        Public Sub New(length As Integer)
            MyBase.New(length)

            If length = 0 Then
                Throw New InvalidOperationException("char型は固定長のカラムです")
            End If
        End Sub

        Public Overrides Function checkDefinition() As Boolean
            Dim r = New Regex("[ -~]")
            '条件に当てはまらないものがひとつでもあれば
            If Value.Any(Function(c) Not r.IsMatch(c)) Then Return False
            Return Me.Value.Count <= Length
        End Function
    End Class
End Namespace