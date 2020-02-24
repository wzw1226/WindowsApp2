
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Threading
Public Class Form3
    Private AddDataRunner As Thread
    Private Rand As New Random()
    Public Delegate Sub AddDataDelegate()  '定义一个线程委托
    Public AddDataDel As AddDataDelegate
    Private minValue, maxValue As DateTime

    Private Sub Form2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '定义一个新的线程进行循环执行
        Dim addDataThreadStart As New ThreadStart(AddressOf AddDataThreadLoop)
        '把线程交给公共线程来管理
        AddDataRunner = New Thread(addDataThreadStart)
        '委托交付管理
        AddDataDel = New AddDataDelegate(AddressOf AddData)

    End Sub

    ''' <summary>
    ''' 主线程每秒循环一次，并通过委托,将数据发给你 CHART
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AddDataThreadLoop()
        While True
            Chart1.Invoke(AddDataDel)

            Thread.Sleep(1000)
        End While
    End Sub 'AddDataThreadLoop

    Public Sub AddData()
        Dim timeStamp As DateTime = DateTime.Now

        Dim ptA As ChartArea
        For Each ptA In Chart1.ChartAreas
            Dim ptSeries As Series
            '对每series进行数据扫描
            For Each ptSeries In Chart1.Series
                Dim k As Single
                k = Rand.Next(10, 50)
                AddNewPoint(timeStamp, k, ptSeries)
            Next ptSeries
        Next
    End Sub 'AddData


    ''' <summary>
    ''' x轴为时间，y轴为数据,并根据随机数据进行填写；
    ''' </summary>
    ''' <param name="timeStamp"></param>
    ''' <param name="ptSeries"></param>
    ''' <remarks></remarks>
    Public Sub AddNewPoint(timeStamp As DateTime, ByVal pValue As Single, ptSeries As System.Windows.Forms.DataVisualization.Charting.Series)
        Dim newVal As Double = 0

        If ptSeries.Points.Count > 0 Then
            newVal = ptSeries.Points((ptSeries.Points.Count - 1)).YValues(0) + (Rand.NextDouble() * 2 - 1)
        End If

        If newVal < 0 Then
            newVal = 0
        End If

        ' Add new data point to its series.
        ptSeries.Points.AddXY(timeStamp.ToOADate, pValue)

        ' remove all points from the source series older than 1.5 minutes.
        Dim removeBefore As Double = timeStamp.AddSeconds((CDbl(90) * -1)).ToOADate()
        'remove oldest values to maintain a constant number of data points
        While ptSeries.Points(0).XValue < removeBefore
            ptSeries.Points.RemoveAt(0)
        End While

        Dim ptA As ChartArea
        For Each ptA In Chart1.ChartAreas
            ptA.AxisX.Minimum = ptSeries.Points(0).XValue
            ptA.AxisX.Maximum = DateTime.FromOADate(ptSeries.Points(0).XValue).AddMinutes(2).ToOADate()
        Next

        Chart1.Invalidate()
    End Sub

    ' Clean up any resources being used.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If (AddDataRunner.ThreadState And ThreadState.Suspended) = ThreadState.Suspended Then
#Disable Warning BC40000 ' 类型或成员已过时
            AddDataRunner.Resume()
#Enable Warning BC40000 ' 类型或成员已过时
        End If
        AddDataRunner.Abort()

        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub 'Dispose



    Private Sub StartTrending_Click(sender As System.Object, e As System.EventArgs) Handles startTrending.Click
        ' 开始按钮状态
        startTrending.Enabled = False
        ' 停止按钮状态
        stopTrending.Enabled = True

        ' Predefine the viewing area of the chart
        minValue = DateTime.Now
        '2分钟预览区域
        maxValue = minValue.AddSeconds(120)

        Chart1.ChartAreas(0).AxisX.Minimum = minValue.ToOADate()
        Chart1.ChartAreas(0).AxisX.Maximum = maxValue.ToOADate()

        Chart1.ChartAreas(1).AxisX.Minimum = minValue.ToOADate()
        Chart1.ChartAreas(1).AxisX.Maximum = maxValue.ToOADate()

        ' Reset number of series in the chart.
        Chart1.Series.Clear()

        ' create a line chart series
        Dim newSeries1 As New Series("Series1")
        With newSeries1
            .LegendText = "曲线一"
            .ChartType = SeriesChartType.Line
            .BorderWidth = 1
            .Color = Color.Red
            .XValueType = ChartValueType.Time
        End With
        newSeries1.ChartArea = "ChartArea1"

        Dim newSeries2 As New Series("Series2")
        With newSeries2
            .LegendText = "曲线二"
            .ChartType = SeriesChartType.Line
            .BorderWidth = 1
            .Color = Color.Blue
            .XValueType = ChartValueType.Time
        End With
        newSeries2.ChartArea = "ChartArea2"

        Chart1.Series.Add(newSeries1)
        Chart1.Series.Add(newSeries2)

        ' start worker threads.
        If AddDataRunner.IsAlive <> True Then
            AddDataRunner.Start()
        Else
#Disable Warning BC40000 ' 类型或成员已过时
            AddDataRunner.Resume()
#Enable Warning BC40000 ' 类型或成员已过时
        End If
    End Sub

    Private Sub StopTrending_Click(sender As System.Object, e As System.EventArgs) Handles stopTrending.Click
        If AddDataRunner.IsAlive = True Then
            AddDataRunner.Resume()
        End If

        ' Enable all controls on the form
        startTrending.Enabled = True
        ' and only Disable the Stop button
        stopTrending.Enabled = False
    End Sub

End Class