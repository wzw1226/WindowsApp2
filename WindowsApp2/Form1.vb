Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar

Public Class Form1
    'Private Rand As New Random()
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Chart1.Series.Clear()
        'Chart1.Series.RemoveAt(0)   '清除原来的系列
        Dim i As Integer
        Dim j As Integer
        For i = 0 To 11    '设置有12个系列
            Chart1.Series.Add("系列" & i)
            ''添加数据点的个数
            For j = 0 To 3   '设置有4个数据点
                Chart1.Series(i).Points.Add()
            Next
        Next

        '用生成的随机数（范围[2.0，9.9]），作为数据
        Randomize()
        For i = 0 To 11
            For j = 0 To 3
                Chart1.Series(i).Points(j).YValues = {Int((99 - 20 + 1) * Rnd() + 20) / 10} ' {i, j} ' Convert.ToDouble(55) ' {Int((99 - 20 1) * Rnd() 20) / 10}   '将随机数据赋值给图表点的Y值
            Next
            Chart1.Series(i).ChartType = DataVisualization.Charting.SeriesChartType.Column  '设置图表类型
        Next

    End Sub
End Class
