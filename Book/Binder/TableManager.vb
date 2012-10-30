'
' Written by : OGURA_Daiki
'    Date    : 2012-10-23
'   Remarks  :
'
Option Strict On
Option Infer On
Option Explicit On

Imports MyADOHelper.ExceptionLogic
Imports MyADOHelper.ExceptionLogic.ErrorState
Imports MyADOHelper.Helper

Imports Book.Utils.Message

Namespace Binder

    ''' <summary>
    ''' Controllerへのプロキシ、あるいはデコレータ？ バリデートや例外のキャッチを行う
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TableManager
        Inherits TableController

        Public Shadows Function addTable(table_id As Integer, maximum_seat As Integer) As IErrorState
            Dim tables = MyBase.getAllTables()
            If tables.Where(Function(t) t.id = table_id).Any Then
                Return New ErrorState.PrimarykeyOverlap : End If

            Dim insert = Functional.pertial(AddressOf MyBase.addTable,
                                            table_id, maximum_seat)

            Return TryADOExcute.catchSQLState(insert)

        End Function

    End Class
End Namespace