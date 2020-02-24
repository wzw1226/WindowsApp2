Imports System.Data.SqlClient
Imports System.Windows.Forms.DataVisualization.Charting
Public Class Fr_Chart

#Region "窗口基本程序"

    Private Sub Fr打印送货单和出车单_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Try
            If e.KeyCode = Keys.Return Then
                SendKeys.Send("{TAB}")
            End If
            If e.KeyCode = Keys.Escape Then
                Me.Enabled = False
            End If
            'If e.KeyCode = Keys.F1 And Me.Enabled = False Then
            '    If 对话.ShowDialog = DialogResult.Cancel Then
            '        Exit Sub
            '    End If
            '    If CKpassword <> Password Then
            '        MsgBox(" 输入密码错误，操作取消！", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "提示信息")
            '        CKpassword = ""
            '        Exit Sub
            '    Else
            '        CKpassword = ""
            '        Me.Enabled = True
            '    End If
            'End If
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripMenuItem帮助_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem帮助.Click
        Try
            Dim strHelp As String = ""
            If (System.IO.File.Exists(Application.StartupPath.ToString + "\帮助文件\" + Me.Name.ToString + ".ini")) Then
                Dim MyReader As New System.IO.StreamReader(Application.StartupPath.ToString + "\帮助文件\" + Me.Name.ToString + ".ini",
                                                                      System.Text.Encoding.Default) 'UTF8)

                Do While MyReader.Peek() > 0
                    strHelp += MyReader.ReadLine + ControlChars.Cr
                Loop
                MyReader.Close()
                MyReader.Dispose()
            Else
                strHelp = "末写出"
            End If

            Help.ShowPopup(Me, strHelp, New Point(100, 100))
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripMenuItem退出_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem退出.Click
        Me.Close()
    End Sub

    Private Sub ToolStripMenuItem退出X_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem退出X.Click
        Me.Close()
    End Sub

#End Region

#Region "DataGridView1"

    Private Sub DataGridView1_CellFormatting(ByVal sender As Object,
            ByVal e As DataGridViewCellFormattingEventArgs) _
            Handles DataGridView1.CellFormatting
        Try
            Dim dgv As DataGridView = CType(sender, DataGridView)
            If TypeOf e.Value Is Integer Or TypeOf e.Value Is Double Or TypeOf e.Value Is Decimal Or TypeOf e.Value Is Single Then
                Dim val As Double = CDbl(e.Value)
                If val < 0 Then
                    e.CellStyle.ForeColor = Color.Red
                ElseIf val = 0 Then
                    e.CellStyle.ForeColor = Color.Blue
                End If
            End If
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick

        If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
            Dim strClipboard As String = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString
            If String.IsNullOrEmpty(strClipboard) = False Then
                Clipboard.Clear()
                Clipboard.SetDataObject(strClipboard)
                MessageBox.Show("已复制: " + strClipboard)
            End If
        End If

    End Sub

    ' DataGridView根据单元格值设定单元格样式单元格负数情况下显示黄色，0的情况下显示红色
    Private Sub DataGridView1_DataError(ByVal sender As Object,
                    ByVal e As DataGridViewDataErrorEventArgs) _
                      Handles DataGridView1.DataError

        MessageBox.Show("发现错误:存在输入不是数字之类的错误！") ' _
        ' & e.Context.ToString())

        If (e.Context = DataGridViewDataErrorContexts.Commit) _
            Then
            MessageBox.Show("存在输入不是数字之类的错误！")
            ' MessageBox.Show("Commit error")
        End If
        If (e.Context = DataGridViewDataErrorContexts _
            .CurrentCellChange) Then
            MessageBox.Show("存在输入不是数字之类的错误！")
            ' MessageBox.Show("Cell change")
        End If
        If (e.Context = DataGridViewDataErrorContexts.Parsing) _
            Then
            MessageBox.Show("存在输入不是数字之类的错误！")
            ' MessageBox.Show("parsing error")
        End If
        If (e.Context =
            DataGridViewDataErrorContexts.LeaveControl) Then
            MessageBox.Show("存在输入不是数字之类的错误！")
            ' MessageBox.Show("leave control error")
        End If

        If (TypeOf (e.Exception) Is ConstraintException) Then
            Dim view As DataGridView = CType(sender, DataGridView)
            view.Rows(e.RowIndex).ErrorText = "错误"
            view.Rows(e.RowIndex).Cells(e.ColumnIndex) _
                .ErrorText = "错误"

            e.ThrowException = False
        End If
    End Sub

    Private Sub DataGridView1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        Using b As SolidBrush =
    New SolidBrush(DataGridView1.RowHeadersDefaultCellStyle.ForeColor)

            e.Graphics.DrawString((e.RowIndex.ToString(
            System.Globalization.CultureInfo.CurrentUICulture) + 1),
                                  DataGridView1.DefaultCellStyle.Font,
                                                                                       b,
                                             e.RowBounds.Location.X + 20,
                                             e.RowBounds.Location.Y + 4)

        End Using

    End Sub

    Private Sub DataGridViewinfo1()
        Try
            DataGridView1.AllowUserToOrderColumns = False
            DataGridView1.AllowUserToAddRows = False
            '-----------------------
            '复数行选择可用
            DataGridView1.MultiSelect = False
            '---------------------------------------
            'DataGridView1.AllowUserToAddRows = False
            ' 设定包括Header和所有单元格的列宽自动调整()
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            '设定包括Header和所有单元格的行高自动调整
            DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

            '单元格选择的时候默认为选择整行
            '   DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '表头部单元格颜色设定  黄緑色
            DataGridView1.EnableHeadersVisualStyles = False
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.YellowGreen
            DataGridView1.TopLeftHeaderCell.Value = "行号"
            '表头部分行高列幅自动调整
            DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize

            'DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            'DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            'DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            'DataGridView1.Columns(0).ReadOnly = True
            'DataGridView1.Columns(0).Visible = False
            'DataGridView1.Columns(1).ReadOnly = True
            'DataGridView1.Columns(2).ReadOnly = True
            'DataGridView1.Columns(3).ReadOnly = True

            DataGridView1.Refresh()
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

#End Region
    Private Sub ButtonChart_Click(sender As Object, e As EventArgs) Handles ButtonChart.Click
        Dim SqlHelper As New SqlHelper
        Dim paras As SqlParameter() =
            {New SqlParameter("@DateStart", BeginDate.Value.ToShortDateString),
             New SqlParameter("@DateEnd", EndDate.Value.ToShortDateString)
             }
        Dim dt1 As DataTable = SqlHelper.ExecSelect("Chart_期间日期_落单金额_送货金额", CommandType.StoredProcedure, paras)

        If dt1.Rows.Count = 0 Then
            MessageBox.Show("无数据,操作取消！")
            Exit Sub
        End If
        DataGridView1.DataSource = dt1
        DataGridViewinfo1()
        MsgBox("导入成功！", MsgBoxStyle.OkOnly, "提示信息")

#Region "图表样式"

        'Chart1.BackGradientStyle = = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;//指定图表元素的渐变样式(中心向外，从左到右，从上到下等等)

        '    Chart1.BackSecondaryColor = System.Drawing.Color.Yellow;//设置背景的辅助颜色

        '    Chart1.BorderlineColor = System.Drawing.Color.Yellow;//设置图像边框的颜色

        '    Chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;//设置图像边框线的样式(实线、虚线、点线)

        '    Chart1.BorderlineWidth = 2;//设置图像的边框宽度

        '    Chart1.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;//设置图像的边框外观样式

        '    Chart1.BackColor = System.Drawing.Color.Yellow;//设置图表的背景颜色
        ' //设置Chart1的相关属性
        'Chart1.BackGradientEndColor = Color.White;
        'Chart1.BorderlineColor = Color.White;
        'Chart1.BorderlineWidth = 0;
        'Chart1.BorderSkin.FrameBackColor = Color.MediumTurquoise;
        'Chart1.BorderSkin.FrameBackGradientEndColor = Color.Teal;
        'Chart1.Palette = ChartColorPalette.SemiTransparent;
        'Chart1.Width = 545;
        'Chart1.Height = 215;
        'Chart1.ImageType = ChartImageType.Jpeg;
        'Chart1.AntiAliasing = AntiAliasing.All;
        'Chart1.Titles.Add("Default");
        'Chart1.Titles[0].Text = "测试Chart";
        'Chart1.Titles[0].Alignment = ContentAlignment.TopCenter;
        'Chart1.Titles[0].Font = New Font("黑体", 12, FontStyle.Bold);
        'Chart1.Titles[0].Color = Color.FromArgb(72, 72, 72);
#End Region
        Chart1.Titles.Add("Default")
        Chart1.Titles(0).Text = "测试Chart"
        Chart1.Titles(0).Alignment = ContentAlignment.TopCenter
        Chart1.Titles(0).Font = New Font("黑体", 12, FontStyle.Bold)
        'Chart1.Titles(0).Color = Color.FromArgb(72, 72, 72)
        Chart1.Series.Clear()
#Region “图例样式”

        'Legend l = New Legend();//初始化一个图例的实例

        '    l.Alignment = System.Drawing.StringAlignment.Near;//设置图表的对齐方式(中间对齐，靠近原点对齐，远离原点对齐)

        '    l.BackColor = System.Drawing.Color.Black;//设置图例的背景颜色

        '    l.DockedToChartArea = "ChartArea1";//设置图例要停靠在哪个区域上

        '    l.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;//设置停靠在图表区域的位置(底部、顶部、左侧、右侧)

        '    l.Font = New System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);//设置图例的字体属性

        '    l.IsTextAutoFit = True;//设置图例文本是否可以自动调节大小

        '    l.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;//设置显示图例项方式(多列一行、一列多行、多列多行)

        '    l.Name = "l1";//设置图例的名称

        '    Chart1.Legends.Add(l.Name);

#End Region
        '调整图例的位置
        Chart1.Legends(0).Docking = Docking.Right
        Chart1.Legends(0).TitleFont = New Font("宋体", 25.0F)



#Region “图表区域样式”

        'Chart1.ChartAreas["ChartArea1"].Name = "图表区域";

        '    Chart1.ChartAreas["图表区域"].Position.Auto = True;//设置是否自动设置合适的图表元素

        '    Chart1.ChartAreas["图表区域"].ShadowColor = System.Drawing.Color.YellowGreen;//设置图表的阴影颜色

        '    Chart1.ChartAreas["图表区域"].Position.X=5.089137F;//设置图表元素左上角对应的X坐标

        '    Chart1.ChartAreas["图表区域"].Position.Y = 5.895753F;//设置图表元素左上角对应的Y坐标

        '    Chart1.ChartAreas["图表区域"].Position.Height = 86.76062F;//设置图表元素的高度

        '    Chart1.ChartAreas["图表区域"].Position.Width = 88F;//设置图表元素的宽度

        '    Chart1.ChartAreas["图表区域"].InnerPlotPosition.Auto = False;//设置是否在内部绘图区域中自动设置合适的图表元素

        '    Chart1.ChartAreas["图表区域"].InnerPlotPosition.Height = 85F;//设置图表元素内部绘图区域的高度

        '    Chart1.ChartAreas["图表区域"].InnerPlotPosition.Width = 86F;//设置图表元素内部绘图区域的宽度

        '    Chart1.ChartAreas["图表区域"].InnerPlotPosition.X = 8.3969F;//设置图表元素内部绘图区域左上角对应的X坐标

        '    Chart1.ChartAreas["图表区域"].InnerPlotPosition.Y = 3.63068F;//设置图表元素内部绘图区域左上角对应的Y坐标

        '    Chart1.ChartAreas["图表区域"].Area3DStyle.Inclination = 10;//设置三维图表的旋转角度

        '    Chart1.ChartAreas["图表区域"].Area3DStyle.IsClustered = True;//设置条形图或柱形图的的数据系列是否为簇状

        '    Chart1.ChartAreas["图表区域"].Area3DStyle.IsRightAngleAxes = True;//设置图表区域是否使用等角投影显示

        '    Chart1.ChartAreas["图表区域"].Area3DStyle.LightStyle = System.Web.UI.DataVisualization.Charting.LightStyle.Realistic;//设置图表的照明类型(色调随旋转角度改变而改变，不应用照明，色调不改变)

        '    Chart1.ChartAreas["图表区域"].Area3DStyle.Perspective = 50;//设置三维图区的透视百分比

        '    Chart1.ChartAreas["图表区域"].Area3DStyle.Rotation = 60;//设置三维图表区域绕垂直轴旋转的角度

        '    Chart1.ChartAreas["图表区域"].Area3DStyle.WallWidth = 0;//设置三维图区中显示的墙的宽度

        '    Chart1.ChartAreas["图表区域"].Area3DStyle.Enable3D = True;//设置是否显示3D效果

        '    Chart1.ChartAreas["图表区域"].BackColor = System.Drawing.Color.Green;//设置图表区域的背景颜色

        '    Chart1.ChartAreas["图表区域"].BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;//指定图表元素的渐变样式(中心向外，从左到右，从上到下等等)

        '    Chart1.ChartAreas["图表区域"].BackSecondaryColor = System.Drawing.Color.White;//设置图表区域的辅助颜色

        '    Chart1.ChartAreas["图表区域"].BorderColor = System.Drawing.Color.White;//设置图表区域边框颜色

        '    Chart1.ChartAreas["图表区域"].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;//设置图像边框线的样式(实线、虚线、点线)



        '    Chart1.ChartAreas["图表区域"].AxisX.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);//设置X轴下方的提示信息的字体属性

        '    Chart1.ChartAreas["图表区域"].AxisX.LabelStyle.Format = "";//设置标签文本中的格式字符串

        '    Chart1.ChartAreas["图表区域"].AxisX.LabelStyle.Interval=5D;//设置标签间隔的大小

        '    Chart1.ChartAreas["图表区域"].AxisX.LabelStyle.IntervalType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.Number;//设置间隔大小的度量单位

        '    Chart1.ChartAreas["图表区域"].AxisX.LineColor = System.Drawing.Color.White;//设置X轴的线条颜色

        '    Chart1.ChartAreas["图表区域"].AxisX.MajorGrid.Interval=5D;//设置主网格线与次要网格线的间隔

        '    Chart1.ChartAreas["图表区域"].AxisX.MajorGrid.IntervalType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.Number;//设置主网格线与次网格线的间隔的度量单位

        '    Chart1.ChartAreas["图表区域"].AxisX.MajorGrid.LineColor = System.Drawing.Color.Snow;//设置网格线的颜色

        '    Chart1.ChartAreas["图表区域"].AxisX.MajorTickMark.Interval = 5D;//设置刻度线的间隔

        '    Chart1.ChartAreas["图表区域"].AxisX.MajorTickMark.IntervalType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.Number;//设置刻度线的间隔的度量单位



        '    Chart1.ChartAreas["图表区域"].AxisY.IsLabelAutoFit = False;//设置是否自动调整轴标签

        '    Chart1.ChartAreas["图表区域"].AxisY.IsStartedFromZero = False;//设置是否自动将数据值均为正值时轴的最小值设置为0，存在负数据值时，将使用数据轴最小值

        '    Chart1.ChartAreas["图表区域"].AxisY.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);//设置Y轴左侧的提示信息的字体属性

        '    Chart1.ChartAreas["图表区域"].AxisY.LineColor = System.Drawing.Color.DarkBlue;//设置轴的线条颜色

        '    Chart1.ChartAreas["图表区域"].AxisY.MajorGrid.LineColor = System.Drawing.Color.White;//设置网格线颜色

        '    Chart1.ChartAreas["图表区域"].AxisY.Maximum = getmax() + 100;//设置Y轴最大值
        '    Chart1.ChartAreas["图表区域"].AxisY.Minimum=0;//设置Y轴最小值
        '          //设置游标
        ' 46                 chart.ChartAreas[0].CursorX.IsUserEnabled = true;
        ' 47                 chart.ChartAreas[0].CursorX.AutoScroll = true;
        ' 48                 chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
        ' 49                 //设置X轴是否可以缩放
        ' 50                 chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
        ' 51                 //将滚动条放到图表外
        ' 52                 chart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = false;
        ' 53                 // 设置滚动条的大小
        ' 54                 chart.ChartAreas[0].AxisX.ScrollBar.Size = 15;
        ' 55                 // 设置滚动条的按钮的风格，下面代码是将所有滚动条上的按钮都显示出来
        ' 56                 chart.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
        ' 57                 chart.ChartAreas[0].AxisX.ScrollBar.ButtonColor = Color.SkyBlue;
        ' 58                 // 设置自动放大与缩小的最小量
        ' 59                 chart.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = double.NaN;
        ' 60                 chart.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = 1;
        ' 61                 //设置刻度间隔
        ' 62                 chart.ChartAreas[0].AxisX.Interval = 10;
        ' 63                 //将X轴上格网取消
        ' 64                 chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
        ' 65                 //X轴、Y轴标题
        ' 66                 chart.ChartAreas[0].AxisX.Title = "环号";
        ' 67                 chart.ChartAreas[0].AxisY.Title = "直径";
#End Region
        '设置坐标轴标题
        Chart1.ChartAreas(0).AxisX.Title = "日期"
        Chart1.ChartAreas(0).AxisY.Title = "金额"
        'Chart1.ChartAreas(0).AxisY2.Title = "百分比（%）"
        '设置坐标轴标题的字体
        Chart1.ChartAreas(0).AxisX.TitleFont = New Font("宋体", 12.0F)
        Chart1.ChartAreas(0).AxisY.TitleFont = New Font("宋体", 12.0F)
        'Chart1.ChartAreas(0).AxisY2.TitleFont = New Font("宋体", 12.0F)
        '设置坐标轴栅格是否可见。。
        Chart1.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        Chart1.ChartAreas(0).AxisY.MajorGrid.Enabled = False
        'Chart1.ChartAreas(0).AxisY2.MajorGrid.Enabled = False

        '    Chart1.ChartAreas[0].AxisX.Interval = 1;//设置X轴间距，这样的话，就间距固定为1
        '    Chart1.ChartAreas[0].AxisY.Maximum = max;//设置Y轴最大值
        '    Chart1.ChartAreas[0].AxisY.Minimum = min; //设置Y轴最小值
        '设置游标
        Chart1.ChartAreas(0).CursorX.IsUserEnabled = True
        Chart1.ChartAreas(0).CursorY.IsUserEnabled = True
        'Chart1.ChartAreas(0).CursorX.AutoScroll = True
        'Chart1.ChartAreas(0).CursorY.IsUserSelectionEnabled = True


        Chart1.DataSource = dt1
        '        日期 Date,
        '落单金额 NUMERIC(16, 2),
        '送货金额 NUMERIC(16, 2)

        For i As Integer = 1 To dt1.Columns.Count - 1
            Chart1.Series.Add(dt1.Columns（i).ColumnName.ToString)
            Chart1.Series(dt1.Columns（i).ColumnName.ToString).XValueType = ChartValueType.Date '//设置X轴绑定值的类型
            Chart1.Series(dt1.Columns（i).ColumnName.ToString).XValueMember = dt1.Columns（0).ColumnName.ToString
            Chart1.Series(dt1.Columns（i).ColumnName.ToString).IsValueShownAsLabel = True
            Chart1.Series(dt1.Columns（i).ColumnName.ToString).YValueMembers = dt1.Columns（i).ColumnName.ToString
            Chart1.Series(dt1.Columns（i).ColumnName.ToString).ChartType = SeriesChartType.Column
        Next
        '设置曲线的颜色
        Chart1.Series(0).Color = Color.Red
        Chart1.Series(0).LabelForeColor = Color.Red
        Chart1.Series(1).Color = Color.Blue
        Chart1.Series(1).LabelForeColor = Color.Blue
        Chart1.DataBind()
        Chart1.Series.Add("颜色" + "  落单金额  ")







    End Sub
End Class