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
    Module DataRowExtension

        <Extension()> _
        Public Function getValue_Type(Of TPrim)(this As IDataRecord, columnname As String) As TPrim
            Return CType(this(columnname), TPrim)
        End Function

    End Module
End Namespace