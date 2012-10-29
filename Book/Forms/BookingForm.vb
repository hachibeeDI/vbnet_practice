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

        Private Sub SchedulerControl1_AppointmentResized(sender As Object, e As DevExpress.XtraScheduler.AppointmentResizeEventArgs) Handles SchedulerControl1.AppointmentResized

            test_start_after.Text = e.HitInterval.Start.ToString
            test_end_after.Text = e.HitInterval.End.ToString
        End Sub

        Private Sub SchedulerControl1_AppointmentResizing(sender As Object, e As DevExpress.XtraScheduler.AppointmentResizeEventArgs) Handles SchedulerControl1.AppointmentResizing
            test_start_before.Text = e.HitInterval.Start.ToString
            test_end_before.Text = e.HitInterval.End.ToString

        End Sub

        Private Sub SchedulerControl1_Click(sender As System.Object, e As System.EventArgs) Handles SchedulerControl1.Click

        End Sub

        Private Sub SchedulerControl1_InitNewAppointment(sender As Object, e As DevExpress.XtraScheduler.AppointmentEventArgs) Handles SchedulerControl1.InitNewAppointment

        End Sub

        Private Sub SchedulerControl1_InplaceEditorShowing(sender As Object, e As DevExpress.XtraScheduler.InplaceEditorEventArgs) Handles SchedulerControl1.InplaceEditorShowing

        End Sub

        Private Sub SchedulerControl1_StorageChanged(sender As Object, e As System.EventArgs) Handles SchedulerControl1.StorageChanged

        End Sub

        Private Sub SchedulerStorage1_AppointmentChanging(sender As Object, e As DevExpress.XtraScheduler.PersistentObjectCancelEventArgs) Handles SchedulerStorage1.AppointmentChanging

        End Sub

        Private Sub SchedulerStorage1_AppointmentCollectionLoaded(sender As Object, e As System.EventArgs) Handles SchedulerStorage1.AppointmentCollectionLoaded

        End Sub

        Private Sub SchedulerStorage1_AppointmentInserting(sender As Object, e As DevExpress.XtraScheduler.PersistentObjectCancelEventArgs) Handles SchedulerStorage1.AppointmentInserting

        End Sub

        Private Sub SchedulerStorage1_AppointmentsChanged(sender As Object, e As DevExpress.XtraScheduler.PersistentObjectsEventArgs) Handles SchedulerStorage1.AppointmentsChanged

        End Sub

        Private Sub SchedulerStorage1_AppointmentsDeleted(sender As Object, e As DevExpress.XtraScheduler.PersistentObjectsEventArgs) Handles SchedulerStorage1.AppointmentsDeleted

        End Sub

        Private Sub SchedulerStorage1_AppointmentsInserted(sender As Object, e As DevExpress.XtraScheduler.PersistentObjectsEventArgs) Handles SchedulerStorage1.AppointmentsInserted

        End Sub
    End Class
End Namespace