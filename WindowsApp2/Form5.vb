Public Class Form5
    Dim dt_name As DataTable

    Public Sub set_dt()

        dt_name = New DataTable()

        Dim col As DataColumn = dt_name.Columns.Add("序号", GetType(System.Int32))
        col.AutoIncrement = True
        col.AutoIncrementSeed = 0
        col.AutoIncrementStep = 1
        col.ReadOnly = True

        dt_name.Columns.Add("交货日期", GetType(System.DateTime))

        dt_name.Columns.Add("客户编码", GetType(System.String))

        dt_name.Columns.Add("类别", GetType(System.String))

        dt_name.Columns.Add("商品代号", GetType(System.String))
        dt_name.Columns.Add("商品", GetType(System.String))

        dt_name.Columns.Add("尺寸宽", GetType(System.Int16))
        dt_name.Columns.Add("尺寸长", GetType(System.Int16))

        dt_name.Columns.Add("单位名称", GetType(System.String))

        dt_name.Columns.Add("吨单价", GetType(System.Decimal))

        dt_name.Columns.Add("订货数", GetType(System.Int16))

        dt_name.Columns.Add("用纸代号", GetType(System.String))
        dt_name.Columns.Add("用纸", GetType(System.String))

        dt_name.Columns.Add("生产纸度", GetType(System.Int16))

        dt_name.Columns.Add("区域名称", GetType(System.String))

        dt_name.Columns.Add("送货地址", GetType(System.String))

        dt_name.Columns.Add("备注", GetType(System.String))

        dt_name.PrimaryKey = New DataColumn() {dt_name.Columns("序号")}

        dt_name.AcceptChanges()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim picture As Image
        If My.Computer.Clipboard.ContainsImage() Then
            picture = My.Computer.Clipboard.GetImage
        End If
        PictureBox1.Image = picture
        TextBox1.Text = picture.GetHashCode.ToString
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress

        e.KeyChar = ChrW(0)  '禁止用户在其中输入任何的文字

    End Sub

End Class