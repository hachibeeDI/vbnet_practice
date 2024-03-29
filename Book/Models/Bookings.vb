﻿'
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
        Inherits BaseModelEntity

#Region "フィールド"
        Private Property id_field As New IntColumn()
        Private Property tables_id_field As New NumericColumn(3)
        Private Property starting_time_field As New DateTimeColumn
        Private Property closing_time_field As New DateTimeColumn
        Private Property name_haveReservation_field As New VarCharColumn(50)
        Private Property numberof_persons_field As New NumericColumn(2)

        Public Property id As Integer
            Set(value As Integer)
                id_field.Value = value
            End Set
            Get
                Return id_field
            End Get
        End Property

        Public Property tables_id As Integer
            Set(value As Integer)
                tables_id_field.Value = value
            End Set
            Get
                Return tables_id_field
            End Get
        End Property

        Public Property starting_time As DateTime
            Set(value As DateTime)
                starting_time_field.Value = value
            End Set
            Get
                Return starting_time_field.Value
            End Get
        End Property

        Public Property closing_time As DateTime
            Set(value As DateTime)
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

        Public Property numberof_persons As Integer
            Set(value As Integer)
                numberof_persons_field.Value = value
            End Set
            Get
                Return numberof_persons_field
            End Get
        End Property

#End Region

#Region "おーばーらいど"
        Public Overrides Function checkFieldDefinitions() As Boolean
            Dim f As IEnumerable(Of ICheckableColumn) =
                {
                    tables_id_field, starting_time_field,
                    closing_time_field, name_haveReservation_field, numberof_persons_field
                }
            'AllよりAnyのほうが処理軽いみたいだけど可読性落ちるのでAll使おう
            Return f.All(Function(c) c.checkDefinition)
        End Function
#End Region
    End Class
End Namespace
