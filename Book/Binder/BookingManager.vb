
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
Imports Book.Utils.Extension.DateTimeExtension


Namespace Binder

    Public Class BookingManager
        Inherits BookingController

        Private _all_tables As IEnumerable(Of Models.Tables)
        Private ReadOnly Property all_tables As IEnumerable(Of Models.Tables)
            Get
                If _all_tables Is Nothing Then
                    _all_tables = New TableManager().getAllTables : End If
                Return _all_tables
            End Get
        End Property

        Public Sub New()
        End Sub

        Public Shadows Function _
        reserveBooking(table_id As Integer, start As DateTime, close As DateTime, numberof_seats As Integer, name As String) _
        As Integer
            'このチェックいらないかも
            Dim ids = all_tables.Select(Function(t) t.id)
            If Not ids.Any(Function(id) id = table_id) Then
                CustomMessage.showError(SITUATIONS.存在しないid.ToMessageText, "エラー")
                Return 0
            End If
            'とりあえず主キー重複は、事前ではなくSQLExceptionで取る。

            Try
                Return MyBase.reserveBooking(table_id, start, close, numberof_seats, name)
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


        Public Shadows Function _
        alterBooking(booking_id As UInteger, table_id As Integer, start As DateTime, close As DateTime,
                    Optional numberof_persons As Integer = 0, Optional name As String = Nothing) _
        As Integer

            If beforeAlterValidate() Then

            End If

            Return MyBase.alterBooking(Convert.ToInt32(booking_id), table_id, start, close, numberof_persons, name)

        End Function
        Private Function _
        beforeAlterValidate(table_id As Integer, start As DateTime, close As DateTime) _
        As Boolean

            If Not start.isLessThen(close) Then Return False


            Dim today = Date.Today

        End Function

    End Class
End Namespace
