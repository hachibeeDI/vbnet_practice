
'
' Written by : OGURA_Daiki
'    Date    : 2012-10-23
'   Remarks  :
'
Option Strict On
Option Infer On
Option Explicit On

Namespace Models
    Public Interface ICheckableColumn
        Function checkDefinition() As Boolean
    End Interface

    Public MustInherit Class BaseColumn(Of T)
        Implements ICheckableColumn

        Public Property Value As T

        Private ReadOnly _length As Integer
        ''' <summary> 桁数。0は未定義とみなす </summary>
        Public ReadOnly Property Length As Integer
            Get
                Return _length
            End Get
        End Property

        Friend Sub New(Optional len As Integer = 0)
            _length = len
        End Sub

        Public MustOverride Function checkDefinition() As Boolean Implements ICheckableColumn.checkDefinition

        ''' <summary> TODO: 記述がシンプルになることを期待。混乱を招く用なら削除する </summary>
        ''' <param name="val"></param>
        ''' <returns></returns>
        Public Shared Widening Operator CType(val As BaseColumn(Of T)) As T
            Return val.Value
        End Operator

    End Class
End Namespace