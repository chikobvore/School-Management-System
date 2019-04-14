Imports MySql.Data.MySqlClient
Public Class fees
    Dim con As String = "server=localhost;user id=root;database=kariangwe_high"
    Dim connection As New MySqlConnection(con)

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        login.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try

            Dim term As Integer = list_term.SelectedItem
            Dim year As String = list_year.SelectedItem
            Dim lock As String = Str(term) + Str(year)

            Dim heads(20) As String
            Dim amounts(20) As Integer

            heads(1) = input_2.Text
            If (heads(1) <> Nothing) Then
                amounts(1) = input_2amount.Text
            End If

            heads(0) = input_1.Text
            If (heads(0) <> Nothing) Then
                amounts(0) = input_1_amount.Text
            End If

            heads(2) = input_3.Text
            If (heads(2) <> Nothing) Then
                amounts(2) = input_3amount.Text
            End If

            heads(3) = input_4.Text
            If (heads(3) <> Nothing) Then
                amounts(3) = input_4amount.Text
            End If

            heads(4) = input_5.Text
            If (heads(4) <> Nothing) Then
                amounts(0) = input_5amount.Text
            End If

            Dim total As Double = 0
            Dim fees As Double = 0


            Dim i As Integer = 0

            connection.Open()
            Dim dr As MySqlDataReader
            Dim sql3 As String = "select amount from fee_heads  where lock_key = '" & lock & "'"
            Dim cmd As MySqlCommand = New MySqlCommand(sql3, connection)
            dr = cmd.ExecuteReader()
            If (dr.HasRows()) Then

                While (dr.Read())
                    fees = fees + dr("Amount")
                End While

            End If
            connection.Close()


            While (heads(i) <> "")

                Try
                    MsgBox(heads(i))
                    total = total + fees
                    connection.Open()
                    Dim sql As String = "Insert into fee_heads(fee_head,amount,lock_key) values('" & heads(i) & "','" & amounts(i) & "','" & lock & "')"
                    Dim Command As MySqlCommand = New MySqlCommand(sql, connection)
                    Dim Reader As MySqlDataReader = Command.ExecuteReader
                    total = total + amounts(i)

                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    i = i + 1
                    connection.Close()
                End Try
            End While
            MsgBox("done")


            connection.Open()
            Dim sql5 As String = "update fees_structure set status = 'OLD'"
            Dim Command1 As MySqlCommand = New MySqlCommand(sql5, connection)
            Dim Reader1 As MySqlDataReader = Command1.ExecuteReader
            connection.Close()



            Try
                connection.Open()
                Dim status As String = "current"
                Dim sql1 As String = "insert into fees_structure(amount,term,year,lock_key,status) values('" & total & "','" & term & "','" & year & "','" & lock & "','" & status & "')"
                Dim Command As MySqlCommand = New MySqlCommand(sql1, connection)
                Dim Reader As MySqlDataReader = Command.ExecuteReader
                MsgBox("Fees structure successfully set for " + Str(year) + " term " + Str(term))
                Me.Dispose()

                connection.Close()
            Catch ex As Exception
                MsgBox(ex.Message())
                connection.Close()
                Try

                    connection.Open()
                    Dim sql2 As String = "update fees_structure set amount = '" & total & "',status = 'current' where lock_key = '" & lock & "'"
                    Dim Command As MySqlCommand = New MySqlCommand(sql2, connection)
                    Dim Reader As MySqlDataReader = Command.ExecuteReader
                    MsgBox("Fees structure successfully updated for " + Str(year) + " term " + Str(term))

                    connection.Close()
                    Me.Dispose()

                Catch ex1 As Exception
                    MsgBox(ex1.Message())
                End Try

            End Try

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Me.Dispose()

    End Sub

    Private Sub data_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles data.CellContentClick

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub SchoolToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SchoolToolStripMenuItem.Click
        Me.Dispose()

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles input_2.TextChanged

    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles input_5amount.TextChanged

    End Sub
End Class