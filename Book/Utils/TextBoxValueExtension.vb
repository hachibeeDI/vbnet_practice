'
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

    Module TextBoxValueExtension

        <Extension()> _
        Public Function getValueAsInt(this As TextBox) As Integer
            Return CType(this.Text, Integer)
        End Function

        <Extension()> _
        Public Function getValueAsDate(this As TextBox) As Date
            Return CType(this.Text, Date)
        End Function

    End Module
End Namespace
