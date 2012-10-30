
'
' Written by : OGURA_Daiki
'    Date    : 2012-10-23
'   Remarks  :
'
Option Strict On
Option Infer On
Option Explicit On

Imports MyADOHelper.ExceptionLogic
Imports MyADOHelper.ExceptionLogic.ErrorState
Imports MyADOHelper.Helper

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
        reserveBooking(table_id As UInteger, start As DateTime, close As DateTime, numberof_seats As Integer, name As String) _
        As ErrorState.IErrorState
            'このチェックいらないかも
            Dim ids = all_tables.Select(Function(t) t.id)
            If Not ids.Any(Function(id) id = table_id) Then
                '                CustomMessage.showError(SITUATIONS.存在しないid.ToMessageText, "エラー")
                Return New NoTableId
            End If

            Dim reserve = Functional.pertial(
                AddressOf MyBase.reserveBooking,
                CInt(table_id), start, close, numberof_seats, name)

            Return TryADOExcute.catchSQLState(reserve)
        End Function


        Public Shadows Function _
        alterBooking(booking_id As UInteger, table_id As Integer, start As DateTime, close As DateTime,
                     numberof_persons As Integer, name As String) _
        As ErrorState.IErrorState

            Dim validate_result = beforeAlterValidate(table_id, start, close)
            If validate_result.GetType IsNot GetType(ErrorState.NoError) Then
                Return validate_result
            End If

            Dim update As Func(Of Integer)
            update = Functional.pertial(
                            AddressOf MyBase.alterBooking,
                            Convert.ToInt32(booking_id), table_id, start, close, numberof_persons, name)

            Return TryADOExcute.catchSQLState(update)
        End Function

        ''' <summary>  </summary>
        ''' <param name="table_id"></param>
        ''' <param name="start"></param>
        ''' <param name="close"></param>
        ''' <remarks></remarks>
        Private Function _
        beforeAlterValidate(table_id As Integer, start As DateTime, close As DateTime) _
        As ErrorState.IErrorState

            If Not start.isLessThen(close) Then Return New InvailedDateRelation
            '存在しないtable_idのようなケースはExceptionを吐いたほうがいい？
            If Not all_tables.Select(Function(t) t.id).Any(Function(id) id = table_id) Then _
                Return New NoTableId

            Dim today = Date.Today
            If today.isLessThen(start) Then Return New InvailedDateRelation

            Return New NoError
        End Function

    End Class
End Namespace
