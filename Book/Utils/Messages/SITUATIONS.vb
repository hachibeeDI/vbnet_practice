
'
' Written by : OGURA_Daiki
'    Date    : 2012-10-23
'   Remarks  :
'
Option Strict On
Option Infer On
Option Explicit On

Imports System.Runtime.CompilerServices

Namespace Utils.Message

    ''' <summary> エラーの状況を表す。ToMessageText拡張メソッドを使ってメッセージを取り出すこともできる </summary>
    ''' <remarks></remarks>
    Public Enum SITUATIONS
        型の違反
        無効な入力値
        存在しないid
    End Enum


    Module SituasionToString
        Private situations_ As New Dictionary(Of SITUATIONS, String) From
            {
                {SITUATIONS.型の違反, "入力値の型が不正です。{0}を入力してください。"},
                {SITUATIONS.無効な入力値, "入力値が無効です。"},
                {SITUATIONS.存在しないid, "指定されたテーブルは存在しません。"}
            }


        <Extension()> _
        Public Function ToMessageText(this As SITUATIONS) As String
            Return situations_(this)
        End Function
    End Module

End Namespace
