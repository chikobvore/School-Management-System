Imports MySql.Data.MySqlClient
Public Class Transfers
    Dim con As String = "server=localhost;user id=root;database=kariangwe_high"
    Dim connection As New MySqlConnection(con)
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ID As String = input_search.Text
        Dim old_form As Integer = ListBox1.SelectedItem
        Dim old_class As String = ListBox2.SelectedItem
        Dim new_form As Integer = ListBox3.SelectedItem
        Dim new_class As String = ListBox4.SelectedItem

        Dim name As String = " "
        Dim surname As String = " "
        Dim dob As String = " "
        Dim Gender As String = " "
        Dim form As Integer = 0
        Dim student_class As String = " "
        Try
            connection.Open()
            Dim sql As String = "SELECT Name,Surname,Date_of_Birth,Gender,form,student_class FROM students  WHERE student_id = '" & ID & "'"
            Dim cmd As MySqlCommand = New MySqlCommand(sql, connection)
            Dim dr As MySqlDataReader = cmd.ExecuteReader()

            If (dr.HasRows()) Then
                While (dr.Read())
                    name = dr("Name")
                    surname = dr("Surname")
                    dob = dr("Date_of_Birth")
                    Gender = dr("Gender")
                    form = dr("form")
                    student_class = dr("student_class")
                End While
                connection.Close()
                Dim fullname As String = name + " " + surname
                If (old_form = form) Then
                    If (old_class = student_class) Then
                        Try

                            Dim sql1 As String = "UPDATE students SET form = '" & new_form & "',student_class = '" & new_class & "' WHERE student_id = '" & ID & "'"
                            connection.Open()
                            Dim Command As MySqlCommand = New MySqlCommand(sql1, connection)
                            Dim Reader As MySqlDataReader = Command.ExecuteReader
                            MsgBox("Student:" + fullname + "Gender: " + Gender + " D.O.B: " + dob + "successfully transfered")
                            connection.Close()

                            view_students.Show()
                            Me.Dispose()

                        Catch ex As Exception
                            MsgBox("Failed to Transfer Student")
                        End Try
                    Else
                        MsgBox("classes do not match")

                    End If
                Else
                    MsgBox("Invalid Student details")

                End If
            Else
                MsgBox("Student Not found")

            End If

        Catch ex As Exception

        End Try





    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub
End Class