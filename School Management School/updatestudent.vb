Imports MySql.Data.MySqlClient
Public Class updatestudent

    Dim con As String = "server=localhost;user id=root;database=kariangwe_high"
    Dim connection As New MySqlConnection(con)
    Private Sub list_sponsor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles list_sponsor.SelectedIndexChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim reg_number As String = input_name.Text
        Dim address As String = input_address.Text

        If (list_sponsor.SelectedItem = "Donors") Then
            Label2.Text = "Donor's Name"
            Label4.Text = "Donor's Contact"
        ElseIf (list_sponsor.SelectedItem = "Scholarship") Then
            Label2.Text = "Scholarship"
            Label4.Text = "Contact Person number"
        Else
            Label2.Visible = False
            Label4.Visible = True
        End If

        Dim sponsor As String = list_sponsor.SelectedItem
        Dim sponsorName As String = TextBox1.Text
        Dim contact As String = TextBox2.Text

        Dim sql As String = "Update students SET Address = '" & address & "' ,
                                            Sponsor = '" & sponsor & "' ,
                                            SponsorName = '" & sponsorName & "',
                                            Sponsorcontact = '" & contact & "'
                                            WHERE student_id = '" & reg_number & "'"

        Try
            connection.Open()
            Dim Command As MySqlCommand = New MySqlCommand(sql, connection)
            Dim Reader As MySqlDataReader = Command.ExecuteReader
            MsgBox("Information successfully updated")
            Me.Dispose()
            view_students.Dispose()


        Catch ex As Exception
            MsgBox(ex.Message())

        Finally
            connection.Close()
        End Try
    End Sub
End Class