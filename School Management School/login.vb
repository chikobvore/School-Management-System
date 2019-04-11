Imports MySql.Data.MySqlClient
Public Class login
    Dim con As String = "server=localhost;user id=root;database=kariangwe_high"
    Dim connection As New MySqlConnection(con)
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles input_username.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        signup.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim username As String
        Dim password As String
        Dim dbpassword As String = ""
        Dim role As String = ""

        username = input_username.Text
        password = input_password.Text

        Try
            connection.Open()
            Dim dr As MySqlDataReader
            Dim sql As String = "select password,role from staff where ec_number = '" & username & "'"
            Dim cmd1 As MySqlCommand = New MySqlCommand(sql, connection)
            dr = cmd1.ExecuteReader()




            If (dr.HasRows()) Then

                While (dr.Read())
                    dbpassword = dr("password")
                    role = dr("role")

                End While
                If (password = dbpassword) Then

                    If (role = "Headmaster") Then
                        Me.Hide()
                        Form1.Show()
                    ElseIf (role = "Deputy") Then
                        Me.Hide()
                        Deputy.Show()
                    ElseIf (role = "Bursar") Then
                        Me.Hide()
                        Bursar.Show()
                    ElseIf (role = "clerk") Then
                        Me.Hide()
                        clerk.Show()

                    Else
                        MsgBox("Invalid credidentals")
                    End If
                Else
                    MsgBox("Invalid password")

                End If
            Else
                MsgBox("Username could not be found")
            End If



        Catch ex As Exception

            MsgBox("We could not found your ec-number")

        Finally
            connection.Close()

        End Try
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        signup.Show()

    End Sub
End Class