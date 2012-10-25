
'
' Written by : OGURA_Daiki
'    Date    : 2012-10-23
'   Remarks  :
'
Option Strict On
Option Infer On
Option Explicit On


Namespace Utils.Message

    Module CustomMessage
        Public Sub showError(message As String, title As String)
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Sub

        Public Sub showInfo(message As String, title As String)
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub
    End Module
End Namespace


