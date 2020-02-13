Public Class 配置打印机

   

    Private Sub 配置打印机_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '//获取本机所有打印机将其名称填充到comboBoxPrinters中：包含本地和网络打印机
        For i = 0 To System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count - 1
            ComboBox1.Items.Add(System.Drawing.Printing.PrinterSettings.InstalledPrinters.Item(i))
            ComboBox2.Items.Add(System.Drawing.Printing.PrinterSettings.InstalledPrinters.Item(i))
            ComboBox3.Items.Add(System.Drawing.Printing.PrinterSettings.InstalledPrinters.Item(i))
            ComboBox4.Items.Add(System.Drawing.Printing.PrinterSettings.InstalledPrinters.Item(i))
        Next
        StrReader()
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        '注:      文件的路径及文件名不存在时, 会自动创建
        Dim objFile As New System.IO.StreamWriter(Application.StartupPath + "\配置打印机.ini", False)

        objFile.WriteLine(ComboBox1.Text.Trim.ToString)
        objFile.WriteLine(ComboBox2.Text.Trim.ToString)
        objFile.WriteLine(ComboBox3.Text.Trim.ToString)
        objFile.WriteLine(ComboBox4.Text.Trim.ToString)

        objFile.Close()  '关闭文件

        objFile.Dispose() '释放对象
        MessageBox.Show("保存成功！")

        If (System.IO.File.Exists(Application.StartupPath + "\配置打印机.ini")) = False Then
            Exit Sub
        End If
        Dim strContents As New ArrayList
        Dim MyReader As New System.IO.StreamReader(Application.StartupPath + "\配置打印机.ini", _
                                                                 System.Text.Encoding.UTF8)


        Do While MyReader.Peek() > 0
            strContents.Add(MyReader.ReadLine)
        Loop

        MyReader.Close()
        '_Print一般文件激光打印字机 = strContents.Item(0).ToString
        '_Print单据文件80列针式打印机 = strContents.Item(1).ToString
        '_PrintA5横式激光打印机 = strContents.Item(2).ToString
        '_Print专用条形码打印字机 = strContents.Item(3).ToString

        Me.Close()
    End Sub
    Private Sub StrReader()

        If (System.IO.File.Exists(Application.StartupPath + "\配置打印机.ini")) = False Then
            Exit Sub
        End If
        Dim strContents As New ArrayList
        Dim MyReader As New System.IO.StreamReader(Application.StartupPath + "\配置打印机.ini", _
                                                                 System.Text.Encoding.UTF8)


        Do While MyReader.Peek() > 0
            strContents.Add(MyReader.ReadLine)
        Loop

        MyReader.Close()
        ComboBox1.Text = strContents.Item(0).ToString
        ComboBox2.Text = strContents.Item(1).ToString
        ComboBox3.Text = strContents.Item(2).ToString
        ComboBox4.Text = strContents.Item(3).ToString
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button针式打印机安装指南_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button针式打印机安装指南.Click
        If System.IO.File.Exists(Application.StartupPath + "\针式打印机安装指南.docx") = True Then
            Process.Start(Application.StartupPath + "\针式打印机安装指南.docx")
        End If

    End Sub
End Class