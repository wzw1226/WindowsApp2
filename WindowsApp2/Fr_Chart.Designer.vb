<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_Chart
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BeginDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.EndDate = New System.Windows.Forms.DateTimePicker()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem文件 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem退出X = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem帮助 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem退出 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.ButtonChart = New System.Windows.Forms.Button()
        Me.Panel3.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.Panel3.Size = New System.Drawing.Size(1368, 42)
        Me.Panel3.TabIndex = 241
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
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.Info
        Me.MenuStrip1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem文件, Me.ToolStripMenuItem帮助, Me.ToolStripMenuItem退出})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1368, 24)
        Me.MenuStrip1.TabIndex = 240
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
        Me.DataGridView1.Location = New System.Drawing.Point(997, 85)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(371, 610)
        Me.DataGridView1.TabIndex = 242
        '
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(12, 85)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Series1.YValuesPerPoint = 6
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(869, 542)
        Me.Chart1.TabIndex = 251
        Me.Chart1.Text = "Chart1"
        '
        'ButtonChart
        '
        Me.ButtonChart.Location = New System.Drawing.Point(689, 650)
        Me.ButtonChart.Name = "ButtonChart"
        Me.ButtonChart.Size = New System.Drawing.Size(152, 45)
        Me.ButtonChart.TabIndex = 252
        Me.ButtonChart.Text = "ButtonChart"
        Me.ButtonChart.UseVisualStyleBackColor = True
        '
        'Fr_Chart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1368, 707)
        Me.Controls.Add(Me.ButtonChart)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "Fr_Chart"
        Me.Text = "Fr_Chart"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel3 As Panel
    Friend WithEvents BeginDate As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents EndDate As DateTimePicker
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolStripMenuItem文件 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem退出X As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem帮助 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem退出 As ToolStripMenuItem
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents ButtonChart As Button
End Class
