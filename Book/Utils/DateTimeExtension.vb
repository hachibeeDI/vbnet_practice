'
' Written by : OGURA_Daiki
'    Date    : 2012-10-23
'   Remarks  :
'
Option Strict On
Option Infer On
Option Explicit On

Imports System.Runtime.CompilerServices

Namespace Utils.Extension

    Module DateTimeExtension

        ''' <summary> Compareメソッドがわかりにくすぎるのでラッパ </summary>
        ''' <remarks>less thenであってるかどうか……</remarks>
        <Extension()> _
        Public Function isLessThen(this As DateTime, target As DateTime) As Boolean
            ' Compare(x, y)としたとき
            ' (x < y) の時は-1が返る
            ' (x > y) の時は1が返る
            ' (x = y) の時は0が返る
            Dim result = DateTime.Compare(this, target)
            Return If(result = -1, True, False)
        End Function

    End Module
End Namespace