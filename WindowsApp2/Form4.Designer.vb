<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem文件 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem退出X = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem帮助 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem退出 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BeginDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.EndDate = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.TextBox机长姓名 = New System.Windows.Forms.TextBox()
        Me.Label0 = New System.Windows.Forms.Label()
        Me.TextBox编号 = New System.Windows.Forms.TextBox()
        Me.Button保存 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.Info
        Me.MenuStrip1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem文件, Me.ToolStripMenuItem帮助, Me.ToolStripMenuItem退出})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1439, 24)
        Me.MenuStrip1.TabIndex = 35
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem文件
        '
        Me.ToolStripMenuItem文件.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem退出X})
        Me.ToolStripMenuItem文件.Name = "ToolStripMenuItem文件"
        Me.ToolStripMenuItem文件.Size = New System.Drawing.Size(76, 20)
        Me.ToolStripMenuItem文件.Text = "文件(&F)"
        '
        'ToolStripMenuItem退出X
        '
        Me.ToolStripMenuItem退出X.Name = "ToolStripMenuItem退出X"
        Me.ToolStripMenuItem退出X.Size = New System.Drawing.Size(132, 22)
        Me.ToolStripMenuItem退出X.Text = "退出(&X)"
        '
        'ToolStripMenuItem帮助
        '
        Me.ToolStripMenuItem帮助.Name = "ToolStripMenuItem帮助"
        Me.ToolStripMenuItem帮助.Size = New System.Drawing.Size(76, 20)
        Me.ToolStripMenuItem帮助.Text = "帮助(&H)"
        '
        'ToolStripMenuItem退出
        '
        Me.ToolStripMenuItem退出.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripMenuItem退出.Name = "ToolStripMenuItem退出"
        Me.ToolStripMenuItem退出.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToolStripMenuItem退出.Size = New System.Drawing.Size(92, 20)
        Me.ToolStripMenuItem退出.Text = " 退 出(&X)"
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.Ivory
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(120, 264)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(371, 336)
        Me.DataGridView1.TabIndex = 36
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 244)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 37
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Yellow
        Me.Panel3.Controls.Add(Me.BeginDate)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.EndDate)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 24)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1439, 42)
        Me.Panel3.TabIndex = 239
        '
        'BeginDate
        '
        Me.BeginDate.CalendarFont = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.BeginDate.CustomFormat = "yyyyMd"
        Me.BeginDate.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.BeginDate.Location = New System.Drawing.Point(176, 7)
        Me.BeginDate.Name = "BeginDate"
        Me.BeginDate.Size = New System.Drawing.Size(143, 26)
        Me.BeginDate.TabIndex = 230
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(82, 12)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 229
        Me.Label1.Text = "开始日期 >="
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Location = New System.Drawing.Point(329, 12)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 16)
        Me.Label3.TabIndex = 228
        Me.Label3.Text = "结束日期 <="
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'EndDate
        '
        Me.EndDate.CalendarFont = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.EndDate.CustomFormat = "yyyyMd"
        Me.EndDate.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.EndDate.Location = New System.Drawing.Point(428, 7)
        Me.EndDate.Name = "EndDate"
        Me.EndDate.Size = New System.Drawing.Size(150, 26)
        Me.EndDate.TabIndex = 231
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(601, 114)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(176, 16)
        Me.Label9.TabIndex = 245
        Me.Label9.Text = "(只显示用，不用输入 )"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkTurquoise
        Me.Label2.Location = New System.Drawing.Point(418, 150)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 24)
        Me.Label2.TabIndex = 242
        Me.Label2.Text = "机长姓名"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label2.UseCompatibleTextRendering = True
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Red
        Me.Label33.Location = New System.Drawing.Point(636, 152)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(10, 19)
        Me.Label33.TabIndex = 244
        Me.Label33.Text = "*"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox机长姓名
        '
        Me.TextBox机长姓名.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TextBox机长姓名.ImeMode = System.Windows.Forms.ImeMode.Hangul
        Me.TextBox机长姓名.Location = New System.Drawing.Point(500, 148)
        Me.TextBox机长姓名.Name = "TextBox机长姓名"
        Me.TextBox机长姓名.Size = New System.Drawing.Size(130, 26)
        Me.TextBox机长姓名.TabIndex = 241
        '
        'Label0
        '
        Me.Label0.AutoSize = True
        Me.Label0.BackColor = System.Drawing.Color.Transparent
        Me.Label0.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label0.Location = New System.Drawing.Point(449, 111)
        Me.Label0.Name = "Label0"
        Me.Label0.Size = New System.Drawing.Size(42, 16)
        Me.Label0.TabIndex = 243
        Me.Label0.Text = "编号"
        Me.Label0.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox编号
        '
        Me.TextBox编号.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TextBox编号.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox编号.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TextBox编号.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TextBox编号.Location = New System.Drawing.Point(500, 107)
        Me.TextBox编号.Name = "TextBox编号"
        Me.TextBox编号.Size = New System.Drawing.Size(95, 26)
        Me.TextBox编号.TabIndex = 240
        '
        'Button保存
        '
        Me.Button保存.AutoSize = True
        Me.Button保存.BackColor = System.Drawing.Color.Coral
        Me.Button保存.Location = New System.Drawing.Point(681, 143)
        Me.Button保存.Name = "Button保存"
        Me.Button保存.Size = New System.Drawing.Size(75, 39)
        Me.Button保存.TabIndex = 246
        Me.Button保存.Text = "保存"
        Me.Button保存.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(565, 206)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 247
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1439, 600)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button保存)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.TextBox机长姓名)
        Me.Controls.Add(Me.Label0)
        Me.Controls.Add(Me.TextBox编号)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form4"
        Me.Text = "Form4"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolStripMenuItem文件 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem退出X As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem帮助 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem退出 As ToolStripMenuItem
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents BeginDate As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents EndDate As DateTimePicker
    Friend WithEvents Label9 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents TextBox机长姓名 As TextBox
    Friend WithEvents Label0 As Label
    Friend WithEvents TextBox编号 As TextBox
    Friend WithEvents Button保存 As Button
    Friend WithEvents Button2 As Button
End Class
