'
' Written by : OGURA_Daiki
'    Date    : 2012-10-23
'   Remarks  :
'
Option Strict On
Option Infer On
Option Explicit On

Imports Book.Utils.Extension
Imports Book.Binder.ViewController

Namespace Forms

    Public Class BookingForm

        Private binder As New Binder.BookingManager
        Private scheduledatabinder As SchedulerDataDispatcher

        ''' <summary> Load </summary>
        Private Sub BookingForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
            TablesBindingSource.DataSource =
                New Binder.TableManager().getAllTables()

            scheduledatabinder = New SchedulerDataDispatcher(SchedulerControl1, BookingsBindingSource)

            BookingsBindingSource.DataSource = binder.getAllBookings().ToList
        End Sub


#Region "テスト用実装"
        Private Sub btn_load_Click(sender As System.Object, e As System.EventArgs) Handles btn_load.Click
            ' Xtraschedulerに入れるときはクエリ式のなかみをかえる
            Dim a = binder.getAllBookings().ToList

            ListBox1.DataSource = a.Select(Function(r) r.name_haveReservation).ToList
            BookingsBindingSource.DataSource = a
        End Sub

        Private Sub btn_reserve_Click(sender As System.Object, e As System.EventArgs) Handles btn_reserve.Click
            'Task<T>とかで非同期実行すべき
            binder.reserveBooking(CType(txt_table_id.getValueAsInt, UInt32),
                                  txt_start.getValueAsDate,
                                  txt_close.getValueAsDate,
                                  txt_seats.getValueAsInt,
                                  txt_name.Text)

        End Sub

        Private Sub SchedulerControl1_AppointmentResized(sender As Object, e As DevExpress.XtraScheduler.AppointmentResizeEventArgs) Handles SchedulerControl1.AppointmentResized

            test_start_after.Text = e.HitInterval.Start.ToString
            test_end_after.Text = e.HitInterval.End.ToString
        End Sub

        Private Sub SchedulerControl1_AppointmentResizing(sender As Object, e As DevExpress.XtraScheduler.AppointmentResizeEventArgs) Handles SchedulerControl1.AppointmentResizing
            test_start_before.Text = e.HitInterval.Start.ToString
            test_end_before.Text = e.HitInterval.End.ToString

        End Sub
#End Region

    End Class
End Namespace