Public Class Form5

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim picture As Image
        If My.Computer.Clipboard.ContainsImage() Then
            picture = My.Computer.Clipboard.GetImage
        End If
        PictureBox1.Image = picture
    End Sub

End Class