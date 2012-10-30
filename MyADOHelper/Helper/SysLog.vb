
'
' Written by : OGURA_Daiki
'    Date    : 2012-10-23
'   Remarks  :
'
Option Strict On
Option Infer On
Option Explicit On

Module SysLog
    ''' <summary>
    ''' ログファイルへの書き込みを行う
    ''' </summary>
    ''' <param name="prefix"></param>
    ''' <param name="message"></param>
    ''' <remarks></remarks>
    Public Sub writeLog(prefix As String, message As String)
        Dim content = String.Format("{0} : Log = {1}", prefix, message)
        'ログ出力の処理はここに集約

    End Sub
End Module
