
'
' Written by : OGURA_Daiki
'    Date    : 2012-10-23
'   Remarks  :
'
Option Strict On
Option Infer On
Option Explicit On

Imports MyADOHelper

Imports Book.Utils.Message

Namespace Binder

    Public Class BookingManager
        Inherits BookingController

        Public Sub New()
        End Sub


        Public Overrides Function _
        reserveBooking(table_id As Integer, targ_date As Date, start As Integer, close As Integer, numberof_seats As Integer, name As String) _
        As Integer
            'このチェックいらないかも
            Dim ids = New TableManager().getAllTables.Select(Function(t) t.id)
            If Not ids.Any(Function(id) id = table_id) Then
                CustomMessage.showError(SITUATIONS.存在しないid.ToMessageText, "エラー")
                Return 0
            End If
            'とりあえず主キー重複は、事前ではなくSQLExceptionで取る。

            Try
                Return MyBase.reserveBooking(table_id, targ_date, start, close, numberof_seats, name)
            Catch e As SqlClient.SqlException
                writeLog("ERROR", e.Message)
                '例えば、エラーコードによってはそのまま処理したい？　その場合はまた別の拡張を考える。
                'この場合、主キー違反はフロントエンド次第では扱いを変えたくなるかもしれない……
                Dim m = New ExceptionLogic.Message(e.Number)
                CustomMessage.showError(m.getMessageByNumber, "エラー")
                Return 0
            Catch e As SqlTypes.SqlTypeException
                writeLog("ERROR", e.Message)
                CustomMessage.showError(e.Message, "エラー")
                Return 0
            End Try

        End Function

    End Class
End Namespace
