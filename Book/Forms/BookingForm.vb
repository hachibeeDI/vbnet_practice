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
            Dim a = binder.getAllBookings().Select(Function(r) r.name_haveReservation).ToList
            ListBox1.DataSource = a
        End Sub

        Private Sub btn_reserve_Click(sender As System.Object, e As System.EventArgs) Handles btn_reserve.Click

            binder.reserveBooking(txt_table_id.getValueAsInt,
                                  txt_date.getValueAsDate,
                                  txt_start.getValueAsInt,
                                  txt_close.getValueAsInt,
                                  txt_seats.getValueAsInt,
                                  txt_name.Text)

        End Sub

    End Class
End Namespace