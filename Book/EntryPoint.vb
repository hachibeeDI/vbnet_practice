

Public Class EntryPoint

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim booking As New Forms.BookingForm
        booking.Show()
    End Sub

    Private Sub btn_manage_tables_Click(sender As System.Object, e As System.EventArgs) Handles btn_manage_tables.Click
        Dim table_manager As New Forms.TableManage
        table_manager.Show()
    End Sub
End Class