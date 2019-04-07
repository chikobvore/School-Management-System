Imports MySql.Data.MySqlClient
Public Class sponsors

    Dim con As String = "server=localhost;user id=root;database=kariangwe_high"
    Dim connection As New MySqlConnection(con)


    Public Property id As Integer


    Private Sub sponsors_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SchoolToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub input_name_TextChanged(sender As Object, e As EventArgs) Handles input_name.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim name As String = input_name.Text
        Dim surname As String = input_surname.Text
        Dim email As String = input_email.Text
        Dim phone As String = input_phone.Text
        Dim type As String = list_type.SelectedItem

        If (name = "" Or surname = "" Or email = "" Or phone = "" Or type = "") Then
            MsgBox("Please fill all the details")
        Else
            Try
                Dim sql As String = "insert into sponsor_details(Name,Surname,Email,Phone,Type) VALUES ('" & name & "','" & surname & "','" & email & "', '" & phone & "','" & type & "')"
                connection.Open()
                Dim Command As MySqlCommand = New MySqlCommand(sql, connection)
                Dim Reader As MySqlDataReader = Command.ExecuteReader

                connection.Close()




                If (type = "co-operate") Then

                    Try

                        connection.Open()
                        Dim sql1 As String
                        sql1 = "SELECT sponsor_id FROM sponsor_details  WHERE Email= '" & email & "'"
                        Dim dr As MySqlDataReader

                        Dim cmd As MySqlCommand = New MySqlCommand(sql1, connection)
                        dr = cmd.ExecuteReader()


                        If (dr.HasRows()) Then
                            While (dr.Read())
                                id = dr("sponsor_id")
                            End While
                        End If

                        sponsor_details.Show()


                    Catch ex As Exception

                        MsgBox("Error: " + ex.Message())

                    Finally
                        connection.Close()
                    End Try

                ElseIf (Type = "Individual") Then

                    connection.Open()
                    Dim dr2 As MySqlDataReader
                    Dim sql2 As String = "Select sponsor_id FROM  sponsor_details  WHERE Email = '" & email & "'"
                    Dim cmd2 As MySqlCommand = New MySqlCommand(sql2, connection)
                    dr2 = cmd2.ExecuteReader()
                    If (dr2.HasRows()) Then
                        While (dr2.Read())
                            id = dr2("sponsor_id")
                        End While
                        sponsored.Show()
                        Me.Dispose()

                    Else
                        MsgBox("No results found")
                    End If
                Else

                    sponsor_details.Show()
                End If

            Catch ex As Exception
                MsgBox(ex.Message())

            Finally
                connection.Close()
            End Try
        End If



    End Sub

    Private Sub SchoolToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles SchoolToolStripMenuItem.Click
        Me.Hide()
    End Sub
End Class