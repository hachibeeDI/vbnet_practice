Namespace Forms

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class BookingForm
        Inherits System.Windows.Forms.Form

        'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Windows フォーム デザイナーで必要です。
        Private components As System.ComponentModel.IContainer

        'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
        'Windows フォーム デザイナーを使用して変更できます。  
        'コード エディターを使って変更しないでください。
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim TimeRuler1 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
            Dim TimeScaleYear1 As DevExpress.XtraScheduler.TimeScaleYear = New DevExpress.XtraScheduler.TimeScaleYear()
            Dim TimeScaleMonth1 As DevExpress.XtraScheduler.TimeScaleMonth = New DevExpress.XtraScheduler.TimeScaleMonth()
            Dim TimeScaleWeek1 As DevExpress.XtraScheduler.TimeScaleWeek = New DevExpress.XtraScheduler.TimeScaleWeek()
            Dim TimeScaleDay1 As DevExpress.XtraScheduler.TimeScaleDay = New DevExpress.XtraScheduler.TimeScaleDay()
            Dim TimeScaleFixedInterval1 As DevExpress.XtraScheduler.TimeScaleFixedInterval = New DevExpress.XtraScheduler.TimeScaleFixedInterval()
            Dim TimeRuler2 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
            Me.ListBox1 = New System.Windows.Forms.ListBox()
            Me.btn_load = New System.Windows.Forms.Button()
            Me.btn_reserve = New System.Windows.Forms.Button()
            Me.txt_table_id = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txt_start = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txt_close = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txt_name = New System.Windows.Forms.TextBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.txt_seats = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.txt_date = New System.Windows.Forms.TextBox()
            Me.SchedulerControl1 = New DevExpress.XtraScheduler.SchedulerControl()
            Me.SchedulerStorage1 = New DevExpress.XtraScheduler.SchedulerStorage(Me.components)
            Me.BookingsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.TablesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.SchedulerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SchedulerStorage1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BookingsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TablesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ListBox1
            '
            Me.ListBox1.FormattingEnabled = True
            Me.ListBox1.ItemHeight = 12
            Me.ListBox1.Location = New System.Drawing.Point(24, 424)
            Me.ListBox1.Name = "ListBox1"
            Me.ListBox1.Size = New System.Drawing.Size(213, 124)
            Me.ListBox1.TabIndex = 0
            '
            'btn_load
            '
            Me.btn_load.Location = New System.Drawing.Point(24, 395)
            Me.btn_load.Name = "btn_load"
            Me.btn_load.Size = New System.Drawing.Size(75, 23)
            Me.btn_load.TabIndex = 1
            Me.btn_load.Text = "読み込み"
            Me.btn_load.UseVisualStyleBackColor = True
            '
            'btn_reserve
            '
            Me.btn_reserve.Location = New System.Drawing.Point(428, 625)
            Me.btn_reserve.Name = "btn_reserve"
            Me.btn_reserve.Size = New System.Drawing.Size(75, 23)
            Me.btn_reserve.TabIndex = 2
            Me.btn_reserve.Text = "追加"
            Me.btn_reserve.UseVisualStyleBackColor = True
            '
            'txt_table_id
            '
            Me.txt_table_id.Location = New System.Drawing.Point(66, 577)
            Me.txt_table_id.Name = "txt_table_id"
            Me.txt_table_id.Size = New System.Drawing.Size(100, 19)
            Me.txt_table_id.TabIndex = 3
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(22, 580)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(14, 12)
            Me.Label1.TabIndex = 4
            Me.Label1.Text = "id"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(217, 580)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(29, 12)
            Me.Label2.TabIndex = 6
            Me.Label2.Text = "start"
            '
            'txt_start
            '
            Me.txt_start.Location = New System.Drawing.Point(261, 577)
            Me.txt_start.Name = "txt_start"
            Me.txt_start.Size = New System.Drawing.Size(100, 19)
            Me.txt_start.TabIndex = 5
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(407, 580)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(32, 12)
            Me.Label3.TabIndex = 8
            Me.Label3.Text = "close"
            '
            'txt_close
            '
            Me.txt_close.Location = New System.Drawing.Point(451, 577)
            Me.txt_close.Name = "txt_close"
            Me.txt_close.Size = New System.Drawing.Size(100, 19)
            Me.txt_close.TabIndex = 7
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(22, 628)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(32, 12)
            Me.Label4.TabIndex = 10
            Me.Label4.Text = "name"
            '
            'txt_name
            '
            Me.txt_name.Location = New System.Drawing.Point(66, 625)
            Me.txt_name.Name = "txt_name"
            Me.txt_name.Size = New System.Drawing.Size(100, 19)
            Me.txt_name.TabIndex = 9
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(188, 628)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(33, 12)
            Me.Label5.TabIndex = 12
            Me.Label5.Text = "seats"
            '
            'txt_seats
            '
            Me.txt_seats.Location = New System.Drawing.Point(232, 625)
            Me.txt_seats.Name = "txt_seats"
            Me.txt_seats.Size = New System.Drawing.Size(100, 19)
            Me.txt_seats.TabIndex = 11
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(22, 669)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(27, 12)
            Me.Label6.TabIndex = 14
            Me.Label6.Text = "date"
            '
            'txt_date
            '
            Me.txt_date.Location = New System.Drawing.Point(66, 666)
            Me.txt_date.Name = "txt_date"
            Me.txt_date.Size = New System.Drawing.Size(100, 19)
            Me.txt_date.TabIndex = 13
            '
            'SchedulerControl1
            '
            Me.SchedulerControl1.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Timeline
            Me.SchedulerControl1.GroupType = DevExpress.XtraScheduler.SchedulerGroupType.Resource
            Me.SchedulerControl1.Location = New System.Drawing.Point(285, 54)
            Me.SchedulerControl1.Name = "SchedulerControl1"
            Me.SchedulerControl1.OptionsCustomization.AllowAppointmentConflicts = DevExpress.XtraScheduler.AppointmentConflictsMode.Forbidden
            Me.SchedulerControl1.Size = New System.Drawing.Size(675, 494)
            Me.SchedulerControl1.Start = New Date(2012, 10, 21, 0, 0, 0, 0)
            Me.SchedulerControl1.Storage = Me.SchedulerStorage1
            Me.SchedulerControl1.TabIndex = 15
            Me.SchedulerControl1.Text = "SchedulerControl1"
            Me.SchedulerControl1.Views.DayView.TimeRulers.Add(TimeRuler1)
            Me.SchedulerControl1.Views.TimelineView.AppointmentDisplayOptions.StatusDisplayType = DevExpress.XtraScheduler.AppointmentStatusDisplayType.Time
            Me.SchedulerControl1.Views.TimelineView.NavigationButtonAppointmentSearchInterval = System.TimeSpan.Parse("00:30:00")
            TimeScaleYear1.Enabled = False
            TimeScaleMonth1.Enabled = False
            TimeScaleFixedInterval1.Value = System.TimeSpan.Parse("00:30:00")
            Me.SchedulerControl1.Views.TimelineView.Scales.Add(TimeScaleYear1)
            Me.SchedulerControl1.Views.TimelineView.Scales.Add(TimeScaleMonth1)
            Me.SchedulerControl1.Views.TimelineView.Scales.Add(TimeScaleWeek1)
            Me.SchedulerControl1.Views.TimelineView.Scales.Add(TimeScaleDay1)
            Me.SchedulerControl1.Views.TimelineView.Scales.Add(TimeScaleFixedInterval1)
            Me.SchedulerControl1.Views.TimelineView.WorkTime.End = System.TimeSpan.Parse("22:00:00")
            Me.SchedulerControl1.Views.TimelineView.WorkTime.Start = System.TimeSpan.Parse("10:00:00")
            Me.SchedulerControl1.Views.WorkWeekView.TimeRulers.Add(TimeRuler2)
            '
            'SchedulerStorage1
            '
            Me.SchedulerStorage1.Appointments.DataSource = Me.BookingsBindingSource
            Me.SchedulerStorage1.Appointments.Mappings.Description = "num_persons"
            Me.SchedulerStorage1.Appointments.Mappings.ResourceId = "tables_id"
            Me.SchedulerStorage1.Appointments.Mappings.Start = "starting_time"
            Me.SchedulerStorage1.Appointments.Mappings.Status = "closing_time"
            Me.SchedulerStorage1.Appointments.Mappings.Subject = "num_persons"
            Me.SchedulerStorage1.Resources.DataSource = Me.TablesBindingSource
            Me.SchedulerStorage1.Resources.Mappings.Caption = "id"
            Me.SchedulerStorage1.Resources.Mappings.Id = "id"
            '
            'BookingsBindingSource
            '
            Me.BookingsBindingSource.DataSource = GetType(Book.Models.Bookings)
            '
            'TablesBindingSource
            '
            Me.TablesBindingSource.DataSource = GetType(Book.Models.Tables)
            '
            'BookingForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(988, 699)
            Me.Controls.Add(Me.SchedulerControl1)
            Me.Controls.Add(Me.Label6)
            Me.Controls.Add(Me.txt_date)
            Me.Controls.Add(Me.Label5)
            Me.Controls.Add(Me.txt_seats)
            Me.Controls.Add(Me.Label4)
            Me.Controls.Add(Me.txt_name)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.txt_close)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.txt_start)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.txt_table_id)
            Me.Controls.Add(Me.btn_reserve)
            Me.Controls.Add(Me.btn_load)
            Me.Controls.Add(Me.ListBox1)
            Me.Name = "BookingForm"
            Me.Text = "book"
            CType(Me.SchedulerControl1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SchedulerStorage1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BookingsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TablesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
        Friend WithEvents btn_load As System.Windows.Forms.Button
        Friend WithEvents btn_reserve As System.Windows.Forms.Button
        Friend WithEvents txt_table_id As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txt_start As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txt_close As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents txt_name As System.Windows.Forms.TextBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents txt_seats As System.Windows.Forms.TextBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents txt_date As System.Windows.Forms.TextBox
        Friend WithEvents SchedulerControl1 As DevExpress.XtraScheduler.SchedulerControl
        Friend WithEvents SchedulerStorage1 As DevExpress.XtraScheduler.SchedulerStorage
        Friend WithEvents TablesBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents BookingsBindingSource As System.Windows.Forms.BindingSource
    End Class
End Namespace
