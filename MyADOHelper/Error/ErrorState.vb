
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


    Public Class NoError
        Implements IErrorState

        Public Function getMessage() As String Implements IErrorState.getMessage
            Return "処理が正常に終了しました。"
        End Function
    End Class


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


    Public Class QueryHasNoEffect
        Implements IErrorState

        Public Function getMessage() As String Implements IErrorState.getMessage
            Return "クエリの実行結果が0件です。"
        End Function
    End Class


    ''' <summary>  </summary>
    ''' <remarks>Dataベースの定義ではなく、アプリケーションの都合上の定義</remarks>
    Public Class InvailedDateRelation
        Implements IErrorState

        Public Function getMessage() As String Implements IErrorState.getMessage
            Return "日付の整合性がとれていません"
        End Function
    End Class


    ''' <summary>  </summary>
    Public Class NoTableId
        Implements IErrorState

        Public Function getMessage() As String Implements IErrorState.getMessage
            Return "存在しないテーブル番号を指定しています。"""
        End Function
    End Class



End Namespace