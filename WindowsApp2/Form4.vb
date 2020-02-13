
Imports System.Data.SqlClient

Public Class Form4

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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'MessageBox.Show("选择客户末选择，操作取消！！！" + vbCrLf + Configuration.ConfigurationManager.AppSettings("con").ToString)
        'Dim SQLString1 As String = "SELECT   TOP (100) PERCENT 代码, 代码 + ' │' + 姓名 AS A  FROM      dbo.tb业务员  ORDER BY 代码"
        'Dim SqlHelper As New SqlHelper
        'Dim dt1 As DataTable = SqlHelper.ExecSelect(SQLString1, CommandType.Text)

        Dim SqlHelper As New SqlHelper
        Dim paras As SqlParameter() = {}
        Dim dt1 As DataTable = SqlHelper.ExecSelect("pr_单价表", CommandType.StoredProcedure, paras)

        If dt1.Rows.Count = 0 Then
            MessageBox.Show("无数据可打印！")
            Exit Sub
        End If
        DataGridView1.DataSource = dt1
        DataGridViewinfo1()
        MsgBox("导入成功！", MsgBoxStyle.OkOnly, "提示信息")
    End Sub
    'Public Function InsertIntoTLogin(ByVal Enlogin As Entity.EnLogin) As Boolean

    '    Enlogin.user_computer = System.Environment.MachineName
    '    Enlogin.user_loginDate = DateString
    '    Enlogin.user_loginTime = TimeOfDay

    '    Dim sql As String = "insert into T_Login(userID,loginDate,loginTime,computer)values(@userID,@loginDate,@loginTime,@computer)"
    '    Dim paras As SqlParameter() = {New SqlParameter("@userID", Enlogin.user_userID),
    '                                   New SqlParameter("@loginDate", Enlogin.user_loginDate),
    '                                   New SqlParameter("@loginTime", Enlogin.user_loginTime),
    '                                   New SqlParameter("@computer", Enlogin.user_computer)}

    '    Dim sh As SqlHelper = New SqlHelper
    '    If sh.ExecuteNonQueryCan(sql, CommandType.Text, paras) > 0 Then
    '        Return True
    '    Else
    '        Return False
    '    End If

    'End Function

End Class