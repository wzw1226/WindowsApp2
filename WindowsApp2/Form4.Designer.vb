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
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Right
        Me.DataGridView1.Location = New System.Drawing.Point(120, 24)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(1319, 576)
        Me.DataGridView1.TabIndex = 36
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 50)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 37
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1439, 600)
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
End Class
