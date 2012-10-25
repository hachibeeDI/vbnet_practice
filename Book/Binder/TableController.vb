
'
' Written by : OGURA_Daiki
'    Date    : 2012-10-23
'   Remarks  :
'
Option Strict On
Option Infer On
Option Explicit On


Imports Codeplex.Data

Imports Book.Utils.Extension

Namespace Binder

    ''' <summary>  </summary>
    ''' <remarks>エラー処理やバリデーションはこちらには書かない</remarks>
    Public Class TableController
        Inherits BaseController

        Private Property tables As Models.Tables

        Protected Sub New()
        End Sub

        Public Overridable Function addTable(table_id As Integer, maximum_seat As Integer) As Integer
            Return DbExecutor.Insert(MyBase.getConnection,
                              "Tables",
                              New Models.Tables With {
                                  .id = table_id,
                                  .maximum_seats = maximum_seat
                             })
        End Function

        Public Overridable Function getAllTables() As IEnumerable(Of Models.Tables)
            Dim ta = DbExecutor.ExecuteReader(MyBase.getConnection,
                             <s>SELECT id, maximum_seats FROM Tables </s>.Value
                             )
            Return ta.Select(Of Models.Tables)(Function(dr)
                                                   Return New Models.Tables() With {
                                                   .id = dr.getValue_Type(Of Integer)("id"),
                                                   .maximum_seats = dr.getValue_Type(Of Integer)("maximum_seats")
                                                       }
                                               End Function).ToArray()




            'Return DbExecutor.Select(Of Models.Tables) _
            '                (MyBase.getConnection,
            '                 <s>SELECT id, maximum_seats FROM Tables WHERE 1 = @dummy</s>.Value,
            '                 New With {.dummy = 1}
            '                 ).ToArray
        End Function

    End Class
End Namespace
