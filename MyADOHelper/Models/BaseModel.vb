
'
' Written by : OGURA_Daiki
'    Date    : 2012-10-23
'   Remarks  :
'
Option Strict On
Option Infer On
Option Explicit On

Namespace Models

    Public MustInherit Class BaseModelEntity
        Public MustOverride Function checkFieldDefinitions() As Boolean

    End Class
End Namespace
