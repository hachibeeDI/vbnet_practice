
'
' Written by : OGURA_Daiki
'    Date    : 2012-10-23
'   Remarks  :
'
Option Strict On
Option Infer On
Option Explicit On


Namespace ExceptionLogic

    ''' <summary>
    ''' SQLServerのものなので多分Oracleとかには使えないけどとりあえずそのまま
    ''' </summary>
    ''' <remarks>System側でわかっていればいいようなコードはわざわざ登録しなくてもいい気がしてきた</remarks>
    Public Enum ERROR_CODE
        主キーの重複 = 2627

    End Enum
End Namespace
