
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
    ''' <param name="prefix">logをgrepするときのフィルターとして使ったり、意味で分けたりする</param>
    ''' <param name="message">メッセージ本体</param>
    ''' <remarks>ログの書式は統一すること</remarks>
    Public Sub writeLog(prefix As String, message As String)
        Dim content = String.Format("{0} : Log = {1}", prefix, message)
        'ログ出力の処理はここに集約
        'とりあえずは標準出力に流す
        Debug.WriteLine(content)
    End Sub

End Module
