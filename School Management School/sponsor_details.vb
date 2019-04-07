Imports MySql.Data.MySqlClient
Public Class sponsor_details
    Dim con As String = "server=localhost;user id=root;database=kariangwe_high"
    Dim connection As New MySqlConnection(con)

    Public Property sponsor_id = sponsors.id

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim cooperatename As String = input_name.Text
        Dim addess As String = input_address.Text
        Dim email As String = input_email.Text
        Dim phone As String = input_phone.Text
        Dim description As String = input_des.Text

        Try
                Dim sql As String = "INSERT INTO cooperate_description (Representative,Name,Address,Phone,Email,Description) VALUES ('" & sponsor_id & "','" & cooperatename & "','" & addess & "','" & phone & "','" & email & "','" & description & "')"
                connection.Open()
                Dim Command As MySqlCommand = New MySqlCommand(sql, connection)
            Dim Reader As MySqlDataReader = Command.ExecuteReader

            sponsored.Show()
            Me.Dispose()

        Catch ex As Exception
            MsgBox(ex.Message())

        Finally

            connection.Close()
        End Try


    End Sub

    Private Sub SchoolToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SchoolToolStripMenuItem.Click
        Me.Hide()
    End Sub
End Class