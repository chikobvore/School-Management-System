Imports MySql.Data.MySqlClient
Public Class signup
    Dim con As String = "server=localhost;user id=root;database=kariangwe_high"
    Dim connection As New MySqlConnection(con)
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim email As String = input_email.Text
        Dim ec_number As String = input_id.Text
        Dim p1 As String = input_p1.Text
        Dim p2 As String = input_p2.Text

        If (p1 = p2) Then

            Try
                connection.Open()
                Dim sql As String = "update staff set password = '" & p1 & "' where ec_number = '" & ec_number & "' and email = '" & email & "'"
                Dim Command As MySqlCommand = New MySqlCommand(sql, connection)
                Dim Reader As MySqlDataReader = Command.ExecuteReader
                Me.Hide()
                login.Show()
            Catch ex As Exception

                MsgBox("Sorry  we could not verify your credidentals" + ex.Message)

            Finally
                connection.Close()
            End Try
        Else
            MsgBox("Passwords mismatch !")
        End If




    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        login.Show()
    End Sub
End Class