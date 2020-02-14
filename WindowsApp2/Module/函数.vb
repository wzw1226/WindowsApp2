Imports System.Data.OleDb
Imports System.Text.RegularExpressions

Module 函数

    Public Function Ch(ByVal mystr As String) As String
#Enable Warning IDE1006 ' 命名样式
        '获得汉字的拼音简码2
        Dim a As Integer
        Ch = ""
        a = Len(mystr)
        For i = 1 To a
            Ch = Ch & Py(Mid(mystr, i, 1))
        Next i
    End Function

    Public Sub DataTable_To_Txt(ByVal dt As DataTable, ByVal filename As String)
        Try
            If dt Is Nothing Or dt.Rows.Count = 0 Then
                Exit Sub
            End If
            If filename = "" Then Exit Sub
            If System.IO.File.Exists(Application.StartupPath + "\" + filename + ".txt") = False Then
                'System.IO.File.Delete(Application.StartupPath + "\" + filename + ".txt")
                Dim MyStream As New System.IO.FileStream(Application.StartupPath + "\" + filename + ".txt",
                                                            System.IO.FileMode.Create)
                Dim My1Writer As New System.IO.StreamWriter(MyStream,
                                                System.Text.Encoding.UTF8)

                Dim str_dt As String = ""
                For I As Integer = 0 To dt.Rows.Count - 1
                    str_dt = ""
                    For j As Integer = 0 To dt.Columns.Count - 1
                        str_dt = str_dt + dt.Rows(I).Item(j).ToString + "|"
                    Next

                    Dim str_line As String = Microsoft.VisualBasic.Left(str_dt, str_dt.Length - 1)

                    My1Writer.WriteLine(str_line)
                Next

                My1Writer.Close()
            Else
                Dim My1Writer As System.IO.StreamWriter =
                                   System.IO.File.AppendText(Application.StartupPath + "\" + filename + ".txt")
                Dim str_dt As String = ""
                For I As Integer = 0 To dt.Rows.Count - 1
                    str_dt = ""
                    For j As Integer = 0 To dt.Columns.Count - 1
                        str_dt = str_dt + dt.Rows(I).Item(j).ToString + "|"
                    Next

                    Dim str_line As String = Microsoft.VisualBasic.Left(str_dt, str_dt.Length - 1)

                    My1Writer.WriteLine(str_line)
                Next

                My1Writer.Close()

            End If

            'Dim MyStream As New System.IO.FileStream(Application.StartupPath + "\" + filename + ".txt", _
            '                                                  System.IO.FileMode.Create)
            'Dim My1Writer As New System.IO.StreamWriter(MyStream, _
            '                                System.Text.Encoding.UTF8)

            'Dim My1Writer As System.IO.StreamWriter = _
            '                   System.IO.File.AppendText(Application.StartupPath + "\" + filename + ".txt")
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
            '异常信息显示
            Dim MyInfo As String = vbCrLf + "错误提供程序名称：" + ex.Source
            MyInfo += vbCrLf + "详细信息：" + ex.Message
            Dim Err_type As String, Err_place As String, Err_Accident As String
            Err_type = "系统" 'SQL  PLC  系统
            Err_place = "函数______" + "DataTable_To_Txt"
            'Err_place = Me.Name.ToString + "SqlCon______" + "Button2_Click"
            'Err_Accident = ""
            Err_Accident = MyInfo
            Write_ErrorLog(Err_type, Err_place, Err_Accident)

        End Try

    End Sub

    Public Sub DcExcel(ByVal DGV As DataGridView)
        '把datagridview中的数据导出到excel
        '添加对EXCEL的引用（在COM选项卡中）
        '假定某窗体中包含一个按钮控件(btnDc)和一个DataGridView控件(DGV1)，若需通过单击按钮来导出，则可在按钮btnDc的单击事件中添加以下代码：
        '    Private Sub btnDc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDc.Click
        '        Call DcExcel(DGV1)
        '    End Sub
        Dim wapp As New Microsoft.Office.Interop.Excel.Application
        Dim wsheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim wbook As Microsoft.Office.Interop.Excel.Workbook

        On Error Resume Next
        '显示与否
        ' wapp.Visible = False
        wapp.Visible = True
        wbook = wapp.Workbooks.Add()
        wsheet = wbook.ActiveSheet

        Dim iX As Integer
        Dim iY As Integer
        Dim iC As Integer

        For iC = 0 To DGV.Columns.Count - 1
            wsheet.Cells(1, iC + 1).Value = DGV.Columns(iC).HeaderText
            wsheet.Cells(1, iC + 1).Font.Bold = True
        Next

        wsheet.Rows(2).select()
        For iX = 0 To DGV.Rows.Count - 1
            For iY = 0 To DGV.Columns.Count - 1
                wsheet.Cells(iX + 2, iY + 1).value = DGV(iY, iX).Value.ToString
            Next
        Next
        '保存形式
        ' wbook.SaveAs("NewExcel.pdf")

        'wsheet = Nothing
        'wbook.Close(False)
        'wbook = Nothing

    End Sub

    Public Sub Del_txt_DataTable_To_Txt(ByVal dt As DataTable, ByVal filename As String)
        Try
            If dt Is Nothing Or dt.Rows.Count = 0 Then
                Exit Sub
            End If
            If filename = "" Then Exit Sub
            If System.IO.File.Exists(Application.StartupPath + "\" + filename + ".txt") = True Then
                System.IO.File.Delete(Application.StartupPath + "\" + filename + ".txt")

            End If

            Dim MyStream As New System.IO.FileStream(Application.StartupPath + "\" + filename + ".txt",
                                                        System.IO.FileMode.Create)
            Dim My1Writer As New System.IO.StreamWriter(MyStream,
                                            System.Text.Encoding.UTF8)

            Dim str_dt As String = ""
            For I As Integer = 0 To dt.Rows.Count - 1
                str_dt = ""
                For j As Integer = 0 To dt.Columns.Count - 1
                    str_dt = str_dt + dt.Rows(I).Item(j).ToString + "|"
                Next

                Dim str_line As String = Microsoft.VisualBasic.Left(str_dt, str_dt.Length - 1)

                My1Writer.WriteLine(str_line)
            Next

            My1Writer.Close()
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
            '异常信息显示
            Dim MyInfo As String = vbCrLf + "错误提供程序名称：" + ex.Source
            MyInfo += vbCrLf + "详细信息：" + ex.Message
            Dim Err_type As String, Err_place As String, Err_Accident As String
            Err_type = "系统" 'SQL  PLC  系统
            Err_place = "函数______" + "Del_txt_DataTable_To_Txt"
            'Err_place = Me.Name.ToString + "SqlCon______" + "Button2_Click"
            'Err_Accident = ""
            Err_Accident = MyInfo
            Write_ErrorLog(Err_type, Err_place, Err_Accident)

        End Try

    End Sub

    Public Function Encrypt(ByVal strSource As String) As String
        strSource += "81948033"
        '这里用的是ascii编码密码原文，如果要用汉字做密码，可以用UnicodeEncoding，但会与ASP中的MD5函数不兼容
        Dim dataToHash As Byte() = (New System.Text.ASCIIEncoding).GetBytes(strSource)
        Dim hashvalue As Byte() = CType(System.Security.Cryptography.CryptoConfig.CreateFromName("MD5"), System.Security.Cryptography.HashAlgorithm).ComputeHash(dataToHash)

        '选择位字符的加密结果
        Dim strResult As String = ""

        Dim i As Integer
        For i = 4 To 11
            strResult += Hex(hashvalue(i)).ToLower
        Next

        Return strResult
    End Function

    Public Function ExceltoDataTable() As DataTable
        'excel读取程序to DataTable
        'Imports System.Data.OleDb
        'Imports System.Data.Odbc

        'Dim path, FileName, FileExname As String
        Dim path As String
        Dim conn As String
#Disable Warning IDE0017 ' 简化对象初始化
        Dim OpenFileDialog1 As New OpenFileDialog()
#Enable Warning IDE0017 ' 简化对象初始化
        OpenFileDialog1.Title = "选择Excel文件"
        OpenFileDialog1.Filter = "Excel 文件|*.xls*"
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then

            path = System.IO.Path.GetFullPath(OpenFileDialog1.FileName)
            'FileName = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
            'FileExname = System.IO.Path.GetExtension(OpenFileDialog1.FileName).ToUpper
            'FileName = Microsoft.VisualBasic.Left(FileName.ToUpper, FileName.Length - 4)

            'If FileExname = "XLSX" Then

            '    conn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & path & ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1';"
            'Else
            conn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & path & ";Extended Properties='Excel 12.0;HDR=YES';"

            'End If
            Dim con As OleDbConnection = New OleDbConnection(conn)
            Dim odda As OleDbDataAdapter = New OleDbDataAdapter("select * from [Sheet1$]", conn)
            Dim ds As DataSet = New DataSet()
            odda.Fill(ds)
            Return ds.Tables(0)
        Else
            Return Nothing
        End If

    End Function

    Public Function GetImage(ByVal Pic As String) As System.Drawing.Image
        Dim fs As System.IO.FileStream = New System.IO.FileStream(Pic, System.IO.FileMode.Open)
        Dim result As System.Drawing.Image = System.Drawing.Image.FromStream(fs)
        fs.Close()
        Return result

    End Function

    Public Function GetPicByte(ByVal Pic As String) As Byte()
        Dim bit1() As Byte                 '定义一个二进制数组,用来存放图片
        Dim nLen As Long                '定义长度,用来得到图片大小
        Dim tStream As New FileIO.FileSystem       '定义文件系统,用来读取图片
        Dim tIoStream As New IO.FileStream(Pic, IO.FileMode.Open, IO.FileAccess.Read) '读取图片,图片名为:C:/RS-Dessert.gif
        Dim tIoBReader As New IO.BinaryReader(tIoStream)    '把图片数据读取成二进制.
        Dim tIoFileInfo As New IO.FileInfo(Pic)  '得到图片文件信息,如大小等.
        nLen = tIoFileInfo.Length
        ReDim bit1(nLen)
        tIoBReader.Read(bit1, 0, nLen)    '把图片二进制数据读取到Bit1
        Return bit1
    End Function

    Public Function GetPicByte1(ByVal str As String) As Byte()
        Dim bit1() As Byte                 '定义一个二进制数组,用来存放图片
        Dim strContents As New ArrayList

        Dim MyReader As New System.IO.StreamReader(str, System.Text.Encoding.UTF8)
        Do While MyReader.Peek() > 0
            strContents.Add(MyReader.ReadLine)
        Loop
        MyReader.Close()

        ReDim bit1(strContents.Count)
        Dim j As Integer
        For j = 0 To strContents.Count - 1
            bit1(j) = strContents.Item(j).ToString
        Next

        Return bit1
    End Function

    Public Function OpenFile() As String
        '创建原图文件
        Dim MyFileName As String = ""
#Disable Warning IDE0017 ' 简化对象初始化
        Dim MyDlg As New OpenFileDialog()
#Enable Warning IDE0017 ' 简化对象初始化
        MyDlg.Filter = "图像文件(JPeg,Gif,Bmp,etc.)|*.jpg;*.jpeg;*.gif; *.bmp; " +
                    "*.tif; *.tiff; *.png| JPeg 文件 (*.jpg;*.jpeg)|*.jpg;*.jpeg " +
                    "|GIF 文件 (*.gif)|*.gif |BMP 文件 (*.bmp)|*.bmp|Tiff 文件 " +
                    "(*.tif;*.tiff)|*.tif;*.tiff|Png 文件 (*.png)|" +
                    " *.png|xml文件(xml)|*.xml "
        If (MyDlg.ShowDialog() = Windows.Forms.DialogResult.OK) Then

            MyFileName = MyDlg.FileName
        End If
        Return MyFileName
    End Function

    Public Function Py(ByVal mystr As String) As String
#Enable Warning IDE1006 ' 命名样式
        '获得汉字的拼音简码1
        Py = ""
        If Asc(mystr) < 0 Then
            If Asc(Left(mystr, 1)) < Asc("啊") Then
                Py = "0"
                Exit Function
            End If
            If Asc(Left(mystr, 1)) >= Asc("啊") And Asc(Left(mystr, 1)) < Asc("芭") Then
                Py = "A"
                Exit Function
            End If
            If Asc(Left(mystr, 1)) >= Asc("芭") And Asc(Left(mystr, 1)) < Asc("擦") Then
                Py = "B"
                Exit Function
            End If
            If Asc(Left(mystr, 1)) >= Asc("擦") And Asc(Left(mystr, 1)) < Asc("搭") Then
                Py = "C"
                Exit Function
            End If
            If Asc(Left(mystr, 1)) >= Asc("搭") And Asc(Left(mystr, 1)) < Asc("蛾") Then
                Py = "D"
                Exit Function
            End If
            If Asc(Left(mystr, 1)) >= Asc("蛾") And Asc(Left(mystr, 1)) < Asc("发") Then
                Py = "E"
                Exit Function
            End If
            If Asc(Left(mystr, 1)) >= Asc("发") And Asc(Left(mystr, 1)) < Asc("噶") Then
                Py = "F"
                Exit Function
            End If
            If Asc(Left(mystr, 1)) >= Asc("噶") And Asc(Left(mystr, 1)) < Asc("哈") Then
                Py = "G"
                Exit Function
            End If
            If Asc(Left(mystr, 1)) >= Asc("哈") And Asc(Left(mystr, 1)) < Asc("击") Then
                Py = "H"
                Exit Function
            End If
            If Asc(Left(mystr, 1)) >= Asc("击") And Asc(Left(mystr, 1)) < Asc("喀") Then
                Py = "J"
                Exit Function
            End If
            If Asc(Left(mystr, 1)) >= Asc("喀") And Asc(Left(mystr, 1)) < Asc("垃") Then
                Py = "K"
                Exit Function
            End If
            If Asc(Left(mystr, 1)) >= Asc("垃") And Asc(Left(mystr, 1)) < Asc("妈") Then
                Py = "L"
                Exit Function
            End If
            If Asc(Left(mystr, 1)) >= Asc("妈") And Asc(Left(mystr, 1)) < Asc("拿") Then
                Py = "M"
                Exit Function
            End If
            If Asc(Left(mystr, 1)) >= Asc("拿") And Asc(Left(mystr, 1)) < Asc("哦") Then
                Py = "N"
                Exit Function
            End If
            If Asc(Left(mystr, 1)) >= Asc("哦") And Asc(Left(mystr, 1)) < Asc("啪") Then
                Py = "O"
                Exit Function
            End If
            If Asc(Left(mystr, 1)) >= Asc("啪") And Asc(Left(mystr, 1)) < Asc("期") Then
                Py = "P"
                Exit Function
            End If
            If Asc(Left(mystr, 1)) >= Asc("期") And Asc(Left(mystr, 1)) < Asc("然") Then
                Py = "Q"
                Exit Function
            End If
            If Asc(Left(mystr, 1)) >= Asc("然") And Asc(Left(mystr, 1)) < Asc("撒") Then
                Py = "R"
                Exit Function
            End If
            If Asc(Left(mystr, 1)) >= Asc("撒") And Asc(Left(mystr, 1)) < Asc("塌") Then
                Py = "S"
                Exit Function
            End If
            If Asc(Left(mystr, 1)) >= Asc("塌") And Asc(Left(mystr, 1)) < Asc("挖") Then
                Py = "T"
                Exit Function
            End If
            If Asc(Left(mystr, 1)) >= Asc("挖") And Asc(Left(mystr, 1)) < Asc("昔") Then
                Py = "W"
                Exit Function
            End If
            If Asc(Left(mystr, 1)) >= Asc("昔") And Asc(Left(mystr, 1)) < Asc("压") Then
                Py = "X"
                Exit Function
            End If
            If Asc(Left(mystr, 1)) >= Asc("压") And Asc(Left(mystr, 1)) < Asc("匝") Then
                Py = "Y"
                Exit Function
            End If
            If Asc(Left(mystr, 1)) >= Asc("匝") Then
                Py = "Z"
                Exit Function
            End If
        Else
            If UCase(mystr) <= "Z" And UCase(mystr) >= "A" Then
                Py = UCase(Left(mystr, 1))
            Else
                Py = mystr
            End If
        End If

    End Function

    Public Sub Read_ErrorLog()
        Dim MyFile1 As String = "错误日志.txt"

        Try
            If (System.IO.File.Exists(Application.StartupPath + "\" + MyFile1)) = False Then
                MessageBox.Show("无错误日志 ", "信息提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Dim MyReader As New System.IO.StreamReader(Application.StartupPath + "\" + MyFile1,
                                                                                   System.Text.Encoding.UTF8)

            Dim strContents As New ArrayList
            Do While MyReader.Peek() > 0
                strContents.Add(MyReader.ReadLine)

            Loop
            MyReader.Close()

            _PublicTable1 = New DataTable()
            _PublicTable1.Columns.Add("日期", GetType(System.String))
            _PublicTable1.Columns.Add("类型", GetType(System.String))
            _PublicTable1.Columns.Add("位置", GetType(System.String))
            _PublicTable1.Columns.Add("描述事件异常信息", GetType(System.String))
            _PublicTable1.AcceptChanges()

            Dim str日期 As String = ""
            Dim str类型 As String = ""
            Dim str位置 As String = ""
            Dim str描述事件异常信息 As String = ""

            For i As Integer = 0 To strContents.Count - 1
                Dim str_ReadLine As String

                str_ReadLine = strContents.Item(i).ToString
                'MessageBox.Show(i.ToString + "    " + str_ReadLine)
                If Microsoft.VisualBasic.Left(str_ReadLine, 1) = "*" Then

                    Dim split As String() = str_ReadLine.Split("：".ToCharArray())
                    Dim strContents_B As New ArrayList
                    For Each s As String In split
                        If s.Trim() <> Nothing Then
                            strContents_B.Add(s)
                        End If
                    Next
                    'MessageBox.Show(strContents_B.Count.ToString + "    " + str_ReadLine)

                    str日期 = Microsoft.VisualBasic.Left(strContents_B.Item(1).ToString, strContents_B.Item(1).ToString.Length - 2)
                    'MessageBox.Show(str日期)
                    str类型 = Microsoft.VisualBasic.Left(strContents_B.Item(2).ToString, strContents_B.Item(2).ToString.Length - 2)
                    'MessageBox.Show(str类型)

                    str位置 = strContents_B.Item(3).ToString ' Microsoft.VisualBasic.Left(strContents_B.Item(3).ToString, strContents_B.Item(3).ToString.Length - 2)
                    'MessageBox.Show(str位置)

                ElseIf Microsoft.VisualBasic.Left(str_ReadLine, 1) = "-" Then
                    If Not (str日期 = "") Then

                        Dim row As DataRow = _PublicTable1.NewRow()

                        row("日期") = str日期.Trim
                        row("类型") = str类型.Trim
                        row("位置") = str位置.Trim
                        row("描述事件异常信息") = str描述事件异常信息.Trim
                        _PublicTable1.Rows.Add(row)
                        _PublicTable1.AcceptChanges()

                        str日期 = ""
                        str类型 = ""
                        str位置 = ""
                        str描述事件异常信息 = ""
                    End If
                Else
                    If Not (str日期 = "") Then
                        str描述事件异常信息 = str描述事件异常信息 + str_ReadLine + vbCrLf
                    End If
                End If

            Next
            _PublicTable1LabelA = " 错误日志"
            _PublicTable1LabelB = " 错误日志"
            'Dim 搜索结果 As New 搜索结果()
            '搜索结果.Show()
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
            '异常信息显示
            Dim MyInfo As String = vbCrLf + "错误提供程序名称：" + ex.Source
            MyInfo += vbCrLf + "详细信息：" + ex.Message
            Dim Err_type As String, Err_place As String, Err_Accident As String
            Err_type = "系统" 'SQL  PLC  系统
            Err_place = "函数______" + "Read_ErrorLog"
            'Err_place = Me.Name.ToString + "SqlCon______" + "Button2_Click"
            'Err_Accident = ""
            Err_Accident = MyInfo
            Write_ErrorLog(Err_type, Err_place, Err_Accident)

        End Try
    End Sub

    Public Function SaveFile() As String
        '创建原图文件
        Dim MyFileName As String = ""
#Disable Warning IDE0017 ' 简化对象初始化
        Dim MyDlg As New SaveFileDialog ' OpenFileDialog()
#Enable Warning IDE0017 ' 简化对象初始化
        MyDlg.Filter = "图像文件(JPeg,Gif,Bmp,etc.)|*.jpg;*.jpeg;*.gif; *.bmp; " +
                    "*.tif; *.tiff; *.png| JPeg 文件 (*.jpg;*.jpeg)|*.jpg;*.jpeg " +
                    "|GIF 文件 (*.gif)|*.gif |BMP 文件 (*.bmp)|*.bmp|Tiff 文件 " +
                    "(*.tif;*.tiff)|*.tif;*.tiff|Png 文件 (*.png)|" +
                    " *.png|xml文件(xml)|*.xml "
        If (MyDlg.ShowDialog() = Windows.Forms.DialogResult.OK) Then

            MyFileName = MyDlg.FileName
        End If
        Return MyFileName
    End Function

    Public Function SetAVGDataGridCol(ByVal dataGridView As DataGridView, ByVal columnName As String) As String
        'AVG    --DataGridView列求平均值
        If dataGridView.Rows.Count < 1 Then
            Return 0
        Else
            Return SetSUMDataGridCol(dataGridView, columnName) / dataGridView.Rows.Count

        End If
    End Function

    Public Function SetAVGDataTableCol(ByVal dataTable As DataTable, ByVal columnName As String) As String
        'AVG    --dataTable列求平均值
        If dataTable.Rows.Count < 1 Then
            Return 0
        Else
            Return SetSUMDataTabledCol(dataTable, columnName) / dataTable.Rows.Count

        End If
    End Function

    Public Function SetMAXDataGridCol(ByVal dataGridView As DataGridView, ByVal columnName As String) As String
        ' MAX(--DataGridView列求最大值)
        If dataGridView.Rows.Count < 1 Then
            Return 0
        Else
            Dim i As Integer
            Dim sum As Decimal = 0

            For i = 0 To dataGridView.Rows.Count - 1
                If String.IsNullOrEmpty(dataGridView.Rows(i).Cells(columnName).ToString) = False Then
                    If sum < Decimal.Parse(dataGridView.Rows(i).Cells(columnName).ToString) Then
                        sum = Decimal.Parse(dataGridView.Rows(i).Cells(columnName).ToString)
                    End If
                End If
            Next
            Return sum
        End If
    End Function

    Public Function SetMAXDataTableCol(ByVal dataTable As DataTable, ByVal columnName As String) As String
        ' MAX(--dataTable列求最大值)
        If dataTable.Rows.Count < 1 Then
            Return 0
        Else
            Dim i As Integer
            Dim sum As Decimal = 0

            For i = 0 To dataTable.Rows.Count - 1
                If String.IsNullOrEmpty(dataTable.Rows(i).Item(columnName)) = False Then
                    If sum < Decimal.Parse(dataTable.Rows(i).Item(columnName).ToString) Then
                        sum = Decimal.Parse(dataTable.Rows(i).Item(columnName).ToString)
                    End If
                End If
            Next
            Return sum
        End If
    End Function

    Public Function SetMIXDataGridCol(ByVal dataGridView As DataGridView, ByVal columnName As String) As String
        ' MAX(--DataGridView列求最小值)
        If dataGridView.Rows.Count < 1 Then
            Return 0
        Else
            Dim i As Integer
            Dim sum As Decimal = 0

            For i = 0 To dataGridView.Rows.Count - 1
                If String.IsNullOrEmpty(dataGridView.Rows(i).Cells(columnName).ToString) = False Then
                    If sum > Decimal.Parse(dataGridView.Rows(i).Cells(columnName).ToString) Then
                        sum = Decimal.Parse(dataGridView.Rows(i).Cells(columnName).ToString)
                    End If
                End If
            Next
            Return sum
        End If
    End Function

    Public Function SetMIXDataTableCol(ByVal dataTable As DataTable, ByVal columnName As String) As String
        ' MAX(--dataTable列求最小值)
        If dataTable.Rows.Count < 1 Then
            Return 0
        Else
            Dim i As Integer
            Dim sum As Decimal = 0

            For i = 0 To dataTable.Rows.Count - 1
                If String.IsNullOrEmpty(dataTable.Rows(i).Item(columnName)) = False Then
                    If sum > Decimal.Parse(dataTable.Rows(i).Item(columnName).ToString) Then
                        sum = Decimal.Parse(dataTable.Rows(i).Item(columnName).ToString)
                    End If
                End If
            Next
            Return sum
        End If
    End Function

    Public Function SetSUMDataGridCol(ByVal dataGridView As DataGridView, ByVal columnName As String) As String
        'DataGridView列总和
        If dataGridView.Rows.Count < 1 Then
            Return 0
        Else
            Dim i As Integer
            Dim sum As Decimal = 0

            For i = 0 To dataGridView.Rows.Count - 1
                If String.IsNullOrEmpty(dataGridView.Rows(i).Cells(columnName).Value.ToString) = False Then
                    sum += Decimal.Parse(dataGridView.Rows(i).Cells(columnName).Value.ToString)
                End If
            Next
            Return sum
        End If
    End Function

    Public Function SetSUMDataTabledCol(ByVal dataTable As DataTable, ByVal columnName As String) As String
        'DataTable列总和
        If dataTable.Rows.Count < 1 Then
            Return 0
        Else
            Dim i As Integer
            Dim sum As Decimal = 0

            For i = 0 To dataTable.Rows.Count - 1
                If String.IsNullOrEmpty(dataTable.Rows(i).Item(columnName).ToString) = False Then
                    sum += Decimal.Parse(dataTable.Rows(i).Item(columnName).ToString)
                End If
            Next
            Return sum
        End If
    End Function

    Public Sub Txt_To_DataTable(ByVal dt As DataTable, ByVal filename As String)
        Try
            dt.Clear()

            If System.IO.File.Exists(Application.StartupPath + "\" + filename + ".txt") = False Then
                'System.IO.File.Delete(Application.StartupPath + "\" + filename + ".txt")
                Exit Sub
            End If

            Dim MyReader As New System.IO.StreamReader(Application.StartupPath + "\" + filename + ".txt",
                                                                       System.Text.Encoding.UTF8)

            Dim strContents_A As New ArrayList
            Do While MyReader.Peek() > 0
                strContents_A.Add(MyReader.ReadLine)
            Loop
            MyReader.Close()

            For i As Integer = 0 To strContents_A.Count - 1
                Dim words As String = ""

                words = strContents_A.Item(i).ToString
                'MsgBox(i.ToString + words, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "提示信息")
                Dim split As String() = words.Split("|".ToCharArray())
                Dim strContents_B As New ArrayList
                For Each s As String In split
                    'If s = "" Then s = 0
                    If s.Trim() <> Nothing Then
                        strContents_B.Add(s)

                    End If
                Next s
                'MsgBox(strContents_B.Count.ToString, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "提示信息")
                Dim row As DataRow = dt.NewRow()
                For j As Integer = 0 To strContents_B.Count - 1
                    'For k As Integer = 0 To dt.Columns.Count - 1

                    row(dt.Columns(j).ColumnName.ToString) = strContents_B.Item(j).ToString
                    'Next
                Next
                dt.Rows.Add(row)
                dt.AcceptChanges()
            Next
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
            '异常信息显示
            Dim MyInfo As String = vbCrLf + "错误提供程序名称：" + ex.Source
            MyInfo += vbCrLf + "详细信息：" + ex.Message
            Dim Err_type As String, Err_place As String, Err_Accident As String
            Err_type = "系统" 'SQL  PLC  系统
            Err_place = "函数______" + "Txt_To_DataTable"
            'Err_place = Me.Name.ToString + "SqlCon______" + "Button2_Click"
            'Err_Accident = ""
            Err_Accident = MyInfo
            Write_ErrorLog(Err_type, Err_place, Err_Accident)

        End Try

    End Sub

    'VB.net中使用正则表达式验证邮箱地址是否合法
    Public Function ValidateEmail(ByVal addr As String) As Boolean
        Dim reg As New Regex("\w[-\w.+]*@([A-Za-z0-9][-A-Za-z0-9]+\.)+[A-Za-z]{2,14}")
        Return reg.IsMatch(addr)
    End Function

    Public Sub Write_ErrorLog(ByVal Err_type As String, ByVal Err_place As String, ByVal Err_Accident As String)
        Dim MyFile1 As String = "错误日志.txt"

        Try
            If (System.IO.File.Exists(Application.StartupPath + "\" + MyFile1)) = False Then
                Dim MyStream As New System.IO.FileStream(Application.StartupPath + "\" + MyFile1,
                                                                 System.IO.FileMode.Create)
                Dim MyWriter As New System.IO.StreamWriter(MyStream,
                                                System.Text.Encoding.UTF8)

                MyWriter.WriteLine("*日期： " + Now.ToLocalTime + "   类型：" + Err_type + "    位置： " + Err_place)
                MyWriter.WriteLine("描述事件异常信息： ")
                Dim lst As New List(Of String)
                Dim arrs As String() = Err_Accident.Split(vbCrLf)
                lst = arrs.ToList
                For Each x As String In lst
                    MyWriter.WriteLine(x)
                Next
                MyWriter.WriteLine("----------------------------------------------------------------------------- ")
                MyWriter.Close()
            Else

                Dim My1Writer As System.IO.StreamWriter =
                             System.IO.File.AppendText(Application.StartupPath + "\" + MyFile1)

                My1Writer.WriteLine("*日期： " + Now.ToLocalTime + "   类型：" + Err_type + "    位置： " + Err_place)
                My1Writer.WriteLine("描述事件异常信息： ")
                Dim lst As New List(Of String)
                Dim arrs As String() = Err_Accident.Split(vbCrLf)
                lst = arrs.ToList
                For Each x As String In lst
                    My1Writer.WriteLine(x)
                Next
                My1Writer.WriteLine("------------------------------------------------------------------------ ")
                My1Writer.Close()

            End If
            'MessageBox.Show("保存成功！")
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#Disable Warning IDE1006 ' 命名样式
#Disable Warning IDE1006 ' 命名样式
End Module