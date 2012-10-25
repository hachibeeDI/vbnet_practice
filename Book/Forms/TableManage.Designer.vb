Namespace Forms

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class TableManage
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
            Me.txt_id = New System.Windows.Forms.TextBox()
            Me.txt_seats = New System.Windows.Forms.TextBox()
            Me.btn_add_table = New System.Windows.Forms.Button()
            Me.ListBox1 = New System.Windows.Forms.ListBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            '
            'txt_id
            '
            Me.txt_id.Location = New System.Drawing.Point(104, 82)
            Me.txt_id.Name = "txt_id"
            Me.txt_id.Size = New System.Drawing.Size(100, 19)
            Me.txt_id.TabIndex = 0
            '
            'txt_seats
            '
            Me.txt_seats.Location = New System.Drawing.Point(104, 120)
            Me.txt_seats.Name = "txt_seats"
            Me.txt_seats.Size = New System.Drawing.Size(100, 19)
            Me.txt_seats.TabIndex = 1
            '
            'btn_add_table
            '
            Me.btn_add_table.Location = New System.Drawing.Point(129, 154)
            Me.btn_add_table.Name = "btn_add_table"
            Me.btn_add_table.Size = New System.Drawing.Size(75, 23)
            Me.btn_add_table.TabIndex = 2
            Me.btn_add_table.Text = "追加"
            Me.btn_add_table.UseVisualStyleBackColor = True
            '
            'ListBox1
            '
            Me.ListBox1.FormattingEnabled = True
            Me.ListBox1.ItemHeight = 12
            Me.ListBox1.Location = New System.Drawing.Point(462, 40)
            Me.ListBox1.Name = "ListBox1"
            Me.ListBox1.Size = New System.Drawing.Size(370, 280)
            Me.ListBox1.TabIndex = 3
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(33, 85)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(41, 12)
            Me.Label1.TabIndex = 4
            Me.Label1.Text = "席番号"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(22, 123)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(61, 12)
            Me.Label2.TabIndex = 5
            Me.Label2.Text = "座れる人数"
            '
            'TableManage
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(940, 602)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.ListBox1)
            Me.Controls.Add(Me.btn_add_table)
            Me.Controls.Add(Me.txt_seats)
            Me.Controls.Add(Me.txt_id)
            Me.Name = "TableManage"
            Me.Text = "TableManage"
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents txt_id As System.Windows.Forms.TextBox
        Friend WithEvents txt_seats As System.Windows.Forms.TextBox
        Friend WithEvents btn_add_table As System.Windows.Forms.Button
        Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
    End Class
End Namespace
