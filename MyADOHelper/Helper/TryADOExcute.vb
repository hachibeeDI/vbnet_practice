'
' Written by : OGURA_Daiki
'    Date    : 2012-10-30
'   Remarks  :
'
Option Strict On
Option Infer On
Option Explicit On


Namespace Helper

    ''' <summary> 例外集約用クラス </summary>
    ''' <remarks></remarks>
    Public Class TryADOExcute

        ''' <summary> SQLException時のログ取り処理などを集約する </summary>
        ''' <param name="f"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function catchSQLState(f As Func(Of Integer)) As ExceptionLogic.ErrorState.IErrorState
            Try

                ' ADOの実行って、selectの時も実行した数を返したっけ？
                Dim adoresult = f()
                If adoresult >= 1 Then
                    Return New ExceptionLogic.ErrorState.NoError
                Else
                    Return New ExceptionLogic.ErrorState.QueryHasNoEffect
                End If


            Catch e As SqlClient.SqlException
                writeLog("ERROR", e.Message & Environment.NewLine & e.StackTrace)

                Return ExceptionLogic.Message.getState(e.Number)
            Catch e As SqlTypes.SqlTypeException
                writeLog("ERROR", e.Message)
                Return New ExceptionLogic.ErrorState.UnknownError
            End Try
        End Function



    End Class
End Namespace