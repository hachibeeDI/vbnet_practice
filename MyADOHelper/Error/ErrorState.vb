
'
' Written by : OGURA_Daiki
'    Date    : 2012-10-23
'   Remarks  :
'
Option Strict On
Option Infer On
Option Explicit On

Namespace ExceptionLogic.ErrorState
    Public Interface IErrorState
        Function getMessage() As String
    End Interface

    Public Class UnknownError
        Implements IErrorState

        Public Function getMessage() As String Implements IErrorState.getMessage
            'とりあえず出力する用
            Return "原因不明のエラーが発生しました。管理者に問い合わせてください。"
        End Function
    End Class

    Public Class PrimarykeyOverlap
        Implements IErrorState

        Public Function getMessage() As String Implements IErrorState.getMessage
            Return "主キーには重複した値を登録できません。"
        End Function
    End Class

End Namespace