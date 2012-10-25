'
' Written by : OGURA_Daiki
'    Date    : 2012-10-23
'   Remarks  :
'
Option Strict On
Option Infer On
Option Explicit On



Imports MyADOHelper
Imports Book.Utils.Message

Namespace Binder

    ''' <summary>
    ''' Controllerへのプロキシ、あるいはデコレータ？ バリデートや例外のキャッチを行う
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TableManager
        Inherits TableController

        Public Overrides Function addTable(table_id As Integer, maximum_seat As Integer) As Integer
            Dim tables = MyBase.getAllTables()
            If tables.Where(Function(t) t.id = table_id).Any Then
                '主キーの重複
                CustomMessage.showInfo(SITUATIONS.無効な入力値.ToMessageText, "Info")
                Return 0 : End If

            Try
                Return MyBase.addTable(table_id, maximum_seat)
            Catch e As SqlClient.SqlException
                writeLog("ERROR", e.Message)
                '例えば、エラーコードによってはそのまま処理したい？　その場合はまた別の拡張を考える。
                'EnumのROR_CODEはPublicとなっている
                Dim m = New ExceptionLogic.Message(e.Number)
                CustomMessage.showError(m.getMessageByNumber, "エラー")
                Return 0
            End Try
        End Function

    End Class
End Namespace