
'
' Written by : OGURA_Daiki
'    Date    : 2012-10-23
'   Remarks  :
'
Option Strict On
Option Infer On
Option Explicit On


Imports MyADOHelper.ExceptionLogic.ErrorState
Namespace ExceptionLogic

    ''' <summary>  </summary>
    ''' <remarks></remarks>
    Public Class Message
        Public Sub New(errorNumber As Integer)
            state_ = getStateByNumber(errorNumber)
        End Sub

        Private ReadOnly state_ As IErrorState

        Private Function getStateByNumber(errorNumber As Integer) As IErrorState
            Select Case errorNumber
                Case ERROR_CODE.主キーの重複
                    Return New PrimarykeyOverlap

                Case Else
                    Return New UnknownError

            End Select
        End Function

        ''' <summary>  </summary>
        ''' <returns></returns>
        ''' <remarks>TODO:ここでロギングもしておくとか？</remarks>
        Public Function getMessageByNumber() As String
            Return state_.getMessage
        End Function
    End Class
End Namespace
