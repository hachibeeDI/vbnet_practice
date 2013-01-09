'
' Written by : OGURA_Daiki
'    Date    : 2012-10-23
'   Remarks  :
'
Option Strict On
Option Infer On
Option Explicit On

Imports System
Imports System.Linq
Imports System.Data.SqlClient

Imports Codeplex.Data

Imports Book.Utils.Extension.DataRowExtension

Namespace Models

    ''' <summary>
    ''' データベースから引き出したりなんだりをする。
    ''' </summary>
    ''' <remarks>TODO:Insert前のバリデーションなんかはプロキシをかませたほうが良いかもしれない</remarks>
    Public Class BookingModel
        Inherits BaseModel

        Private Property bookings As Models.Bookings
        Private Property tables As Models.Tables

        Protected Sub New()
        End Sub

        ''' <summary> すべての予約を取得 </summary>
        Public Overridable Function getAllBookings() As IEnumerable(Of Models.Bookings)
            Return _
            DbExecutor.ExecuteReader(MyBase.getConnection,
                <sql>SELECT TB.id,
                           TB.tables_id,
                           TB.starting_time,
                           TB.closing_time,
                           TB.name_haveReservation,
                           TB.numberof_persons
                       FROM Bookings as TB
                       </sql>.Value,
                ).
                    Select(
                    Function(row) New Models.Bookings() With
                                     {
                                         .id = row.getValue_Type(Of Integer)("id"),
                                         .tables_id = row.getValue_Type(Of Integer)("tables_id"),
                                         .starting_time = row.getValue_Type(Of DateTime)("starting_time"),
                                         .closing_time = row.getValue_Type(Of DateTime)("closing_time"),
                                         .name_haveReservation = row.getValue_Type(Of String)("name_haveReservation"),
            .numberof_persons = row.getValue_Type(Of Integer)("numberof_persons")
                                     }
                                 ).ToArray()
        End Function

        ''' <summary> 指定日の予約を取得 </summary>
        Public Overridable Function getBookings(targ_date As DateTime) As IEnumerable(Of Models.Bookings)
            'Dynamicの方を使えばIDataRecordからの型変換はいらないけども……
            'Dynamicも十分高速。移行を検討
            Return _
            DbExecutor.ExecuteReader(MyBase.getConnection,
                <sql>SELECT TB.id,
                           TB.tables_id,
                           TB.starting_time,
                           TB.closing_time,
                           TB.name_haveReservation,
                           TB.numberof_persons
                       FROM Bookings as TB
                       WHERE TB.date_reserve = @DateReserve</sql>.Value,
                    New With {.DateReserve = targ_date}
                ).
                    Select(
                    Function(row) New Models.Bookings() With
                                     {
                                         .id = row.getValue_Type(Of Integer)("id"),
                                         .tables_id = row.getValue_Type(Of Integer)("tables_id"),
                                         .starting_time = row.getValue_Type(Of DateTime)("starting_time"),
                                         .closing_time = row.getValue_Type(Of DateTime)("closing_time"),
                                         .name_haveReservation = row.getValue_Type(Of String)("name_haveReservation"),
                                         .numberof_persons = row.getValue_Type(Of Integer)("numberof_persons")
                                     }
                                 ).ToArray()
        End Function

        ''' <summary> 指定日の予約を取得 </summary>
        Public Overridable Function getBookings(targ_id As Integer) As IEnumerable(Of Models.Bookings)
            'VBの構文解析がくさってて、一時分割しないとコンパイル時にエラー吐いたりするのでここは分割
            Dim tmp =
            DbExecutor.ExecuteReader(MyBase.getConnection,
                <sql>SELECT
                           *
                       FROM Bookings
                       WHERE id = @booking_id</sql>.Value,
                    New With {.booking_id = targ_id})
            Return tmp.
                Select(
                    Function(row)
                        Return New Models.Bookings() With {
                                .id = row.getValue_Type(Of Integer)("id"),
                                .tables_id = row.getValue_Type(Of Integer)("tables_id"),
                                .starting_time = row.getValue_Type(Of DateTime)("starting_time"),
                                .closing_time = row.getValue_Type(Of DateTime)("closing_time"),
                                .name_haveReservation = row.getValue_Type(Of String)("name_haveReservation"),
                                .numberof_persons = row.getValue_Type(Of Integer)("numberof_persons")}
                    End Function).
                ToArray()
        End Function



        ''' <summary> 新規に予約を取る </summary>
        ''' <param name="table_id"></param>
        ''' <param name="start">予約の開始時刻</param>
        ''' <param name="close">予約の終了時刻</param>
        ''' <param name="name">予約者の氏名</param>
        ''' <returns>ExecutenonQueryのラッパなのでIntegerが返る</returns>
        Protected Overridable Function _
        reserveBooking(table_id As Integer, start As DateTime, close As DateTime, numberof_seats As Integer, name As String) _
        As Integer
            Return DbExecutor.ExecuteNonQuery(MyBase.getConnection,
                              <ins>
INSERT INTO Bookings(
    tables_id, starting_time, closing_time, name_haveReservation,
     numberof_persons)
VALUES(
    @tables_id, @starting_time, @closing_time, @name_haveReservation,
     @numberof_persons)
                              </ins>.Value,
                              New Models.Bookings With {
                                  .tables_id = table_id,
                                  .starting_time = start,
                                  .closing_time = close,
                                  .name_haveReservation = name,
                                  .numberof_persons = numberof_seats
                             })
        End Function


        ' ''' <summary> 予約を変更する </summary>
        ' ''' <param name="table_id">対象のテーブル番号</param>
        ' ''' <param name="start">予約の開始時刻</param>
        ' ''' <param name="close">予約の終了時刻</param>
        ' ''' <returns>引数は更新したい{開始時刻、終了時刻} 返り値は更新に成功した行数を返す</returns>
        ' ''' <remarks>高階関数</remarks>
        'Protected Overridable Overloads Function _
        'alterBooking(booking_id As Integer, table_id As Integer,
        '            start As DateTime, close As DateTime, numberof_persons As Integer) _
        'As Func(Of Integer, Integer, Integer)

        '    Return Function(new_start As Integer, new_close As Integer)
        '               Return DbExecutor.Update(MyBase.getConnection,
        '                                       "Bookings",
        '                                       New With {
        '                                           .starting_time = new_start.ToString,
        '                                           .closing_time = new_close.ToString,
        '                                           .num_persons = numberof_persons
        '                                         },
        '                                       New With {
        '                                            .id = booking_id
        '                                         }
        '                                      )
        '           End Function
        'End Function

        ''' <summary> 予約を変更する </summary>
        ''' <param name="booking_id">予約番号</param>
        ''' <param name="table_id">対象のテーブル番号</param>
        ''' <param name="new_start">新規の開始時刻</param>
        ''' <param name="new_close">新規の終了時刻</param>
        ''' <param name="new_name">予約者の名前</param>
        ''' <returns>引数は更新したい{開始時刻、終了時刻、氏名} 返り値は更新に成功した行数を返す</returns>
        ''' <remarks></remarks>
        Protected Overridable Overloads Function _
        alterBooking(booking_id As Integer, table_id As Integer,
                     new_start As DateTime, new_close As DateTime, numof_persons As Integer, new_name As String) _
        As Integer

            Return DbExecutor.Update(MyBase.getConnection,
                                               "Bookings",
                                               New With {
                                                   .tables_id = table_id,
                                                   .starting_time = new_start.ToString,
                                                   .closing_time = new_close.ToString,
                                                   .numberof_persons = numof_persons,
                                                    .name_haveReservation = new_name
                                                 },
                                               New With {
                                                    .id = booking_id
                                                 }
                                             )
        End Function

        ''' <summary> 予約を変更する </summary>
        ''' <param name="booking_id">予約番号</param>
        ''' <param name="table_id">対象のテーブル番号</param>
        ''' <param name="new_start">新規の開始時刻</param>
        ''' <param name="new_close">新規の終了時刻</param>
        ''' <returns>引数は更新したい{開始時刻、終了時刻、氏名} 返り値は更新に成功した行数を返す</returns>
        ''' <remarks></remarks>
        Protected Overridable Overloads Function _
        alterBooking(booking_id As Integer, table_id As Integer,
                     new_start As DateTime, new_close As DateTime, numof_persons As Integer) _
        As Integer

            Return DbExecutor.Update(MyBase.getConnection,
                                               "Bookings",
                                               New With {
                                                   .tables_id = table_id,
                                                   .starting_time = new_start.ToString,
                                                   .closing_time = new_close.ToString,
                                                   .numberof_persons = numof_persons
                                                 },
                                               New With {
                                                    .id = booking_id
                                                 }
                                             )
        End Function



        ''' <summary> 予約を変更する </summary>
        ''' <param name="booking_id">予約番号</param>
        ''' <param name="table_id">対象のテーブル番号</param>
        ''' <param name="new_start">新規の開始時刻</param>
        ''' <param name="new_close">新規の終了時刻</param>
        ''' <returns>引数は更新したい{開始時刻、終了時刻、氏名} 返り値は更新に成功した行数を返す</returns>
        ''' <remarks></remarks>
        Protected Overridable Overloads Function _
        alterBooking(booking_id As Integer, table_id As Integer,
                     new_start As DateTime, new_close As DateTime) _
        As Integer

            Return DbExecutor.Update(MyBase.getConnection,
                                               "Bookings",
                                               New With {
                                                   .tables_id = table_id,
                                                   .starting_time = new_start.ToString,
                                                   .closing_time = new_close.ToString
                                                 },
                                               New With {
                                                    .id = booking_id
                                                 }
                                             )
        End Function



        ''' <summary>  </summary>
        ''' <param name="table_id"></param>
        ''' <param name="start"></param>
        ''' <param name="close"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function _
        deleteBooking(table_id As Integer, start As DateTime, close As DateTime) _
        As Integer
            Return DbExecutor.Delete(MyBase.getConnection,
                                     "Bookings",
                                     New With {
                                         .tables_id = table_id,
                                         .starting_time = start,
                                         .closing_time = close
                                        }
                                    )
        End Function

    End Class
End Namespace
