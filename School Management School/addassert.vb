Imports MySql.Data.MySqlClient
Public Class addassert
    Dim con As String = "server=localhost;user id=root;database=kariangwe_high"
    Dim connection As New MySqlConnection(con)

    Private Sub SchoolToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SchoolToolStripMenuItem.Click
        Me.Dispose()

    End Sub

    Private Sub pay_Click(sender As Object, e As EventArgs) Handles pay.Click
        Dim assert_name As String = input_name.Text
        Dim quantity As Integer = input_quantity.Text
        Dim purchased As DateTime = DateTime.Now
        Dim allocation As String = input_allocation.Text

        Try
            connection.Open()
            Dim sql As String = "INSERT INTO asserts(assert_name,Quantity,Purchased_date,allocation) VALUES('" & assert_name & "','" & quantity & "','" & purchased & "',
                            '" & allocation & "')"

            Dim Command As MySqlCommand = New MySqlCommand(sql, connection)
            Dim Reader As MySqlDataReader = Command.ExecuteReader
            MsgBox("Property successfully added")
            Me.Dispose()
            assets.Show()



        Catch ex As Exception
            MsgBox(ex.Message)

        Finally

            connection.Close()

        End Try


    End Sub

    Private Sub input_quantity_TextChanged(sender As Object, e As EventArgs) Handles input_quantity.TextChanged

    End Sub
End Class