Imports MySql.Data.MySqlClient
Public Class overview

    Dim con As String = "server=localhost;user id=root;database=kariangwe_high"
    Dim connection As New MySqlConnection(con)
    Private Sub Overview_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim sql As String = "SELECT Fee_head, Fee_heads.Amount FROM Fee_heads 
                                                    INNER JOIN fees_structure ON fee_heads.lock_key = fees_structure.lock_key"
        Try
            connection.Open()
            Dim adapater As New MySqlDataAdapter(sql, connection)
            Dim table As New DataTable()
            Dim ds As New DataSet

            adapater.Fill(table)
            data.DataSource = table

            Dim count As Integer = adapater.Fill(ds, "MY TABLE FROM DB")
            connection.Close()

            connection.Open()
            Dim amount As Double = 0
            Dim Year As String = String.Empty
            Dim newterm As String = String.Empty

            Dim dr2 As MySqlDataReader
            Dim sql1 As String = "SELECT AMOUNT,Year,Term FROM fees_structure WHERE status = 'current'"
            Dim cmd2 As MySqlCommand = New MySqlCommand(sql1, connection)
            dr2 = cmd2.ExecuteReader()

            If (dr2.HasRows()) Then
                While (dr2.Read())
                    amount = dr2("Amount")
                    Year = dr2("Year")
                    newterm = dr2("Term")

                End While
            End If

            name_label.Visible = True
            my_name.Text = "$" & " " & Str(amount)
            my_name.Visible = True

            form_label.Visible = True
            my_grade.Text = Year & "  Term  " & newterm
            my_grade.Visible = True
            Button2.Visible = True

            connection.Close()





        Catch ex As Exception
            MsgBox(ex.Message())
        End Try

    End Sub
End Class