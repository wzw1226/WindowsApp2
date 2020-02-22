<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form3
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    '<System.Diagnostics.DebuggerNonUserCode()>
    'Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    '    Try
    '        If disposing AndAlso components IsNot Nothing Then
    '            components.Dispose()
    '        End If
    '    Finally
    '        MyBase.Dispose(disposing)
    '    End Try
    'End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.startTrending = New System.Windows.Forms.Button()
        Me.stopTrending = New System.Windows.Forms.Button()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(33, 12)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(885, 499)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        '
        'startTrending
        '
        Me.startTrending.Location = New System.Drawing.Point(1071, 60)
        Me.startTrending.Name = "startTrending"
        Me.startTrending.Size = New System.Drawing.Size(133, 23)
        Me.startTrending.TabIndex = 2
        Me.startTrending.Text = "startTrending"
        Me.startTrending.UseVisualStyleBackColor = True
        '
        'stopTrending
        '
        Me.stopTrending.Location = New System.Drawing.Point(1071, 123)
        Me.stopTrending.Name = "stopTrending"
        Me.stopTrending.Size = New System.Drawing.Size(124, 23)
        Me.stopTrending.TabIndex = 3
        Me.stopTrending.Text = "stopTrending"
        Me.stopTrending.UseVisualStyleBackColor = True
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1236, 578)
        Me.Controls.Add(Me.stopTrending)
        Me.Controls.Add(Me.startTrending)
        Me.Controls.Add(Me.Chart1)
        Me.Name = "Form3"
        Me.Text = "Form3"
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents startTrending As Button
    Friend WithEvents stopTrending As Button
End Class
