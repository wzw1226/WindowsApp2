Module 公共参数
    Public username As String  '定义登录用户名的公用变量
    Public Password As String  '定义登录用户名的密码公用变量
    Public RealName As String '定义登录真实姓名的公用变量
    Public Privilege As String  '定义登录用户名的权限公用变量
    Public CKpassword As String = "" '定义检查密码公用变量
    Public CKhelp As Boolean = True '定义检查显示帮助公用变量
    Public CK123 As Boolean = False  '定义检查是否授权公用变量
    Public _Print一般文件激光打印字机 As String = "" '定义打印的公用变量
    Public _PrintA5横式激光打印机 As String = "" '定义打印的公用变量
    Public _Print单据文件80列针式打印机 As String = "" '定义打印的公用变量
    Public _Print专用条形码打印字机 As String = "" '定义打印的公用变量

    Public _PublicTable1 As DataTable = Nothing '定义DataTable的公用变量
    Public _PublicTable1LabelA As String = "" '定义DataTable标题的公用变量
    Public _PublicTable1LabelB As String = "" '定义DataTable条件的公用变量

    Public _PublicString As String = "" '定义公用String变量

    Public _PublicBiginDate As Date = Today '定义条件的公用变量
    Public _PublicEndDate As Date = Today '定义DataTable条件的公用变量
    Public _PublicMaxN As String = 0 '定义公用变量
    Public _PublicMinN As String = 0 '定义公用变量
    Public _CKDatabase As Boolean = False  '定义检查r数据库授权激活
    Public _CKtimes As Boolean = True   '定义客户端是否要授权激活（True不用激活）
End Module