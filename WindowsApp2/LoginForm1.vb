Public Class LoginForm1

    ' TODO: ������룬��ʹ���ṩ���û���������ִ���Զ���������֤
    ' (����� https://go.microsoft.com/fwlink/?LinkId=35339)��  
    ' ����Զ�������ɸ��ӵ���ǰ�̵߳����壬������ʾ: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' ���� CustomPrincipal ������ִ�������֤�� IPrincipal ʵ�֡�
    ' ���My.User ������ CustomPrincipal �����з�װ�ı�ʶ��Ϣ
    ' ���û�������ʾ����

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Me.Close()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

End Class
