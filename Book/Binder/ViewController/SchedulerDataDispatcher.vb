'
' Written by : OGURA_Daiki
'    Date    : 2012-10-29
'   Remarks  :
'
Option Strict On
Option Infer On
Option Explicit On

Imports DevExpress

Imports MyADOHelper.ExceptionLogic

Imports Book.Utils.Extension.TextBoxValueExtension

Namespace Binder.ViewController
    Public Class SchedulerDataDispatcher

#Region "フィールド"
        Private _binder As New Binder.BookingManager
        Private ReadOnly Property binder As Binder.BookingManager
            Get
                Return _binder
            End Get
        End Property

        Private _apointment_datasource As BindingSource
        Private ReadOnly Property apointment_datasouce As BindingSource
            Get
                Return _apointment_datasource
            End Get
        End Property


        Private WithEvents _scheduler As DevExpress.XtraScheduler.SchedulerControl
        ''' <summary> ターゲットとなる画面上のスケジューラーコントロール </summary>
        Private ReadOnly Property scheduler As XtraScheduler.SchedulerControl
            Get
                Return _scheduler
            End Get
        End Property

        Private WithEvents _scheduler_storage As DevExpress.XtraScheduler.SchedulerStorage
        ''' <summary> スケジューラーコントロールのストレージ </summary>
        Private ReadOnly Property scheduler_storage As XtraScheduler.SchedulerStorage
            Get
                Return _scheduler_storage
            End Get
        End Property
#End Region

        ''' <summary>  </summary>
        ''' <remarks>strageがNullの状態で呼ぶとぬる落ちするので、Loadイベントなどのタイミングで呼ぶように</remarks>
        Public Sub New(scheduler_control As XtraScheduler.SchedulerControl, form_apointment_datasource As BindingSource)
            _scheduler = scheduler_control
            _scheduler_storage = _scheduler.Storage
            _apointment_datasource = form_apointment_datasource
        End Sub


#Region "Schedulerのイベント"

        ''' <summary> 予約のバーを引っ張って伸ばした時のイベント </summary>
        ''' <remarks> パフォーマンスが問題になる場合、DBアクセスの部分を非同期化するとか </remarks>
        Private Sub _
        _scheduler_AppointmentResized(sender As Object, e As DevExpress.XtraScheduler.AppointmentResizeEventArgs) _
        Handles _scheduler.AppointmentResized

            'この質問は必要？
            If vbYes =
                System.Windows.Forms.MessageBox.Show(
                    "予約日付を更新しますかああああああああ", "", MessageBoxButtons.YesNo) Then
                Dim storage = e.EditedAppointment
                Dim state As ErrorState.IErrorState
                With storage
                    state = binder.alterBooking(CType(.Description, UInteger),
                                        CInt(.ResourceId),
                                        .Start,
                                        .End,
                                        CInt(.Subject),
                                        .Location)
                End With

                System.Windows.Forms.MessageBox.Show(state.getMessage())
            End If
        End Sub
#End Region

#Region "SchedulerStorageのイベント"

        Private Sub _
        _scheduler_storage_AppointmentInserting(sender As Object,
                                            e As DevExpress.XtraScheduler.PersistentObjectCancelEventArgs) _
        Handles _scheduler_storage.AppointmentInserting

            'そもそも、PersistentObjectsEventArgsに紐付いているBookingオブジェクトの参照を見つけることができれば
            '以下のような代入しょりはいらなくなる。でも見つからない
            Dim apoint = DirectCast(e.Object, DevExpress.XtraScheduler.Appointment)

            Dim table_id = CType(apoint.ResourceId, UInt32)
            Dim start_date = apoint.Start
            Dim close_date = apoint.End
            '席の人数と予約者の名前は無理やりMappingしているので、不都合があれば画面側で設定とかする
            'もっと時間かけてハックすればスマートな解決策はありそう。例えばStatusCollectionを拡張して人数をいれさせるとか
            Dim num_seats = CInt(apoint.Subject)
            Dim name_haveResevation = apoint.Location


            Dim message = binder.reserveBooking(table_id, start_date, close_date, num_seats, name_haveResevation)
            System.Windows.Forms.MessageBox.Show(message.getMessage())

            'この後なぜかFormatExceptionが起きる。
            '理由は現時点では完全に不明。
            '以下のようにして↓
            '            e.Cancel = True
            '下のAppointmentsInsertedで再読み込み
            '            apointment_datasouce.DataSource = binder.getAllBookings().ToList
            'をするとかで回避できそうではある
        End Sub

        ''' <summary> なんらかの処理(ダブルクリックでポップアップするEditorとか)によって要素が挿入された時 </summary>
        ''' <remarks></remarks>
        Private Sub _
        _scheduler_storage_AppointmentsInserted(sender As Object,
                                            e As DevExpress.XtraScheduler.PersistentObjectsEventArgs) _
        Handles _scheduler_storage.AppointmentsInserted

        End Sub

#End Region

    End Class
End Namespace
