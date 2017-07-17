Partial Class Form1
    Dim msgFrom, msgTo, msgSubject, msgBody, strStatus As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        MsgBox.Text = ""
        MsgBox.Update()

        'Declare a proxy object'
        Dim pxyWebEmail As localhost.WebMailService = New localhost.WebMailService()
        'Add if required login'
        'pxyWebEmail.Credentials = System.Net.CredentialCache.DefaultCredentials'

        msgFrom = txtFrom.Text
        msgTo = txtTo.Text
        msgSubject = txtSubject.Text
        msgBody = txtBody.Text

        strStatus = pxyWebEmail.Send(msgFrom, msgTo, msgSubject, msgBody)

        If (strStatus = "OK") Then
            MsgBox.Text = "Email is sent successfully"
        Else
            MsgBox.Text = "Error " + strStatus
        End If

        MsgBox.Update()
    End Sub
End Class
