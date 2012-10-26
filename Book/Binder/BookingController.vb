﻿'
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

Namespace Binder

    ''' <summary>
    ''' データベースから引き出したりなんだりをする。
    ''' </summary>
    ''' <remarks>TODO:Insert前のバリデーションなんかはプロキシをかませたほうが良いかもしれない</remarks>
    Public Class BookingController
        Inherits BaseController

        Private Property bookings As Models.Bookings
        Private Property tables As Models.Tables

        Protected Sub New()
        End Sub

        Public Overridable Function getAllBookings() As IEnumerable(Of Models.Bookings)
            Return _
            DbExecutor.ExecuteReader(MyBase.getConnection,
                <sql>SELECT TB.tables_id, TT.maximum_seats, TB.starting_time, TB.closing_time, TB.name_haveReservation, TB.num_persons
                       FROM Bookings as TB INNER JOIN Tables as TT ON TB.tables_id = TT.id
                       </sql>.Value,
                ).
                    Select(
                    Function(row) New Models.Bookings() With
                                     {
                                         .tables_id = row.getValue_Type(Of Integer)("tables_id"),
                                         .tables_maximum_seats = row.getValue_Type(Of Integer)("maximum_seats"),
                                         .starting_time = row.getValue_Type(Of String)("starting_time"),
                                         .closing_time = row.getValue_Type(Of String)("closing_time"),
                                         .name_haveReservation = row.getValue_Type(Of String)("name_haveReservation"),
                                         .num_persons = row.getValue_Type(Of Integer)("num_persons")
                                     }
                                 ).ToArray()
        End Function

        Public Overridable Function getBookings(targ_date As Date) As IEnumerable(Of Models.Bookings)
            'Dynamicの方を使えばIDataRecordからの型変換はいらないけども……
            Return _
            DbExecutor.ExecuteReader(MyBase.getConnection,
                <sql>SELECT TB.tables_id, TT.maximum_seats, TB.starting_time, TB.closing_time, TB.name_haveReservation, TB.num_persons
                       FROM Bookings as TB INNER JOIN Tables as TT ON TB.tables_id = TT.id
                       WHERE date_reserve = @DateReserve</sql>.Value,
                    New With {.DateReserve = targ_date}
                ).
                    Select(
                    Function(row) New Models.Bookings() With
                                     {
                                         .tables_id = row.getValue_Type(Of Integer)("tables_id"),
                                         .tables_maximum_seats = row.getValue_Type(Of Integer)("maximum_seats"),
                                         .starting_time = row.getValue_Type(Of String)("starting_time"),
                                         .closing_time = row.getValue_Type(Of String)("closing_time"),
                                         .name_haveReservation = row.getValue_Type(Of String)("name_haveReservation"),
                                         .num_persons = row.getValue_Type(Of Integer)("num_persons")
                                     }
                                 ).ToArray()
        End Function


        ''' <summary> 新規に予約を取る </summary>
        ''' <param name="table_id"></param>
        ''' <param name="targ_date">対象日付</param>
        ''' <param name="start">予約の開始時刻</param>
        ''' <param name="close">予約の終了時刻</param>
        ''' <param name="name">予約者の氏名</param>
        ''' <returns>ExecutenonQueryのラッパなのでIntegerが返る</returns>
        Public Overridable Function _
        reserveBooking(table_id As Integer, targ_date As Date, start As Integer, close As Integer, numberof_seats As Integer, name As String) _
        As Integer
            Return DbExecutor.ExecuteNonQuery(MyBase.getConnection,
                              <ins>
INSERT INTO Bookings(
    tables_id, starting_time, closing_time, name_haveReservation,
    date_reserve, num_persons)
VALUES(
    @tables_id, @starting_time, @closing_time, @name_haveReservation,
    @date_reserve, @num_persons)
                              </ins>.Value,
                              New Models.Bookings With {
                                  .tables_id = table_id,
                                  .starting_time = start.ToString,
                                  .closing_time = close.ToString,
                                  .name_haveReservation = name,
                                  .date_reserve = targ_date,
                                  .num_persons = numberof_seats
                             })
        End Function


        'Update部分は後日修正

        ''' <summary> 予約を変更する </summary>
        ''' <param name="table_id">対象のテーブル番号</param>
        ''' <param name="targ_date">対象日付</param>
        ''' <param name="start">予約の開始時刻</param>
        ''' <param name="close">予約の終了時刻</param>
        ''' <returns>引数は更新したい{開始時刻、終了時刻} 返り値は更新に成功した行数を返す</returns>
        ''' <remarks>高階関数</remarks>
        Public Overridable Overloads Function _
        alterBooking(table_id As Integer, targ_date As Date, start As Integer, close As Integer, numberof_persons As Integer) _
        As Func(Of Integer, Integer, Integer)

            Return Function(new_start As Integer, new_close As Integer)
                       Return DbExecutor.Update(MyBase.getConnection,
                                               "Bookings",
                                               New With {
                                                   .starting_time = new_start.ToString,
                                                   .closing_time = new_close.ToString,
                                                   .num_person = numberof_persons
                                                 },
                                               New With {
                                                   .date_reserve = targ_date.ToString,
                                                   .tables_id = table_id,
                                                   .starting_time = start,
                                                   .closing_time = close
                                                 }
                                              )
                   End Function
        End Function

        ''' <summary> 予約を変更する </summary>
        ''' <param name="table_id">対象のテーブル番号</param>
        ''' <param name="targ_date">対象日付</param>
        ''' <param name="start">予約の開始時刻</param>
        ''' <param name="close">予約の終了時刻</param>
        ''' <param name="name">予約者の名前</param>
        ''' <returns>引数は更新したい{開始時刻、終了時刻、氏名} 返り値は更新に成功した行数を返す</returns>
        ''' <remarks>高階関数</remarks>
        Public Overridable Overloads Function _
        alterBooking(table_id As Integer, targ_date As Date, start As Integer, close As Integer, numberof_seats As Integer, name As String) _
        As Func(Of Integer, Integer, String, Integer)

            Return Function(new_start As Integer, new_close As Integer, new_name As String)
                       Return DbExecutor.Update(MyBase.getConnection,
                                               "Bookings",
                                               New With {
                                                   .starting_time = new_start.ToString,
                                                   .closing_time = new_close.ToString,
                                                   .name_haveReservation = new_name
                                                 },
                                               New With {
                                                   .date_reserve = targ_date.ToString,
                                                   .tables_id = table_id,
                                                   .starting_time = start,
                                                   .closing_time = close
                                                 }
                                              )
                   End Function
        End Function

        ''' <summary>  </summary>
        ''' <param name="table_id"></param>
        ''' <param name="targ_date"></param>
        ''' <param name="start"></param>
        ''' <param name="close"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function _
        deleteBooking(table_id As Integer, targ_date As Date, start As Integer, close As Integer) _
        As Integer
            Return DbExecutor.Delete(MyBase.getConnection,
                                     "Bookings",
                                     New With {
                                         .date_reserve = targ_date.ToString,
                                         .tables_id = table_id,
                                         .starting_time = start,
                                         .closing_time = close
                                        }
                                    )
        End Function

    End Class
End Namespace