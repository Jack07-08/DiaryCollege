Public Class loginpage
    ' Login button click event
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' Hardcoded username and password (for demo purposes)
        Dim validUsername As String = "admin"
        Dim validPassword As String = "password123"

        ' Check if input credentials are valid
        If txtUsername.Text = validUsername And txtPassword.Text = validPassword Then
            ' If valid, hide login form and open MenuForm
            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Hide()
            Dim menuForm As New menupage

            menuForm.ShowDialog()

        Else
            ' If invalid, show error message
            MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub
End Class
