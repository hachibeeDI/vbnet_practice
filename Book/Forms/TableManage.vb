Imports Book.Utils.Message

Namespace Forms

    Public Class TableManage

        Private binder As New Binder.TableManager


        Private Sub TableManage_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
            Dim tables = binder.getAllTables()
            ListBox1.DataSource = tables _
                                    .Select(
                                        Function(t) "id: " & t.id.ToString & "  座席数: " & t.maximum_seats.ToString).ToList()
        End Sub

        Private Sub btn_add_table_Click(sender As System.Object, e As System.EventArgs) Handles btn_add_table.Click
            Dim isInt = Function(txt As String) Integer.TryParse(txt, Nothing)
            If Not (isInt(txt_id.Text) AndAlso isInt(txt_seats.Text)) Then
                MessageBox.Show(String.Format(SITUATIONS.型の違反.ToMessageText, "数字"))
                Return
            End If


            binder.addTable(CType(txt_id.Text, Integer), CType(txt_seats.Text, Integer))
            Call TableManage_Load(Nothing, Nothing)
        End Sub

    End Class
End Namespace