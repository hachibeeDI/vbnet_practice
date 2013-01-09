
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
    Public Class Tables
        Inherits BaseModelEntity

#Region "フィールド"
        'プロパティの使い方、もう少しスマートになりそうな気もするが。
        'オブジェクト初期化子を使う関係とオーバーロードの制限上このあたりが限界？

        Private Property id_field As New NumericColumn(3)
        Private Property maximum_seats_field As New NumericColumn(2)

        ''' <summary>  </summary>
        ''' <remarks>この部分は、画面表示の辻褄合わせなので派生クラスに実装する形にしたほうが良いのでは</remarks>
        Public Property caption As String
            Set(value As String)
                'pass
            End Set
            Get
                Return String.Format("No:{0} Max:{1}", id_field.Value, maximum_seats_field.Value)
            End Get
        End Property

        Public Property id As Integer
            Set(value As Integer)
                id_field.Value = value
            End Set
            Get
                Return id_field.Value
            End Get
        End Property

        Public Property maximum_seats As Integer
            Set(value As Integer)
                maximum_seats_field.Value = value
            End Set
            Get
                Return maximum_seats_field.Value
            End Get
        End Property

#End Region

#Region "抽象メソッドのオーバーライド"
        Public Overrides Function checkFieldDefinitions() As Boolean
            Dim fields = {id_field, maximum_seats_field}
            Return fields.All(Function(f) f.checkDefinition)

        End Function

#End Region
    End Class
End Namespace
