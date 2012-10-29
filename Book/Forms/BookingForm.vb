'
' Written by : OGURA_Daiki
'    Date    : 2012-10-23
'   Remarks  :
'
Option Strict On
Option Infer On
Option Explicit On

Imports Book.Utils.Extension

Namespace Forms

    Public Class BookingForm

        Private binder As New Binder.BookingManager
        Private Sub btn_load_Click(sender As System.Object, e As System.EventArgs) Handles btn_load.Click
            ' Xtraschedulerに入れるときはクエリ式のなかみをかえる
            Dim a = binder.getAllBookings().ToList

            ListBox1.DataSource = a.Select(Function(r) r.name_haveReservation).ToList
            BookingsBindingSource.DataSource = a
        End Sub

        Private Sub btn_reserve_Click(sender As System.Object, e As System.EventArgs) Handles btn_reserve.Click
            'Task<T>とかで非同期実行すべき
            binder.reserveBooking(txt_table_id.getValueAsInt,
                                  txt_start.getValueAsDate,
                                  txt_close.getValueAsDate,
                                  txt_seats.getValueAsInt,
                                  txt_name.Text)

        End Sub

        Private Sub BookingForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
            TablesBindingSource.DataSource =
                New Binder.TableManager().getAllTables()


        End Sub

        Private Sub SchedulerControl1_Click(sender As System.Object, e As System.EventArgs) Handles SchedulerControl1.Click

        End Sub
    End Class
End Namespace