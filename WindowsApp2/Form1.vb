Imports System.Windows.Forms.DataVisualization.Charting

Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '绘制柱形图
        Chart1.ChartAreas.Clear()
        Dim ChartAreas1 As New ChartArea("Read length")    '定义新的ChartArea
        Chart1.ChartAreas.Add(ChartAreas1)                 '将新定义的ChartArea加入Chart1
        Chart1.ChartAreas(0).AxisX.Title = "Length (nt)"   '设置ChartArea里坐标轴标题
        Chart1.ChartAreas(0).AxisY.Title = "Read count"

        Chart1.Series.Clear()
#Disable Warning IDE0017 ' 简化对象初始化
        Dim series1 As New Series("Read Count")
#Enable Warning IDE0017 ' 简化对象初始化
        series1.ChartType = SeriesChartType.Column         '设置Series的绘图类型
        Chart1.Series.Add(series1)

        For i As Integer = 17 To 37
            Chart1.Series("Read Count").Points.AddXY(i, i + 5)    '为这个Series加数据点
        Next
        Chart1.Legends(0).Docking = Docking.Right             '调整图例的位置
        '//设置坐标轴标题
        '    Chart1.ChartAreas[0].AxisX.Title = "日期";
        '    Chart1.ChartAreas[0].AxisY.Title = "产量";
        '    Chart1.ChartAreas[0].AxisY2.Title = "百分比（%）";

        '    //设置坐标轴标题的字体
        '    Chart1.ChartAreas[0].AxisX.TitleFont = New Font("宋体", 12F);
        '    Chart1.ChartAreas[0].AxisY.TitleFont = New Font("宋体", 12F);
        '    Chart1.ChartAreas[0].AxisY2.TitleFont = New Font("宋体", 12F);

        '    //设置坐标轴栅格是否可见。。
        '    Chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = False;
        '    Chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = False;
        '    Chart1.ChartAreas[0].AxisY2.MajorGrid.Enabled = False;
        'Chart1.Series[0].ChartType = SeriesChartType.Line;//设置曲线类型

        '    Chart1.Series[0].XValueType = ChartValueType.DateTime;//设置X轴绑定值的类型

        '    Chart1.Series[0].LegendToolTip = "Target Output";//鼠标放到系列上出现的文字 

        '    Chart1.Series[0].LegendText = "Target Output";//系列名字 

        '    Chart1.ChartAreas[0].AxisX.Minimum = 1;//坐标最小值，这样的话，X轴坐标是从1开始

        '    Chart1.Series[0].IsValueShownAsLabel = True;//值作为标签显示在图表中

        '    Chart1.Series[0].BorderWidth = 3;//设置线宽

        '    Chart1.ChartAreas[0].AxisX.Interval = 1;//设置X轴间距，这样的话，就间距固定为1

        '    Double max = 120, min = 0;

        '    Chart1.ChartAreas[0].AxisY.Maximum = max;//设置Y轴最大值

        '    Chart1.ChartAreas[0].AxisY.Minimum = min; //设置Y轴最小值

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' 下面再来说说如何将绘制的数据图表保存起来。Chart对象有一个方法叫SaveImage，直接就能将图表存为BMP,JPG,PNG,TIF等位图格式，更重要的是还能直接存成EMF格式的矢量图!这样就不怕后期放大了。
        '命令嘛， 很简单
        'Chart1.SaveImage(SaveFileDialog1.FileName, ChartImageFormat.Png)
    End Sub
    ''Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    ''    Chart1.Series.Clear()
    ''    'Chart1.Series.RemoveAt(0)   '清除原来的系列
    ''    Dim i As Integer
    ''    Dim j As Integer
    ''    For i = 0 To 11    '设置有12个系列
    ''        Chart1.Series.Add("系列" & i)
    ''        ''添加数据点的个数
    ''        For j = 0 To 3   '设置有4个数据点
    ''            Chart1.Series(i).Points.Add()
    ''        Next
    ''    Next

    ''    '用生成的随机数（范围[2.0，9.9]），作为数据
    ''    Randomize()
    ''    For i = 0 To 11
    ''        For j = 0 To 3
    ''            Chart1.Series(i).Points(j).YValues = {Int((99 - 20 + 1) * Rnd() + 20) / 10} ' {i, j} ' Convert.ToDouble(55) ' {Int((99 - 20 1) * Rnd() 20) / 10}   '将随机数据赋值给图表点的Y值
    ''        Next
    ''        Chart1.Series(i).ChartType = DataVisualization.Charting.SeriesChartType.Column  '设置图表类型
    ''    Next

    ''End Sub
End Class
