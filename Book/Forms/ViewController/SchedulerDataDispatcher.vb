'
' Written by : OGURA_Daiki
'    Date    : 2012-10-29
'   Remarks  :
'
Option Strict On
Option Infer On
Option Explicit On

Imports DevExpress

Namespace Forms.ViewController
    Public Class SchedulerDataDispatcher

        Private WithEvents _scheduler As DevExpress.XtraScheduler.SchedulerControl
        Private ReadOnly Property scheduler As XtraScheduler.SchedulerControl
            Get
                Return _scheduler
            End Get
        End Property

        Private WithEvents _scheduler_storage As DevExpress.XtraScheduler.SchedulerStorage
        Private ReadOnly Property scheduler_storage As XtraScheduler.SchedulerStorage
            Get
                Return _scheduler_storage
            End Get
        End Property

        Public Sub New(scheduler_control As XtraScheduler.SchedulerControl)
            _scheduler = scheduler_control
            _scheduler_storage = _scheduler.Storage
        End Sub



    End Class
End Namespace
