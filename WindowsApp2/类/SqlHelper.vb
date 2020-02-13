'Imports System.Configuration
Imports System.Data.SqlClient
''' <summary>
''' 对数据库的增删改查
''' </summary>
''' <remarks></remarks>
Public Class SqlHelper

    Private Shared ReadOnly DatabaseServer As String = Configuration.ConfigurationManager.AppSettings("DatabaseServer").ToString

    Private Shared ReadOnly Database As String = Configuration.ConfigurationManager.AppSettings("Database").ToString
    Private Shared ReadOnly DatabaseUser As String = Configuration.ConfigurationManager.AppSettings("DatabaseUser").ToString
    Private Shared ReadOnly DatabasePassword As String = Configuration.ConfigurationManager.AppSettings("DatabasePassword").ToString

    Public Shared constr As String = "Initial Catalog=" + Database _
                                       + ";Data Source=" + DatabaseServer _
                                       + ";User ID=" + DatabaseUser _
                                       + ";Password=" + DatabasePassword
    'Private Shared con As SqlConnection = New SqlConnection(constr)

    Dim sqlcon As SqlConnection = New SqlConnection(constr)
    Dim cmd As New SqlClient.SqlCommand '使用command对象执行命令并返回
    ''' <summary>
    ''' 执行增删改三个操作，有参数
    ''' </summary>
    ''' <param name="cmdText"></param>
    ''' <param name="cmdType"></param>
    ''' <param name="sqlParams"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ExecAddDelUpdate(ByVal cmdText As String, ByVal cmdType As String, ByVal sqlParams As SqlParameter()) As Integer
        cmd.Parameters.AddRange(sqlParams) '将参数传入
        cmd.CommandType = cmdType
        cmd.Connection = sqlcon   '设置连接
        cmd.CommandText = cmdText
        Try
            sqlcon.Open()  '打开连接
            Return cmd.ExecuteNonQuery()  '执行增删改
            cmd.Parameters.Clear()  '清除参数

        Catch ex As Exception
            Return 0
        Finally
            Call CloseCon(sqlcon)
            Call CloseCmd(cmd)

        End Try
    End Function
    ''' <summary>
    ''' 执行增删改，无参数
    ''' </summary>
    ''' <param name="cmdText"></param>
    ''' <param name="cmdType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ExecAddDelUpdate(ByVal cmdText As String, ByVal cmdType As String) As Integer
        cmd.CommandText = cmdText
        cmd.CommandType = cmdType
        cmd.Connection = sqlcon
        Try
            sqlcon.Open()
            Return cmd.ExecuteNonQuery()
        Catch ex As Exception
            Return 0
        Finally
            Call CloseCon(sqlcon)
            Call CloseCmd(cmd)
        End Try
    End Function
    ''' <summary>
    ''' 执行查询，有参数
    ''' </summary>
    ''' <param name="cmdText"></param>
    ''' <param name="cmdType"></param>
    ''' <param name="sqlParams"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ExecSelect(ByVal cmdText As String, ByVal cmdType As String, ByVal sqlParams As SqlParameter()) As DataTable
        Dim sqlAdapter As SqlDataAdapter
        Dim dt As New DataTable
        Dim ds As New DataSet

        cmd.CommandText = cmdText
        cmd.CommandType = cmdType
        cmd.Connection = sqlcon
        cmd.Parameters.AddRange(sqlParams)
        sqlAdapter = New SqlDataAdapter(cmd)

        Try

            sqlAdapter.Fill(ds) '填充dataset
            dt = ds.Tables(0)  'dt为dataset的第一个表
            cmd.Parameters.Clear()
        Catch ex As Exception
            Return Nothing
        Finally
            Call CloseCmd(cmd)
        End Try
        Return dt
    End Function
    ''' <summary>
    ''' 执行查询，无参数
    ''' </summary>
    ''' <param name="cmdText"></param>
    ''' <param name="cmdType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ExecSelect(ByRef cmdText As String, ByVal cmdType As String) As DataTable
        Dim sqlAdapter As SqlDataAdapter
        Dim ds As New DataSet
        cmd.CommandText = cmdText
        cmd.CommandType = cmdType
        cmd.Connection = sqlcon
        sqlAdapter = New SqlDataAdapter(cmd)

        Try
            sqlAdapter.Fill(ds)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
        Finally
            Call CloseCmd(cmd)
        End Try
    End Function
    ''' <summary>
    ''' 关闭数据库连接
    ''' </summary>
    ''' <param name="con"></param>
    ''' <remarks></remarks>
    Public Sub CloseCon(ByVal con As SqlConnection)
        If (con.State <> ConnectionState.Closed) Then
            con.Close()
            con = Nothing
        End If
    End Sub
    ''' <summary>
    ''' 关闭命令
    ''' </summary>
    ''' <param name="cmd"></param>
    ''' <remarks></remarks>
    Public Sub CloseCmd(ByVal cmd As SqlCommand)
        If Not IsNothing(cmd) Then
            cmd.Dispose()
            cmd = Nothing
        End If
    End Sub
End Class
'————————————————
'版权声明： 本文为CSDN博主「飞蛾飞吧」的原创文章，遵循 CC 4.0 BY-SA 版权协议，转载请附上原文出处链接及本声明。
'原文链接： https : //blog.csdn.net/jin870132690/article/details/41597067