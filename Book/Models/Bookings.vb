'
' Written by : OGURA_Daiki
'    Date    : 2012-10-23
'   Remarks  :
'
Option Strict On
Option Infer On
Option Explicit On

Imports MyADOHelper.Models

Namespace Models

    ''' <summary>  </summary>
    ''' <remarks>例えばバリデーションだけじゃなくて、ここのカラムの定義情報からフォームコントロールの制約も定義できたらいいかなという予定</remarks>
    Public Class Bookings
        Inherits BaseModel

#Region "フィールド"
        Private Property tables_id_field As New NumericColumn(3)
        'Private Property tables_maximum_seats_field As New NumericColumn(2)
        Private Property date_reserve_field As New DateColumn
        Private Property starting_time_field As New CharColumn(4)
        Private Property closing_time_field As New CharColumn(4)
        Private Property name_haveReservation_field As New VarCharColumn(50)
        Private Property num_persons_field As New NumericColumn(2)

        Public Property tables_id As Integer
            Set(value As Integer)
                tables_id_field.Value = value
            End Set
            Get
                Return tables_id_field
            End Get
        End Property

        'Public Property tables_maximum_seats As Integer
        '    Set(value As Integer)
        '        tables_maximum_seats_field.Value = value
        '    End Set
        '    Get
        '        Return tables_maximum_seats_field
        '    End Get
        'End Property

        Public Property date_reserve As Date
            Set(value As Date)
                date_reserve_field.Value = value
            End Set
            Get
                Return date_reserve_field
            End Get
        End Property

        Public Property starting_time As String
            Set(value As String)
                starting_time_field.Value = value
            End Set
            Get
                Return starting_time_field.Value
            End Get
        End Property

        Public Property closing_time As String
            Set(value As String)
                closing_time_field.Value = value
            End Set
            Get
                Return closing_time_field.Value
            End Get
        End Property

        Public Property name_haveReservation As String
            Set(value As String)
                name_haveReservation_field.Value = value
            End Set
            Get
                Return name_haveReservation_field.Value
            End Get
        End Property

        Public Property num_persons As Integer
            Set(value As Integer)
                num_persons_field.Value = value
            End Set
            Get
                Return num_persons_field
            End Get
        End Property

#End Region

#Region "抽象メソッドのオーバーライド"
        Public Overrides Function checkFieldDefinitions() As Boolean
            Dim f As IEnumerable(Of ICheckableColumn) =
                {tables_id_field,
                 date_reserve_field, starting_time_field,
                 closing_time_field, name_haveReservation_field, num_persons_field
                }
            'AllよりAnyのほうが処理軽いみたいだけど可読性落ちるのでAll使おう
            Return f.All(Function(c) c.checkDefinition)
        End Function
#End Region
    End Class
End Namespace