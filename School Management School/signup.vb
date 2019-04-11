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
                Dim dr0 As MySqlDataReader
                Dim sql0 As String = "select * FROM staff where  ec_number = '" & ec_number & "' AND email = '" & email & "'"
                Dim cmd As MySqlCommand = New MySqlCommand(sql0, connection)
                dr0 = cmd.ExecuteReader()
                Dim total As Double = 0


                If (dr0.HasRows()) Then
                    connection.Close()

                    connection.Open()

                    Dim sql As String = "update staff set password = '" & p1 & "' where ec_number = '" & ec_number & "' and email = '" & email & "'"
                    Dim Command As MySqlCommand = New MySqlCommand(sql, connection)
                    Dim Reader As MySqlDataReader = Command.ExecuteReader
                    connection.Close()
                    Me.Hide()
                    login.Show()
                Else
                    connection.Close()
                    MsgBox("Credidentals not found")
                End If


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