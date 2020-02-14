Imports System.Data.SqlClient
Public Class Fr用户名编辑

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

    Private Sub SettextboxNull()

        TextBoxID.Text = ""
        TextBox真实姓名.Text = ""
        TextBox用户名.Text = ""
        TextBox密码.Text = ""
        TextBox备注.Text = ""
        RadioButton办公文员.Checked = False
        RadioButton财务出纳.Checked = False
        RadioButton财务会计.Checked = False
        RadioButton产量编辑专职.Checked = False
        RadioButton开送货单专职.Checked = False
        RadioButton基础资料专职.Checked = False
        RadioButton报价合同专职.Checked = False
        RadioButton系统管理员.Checked = False
        RadioButton生产销售.Checked = False
        RadioButton原纸管理专职.Checked = False
        RadioButton总经理.Checked = False
    End Sub

    Private Sub ToolStripMenuItem新建_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem新建.Click
        SettextboxNull()
        TextBoxID.ReadOnly = True
        ToolStripMenuItem保存.Enabled = True
        TextBox真实姓名.Focus()
    End Sub
    Dim strPrivilege As String = ""
    Private Sub ToolStripMenuItem保存_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem保存.Click
        Try
            '--------------------------------------------
            If TextBox用户名.Text = "" Then
                MsgBox(Label1.Text + " 不能为空！", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "提示信息")
                TextBox用户名.Focus()
                TextBox用户名.Select()
                Exit Sub
            End If

            ''Dim SQLString As String = "SELECT * FROM tbUser WHERE 用户名='" & TextBox用户名.Text.ToString.Trim & "' "
            ''Dim SqlHelper As New SqlHelper
            ''Dim dt1 As DataTable = SqlHelper.ExecSelect(SQLString, CommandType.Text)
            ''If dt1.Rows.Count > 0 Then
            ''    MsgBox(TextBox用户名.Text.ToString + " 用户名已注册！", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "提示信息")
            ''    TextBox用户名.Focus()
            ''    Exit Sub
            ''End If
            If TextBox密码.Text = "" Then
                MsgBox(Label2.Text + " 不能为空！", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "提示信息")
                TextBox密码.Focus()
                Exit Sub
            End If
            If TextBox真实姓名.Text = "" Then
                MsgBox("真实姓名 不能为空！", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "提示信息")
                TextBox真实姓名.Focus()
                Exit Sub
            End If

            If ComboBox登录有效吗.Text = "" Then
                MsgBox("登录有效吗 不能为空！", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "提示信息")
                ComboBox登录有效吗.Focus()
                Exit Sub
            End If

            strPrivilege = ""


            If RadioButton办公文员.Checked Then
                strPrivilege = "办公文员"


            ElseIf RadioButton财务出纳.Checked Then
                strPrivilege = "财务出纳"

            ElseIf RadioButton财务会计.Checked Then
                strPrivilege = "财务会计"

            ElseIf RadioButton产量编辑专职.Checked Then
                strPrivilege = "产量编辑专职"

            ElseIf RadioButton开送货单专职.Checked Then

                strPrivilege = "开送货单专职"

            ElseIf RadioButton基础资料专职.Checked Then
                strPrivilege = "基础资料专职"

            ElseIf RadioButton报价合同专职.Checked Then
                strPrivilege = "报价合同专职"

            ElseIf RadioButton系统管理员.Checked Then

                strPrivilege = "系统管理员"
            ElseIf RadioButton生产销售.Checked Then

                strPrivilege = "生产销售"
            ElseIf RadioButton原纸管理专职.Checked Then
                strPrivilege = "原纸管理专职"

            ElseIf RadioButton总经理.Checked Then
                strPrivilege = "总经理"
            Else
                MsgBox("权限设置 不能为空！", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "提示信息")
                Exit Sub
            End If
            '            '---------------------------------------------------------------
            '[usp_tbUser$insupdet]
            '	-- Add the parameters for the stored procedure here
            '    @CMD       NVARCHAR(20),
            '	@用户名  VARCHAR (20) ,
            '	@密码  VARCHAR (20) ,
            '	@真实姓名  NVARCHAR (50) ,
            '	@登录有效吗  VARCHAR (5) ,
            '	@权限  NVARCHAR (50) ,
            '	@备注  NVARCHAR (50)

            Dim SqlHelper1 As New SqlHelper
            Dim paras1 As SqlParameter() =
                {New SqlParameter("@CMD", "INSERT"),
                 New SqlParameter("@用户名", TextBox用户名.Text.Trim.ToString),
                 New SqlParameter("@密码", Encrypt(TextBox密码.Text.Trim.ToString)),
                 New SqlParameter("@真实姓名", TextBox真实姓名.Text.Trim.ToString),
                 New SqlParameter("@登录有效吗", ComboBox登录有效吗.Text.Trim.ToString),
                 New SqlParameter("@权限", strPrivilege),
                 New SqlParameter("@备注", TextBox备注.Text.Trim.ToString)
                 }
            If SqlHelper1.ExecAddDelUpdate("usp_tbUser$insupdet", CommandType.StoredProcedure, paras1) > 0 Then
                MsgBox("保存成功！", MsgBoxStyle.OkOnly, "提示信息")

            Else
                MsgBox("保存失败！", MsgBoxStyle.OkOnly, "提示信息")
            End If




            'Dim _proceName() As String = {"@CMD", "@用户名", "@密码", "@真实姓名", "@登录有效吗", "@权限", "@手机号码", "@QQ号码", "@备注"}
            'Dim _dbType() As SqlDbType = {SqlDbType.NVarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.NVarChar, SqlDbType.VarChar, SqlDbType.NVarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.NVarChar}
            'Dim _values() As Object = {"INSERT", TextBox用户名.Text.Trim, Encrypt(Trim(TextBox密码.Text)), TextBox真实姓名.Text.Trim, ComboBox登录有效吗.Text.Trim, strPrivilege, TextBox手机号码.Text.Trim, TextBoxQQ号码.Text.Trim, TextBox备注.Text}

            'If (wzwsp.DataAccess.ExecuteNoQuery("usp_tbUser$insupdet", _proceName, _dbType, _values)) = 1 Then
            '    MsgBox("保存成功！", MsgBoxStyle.OkOnly, "提示信息")
            '    保存ToolStripButton.Enabled = False
            '    刷新ToolStripButton.PerformClick()

            'Else
            '    MsgBox("保存失败！", MsgBoxStyle.OkOnly, "提示信息")
            'End If

        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub ComboBox登录有效吗_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox登录有效吗.KeyPress
        e.KeyChar = ChrW(0)  '禁止用户在其中输入任何的文字
    End Sub

    Private Sub ToolStripMenuItem刷新_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem刷新.Click

        'Dim SqlHelper As New SqlHelper
        'Dim paras As SqlParameter() = {}
        'Dim dt1 As DataTable = SqlHelper.ExecSelect("pr_tbUser", CommandType.StoredProcedure, paras)
        'MessageBox.Show("选择客户末选择，操作取消！！！" + vbCrLf + dt1.Rows.Count.ToString)

        Dim SQLString As String = " EXEC	 [dbo].[pr_tbUser]" 'SELECT * FROM tbUser 

        Dim SqlHelper As New SqlHelper
        Dim dt1 As DataTable = SqlHelper.ExecSelect(SQLString, CommandType.Text)
        MessageBox.Show("选择客户末选择，操作取消！！！" + vbCrLf + dt1.Rows.Count.ToString)
        DataGridView1.DataSource = dt1
        DataGridViewinfo1()
        MsgBox("导入成功！", MsgBoxStyle.OkOnly, "提示信息")
    End Sub
End Class