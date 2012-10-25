
'
' Written by : OGURA_Daiki
'    Date    : 2012-10-23
'   Remarks  :
'
Option Strict On
Option Infer On
Option Explicit On


Imports Codeplex.Data

Namespace Binder
    Public MustInherit Class BaseController
        ' テスト用
        Private Const CONNECTION_STRING = "Data Source=.\TEST;Initial Catalog=Booking;Integrated Security=SSPI;"
        Protected ReadOnly Property getConnection As SqlClient.SqlConnection
            Get
                Return New SqlClient.SqlConnection(CONNECTION_STRING)
            End Get
        End Property

    End Class
End Namespace