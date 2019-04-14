Imports MySql.Data.MySqlClient
Public Class payment
    Dim con As String = "server=localhost;user id=root;database=kariangwe_high"
    Dim connection As New MySqlConnection(con)
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            Dim student_class As String = ListBox2.SelectedItem
            Dim term As String = ListBox1.SelectedItem
            Dim reg_num As String = input_regnum.Text
            Dim amount As Integer = input_amount.Text
            Dim purpose As String = list_purpose.SelectedItem
            Dim payment As String = list_payment.SelectedItem

            Dim combination As String = term + student_class
            Try
                Dim timeStamp As DateTime = DateTime.Now
                MsgBox(timeStamp)
                Dim sql As String = "insert into payments(student_id,amount,purpose,methods,payment_date, student_class,Term,combination)
                                        Values (
                                                '" & reg_num & "',
                                                '" & amount & "',
                                                '" & purpose & "',
                                                '" & payment & "',
                                                '" & timeStamp & "',
                                                '" & student_class & "',
                                                '" & term & "',
                                                '" & combination & "'
                                                )"
                connection.Open()
                Dim Command As MySqlCommand = New MySqlCommand(sql, connection)
                Dim Reader As MySqlDataReader = Command.ExecuteReader
                connection.Close()

                Try
                    connection.Open()
                    Dim dr As MySqlDataReader
                    Dim sql1 As String = "SELECT amount from payments where student_id like '" & reg_num & "'"

                    Dim cmd As MySqlCommand = New MySqlCommand(sql1, connection)
                    dr = cmd.ExecuteReader()
                    Dim total As Double = 0


                    If (dr.HasRows()) Then

                        While (dr.Read())
                            total = total + dr("amount")
                        End While


                    End If
                    connection.Close()

                    Try
                        connection.Open()
                        Dim dr1 As MySqlDataReader
                        Dim current As String = "current"
                        Dim sql2 As String = "SELECT amount from fees_structure where status = '" & current & "'"

                        Dim cmd1 As MySqlCommand = New MySqlCommand(sql2, connection)
                        dr1 = cmd1.ExecuteReader()

                        Dim amount1 As Double = 0


                        If (dr1.HasRows()) Then

                            While (dr1.Read())
                                amount1 = dr1("amount")
                            End While
                        End If
                        Dim balance As Double
                        balance = amount1 - total
                        connection.Close()

                        Try
                            connection.Open()
                            Dim sql3 As String = "INSERT INTO student_portal(student_id,Paid_amount,Balance)VALUES('" & reg_num & "','" & total & "', '" & balance & "')"
                            Dim Command1 As MySqlCommand = New MySqlCommand(sql3, connection)
                            Dim Reade1r As MySqlDataReader = Command1.ExecuteReader
                            connection.Close()
                        Catch ex As Exception
                            connection.Close()
                            connection.Open()
                            Dim sql4 As String = "UPDATE student_portal SET Paid_amount = '" & total & "' ,Balance = '" & balance & "' WHERE student_id = '" & reg_num & "'"
                            Dim Command1 As MySqlCommand = New MySqlCommand(sql4, connection)
                            Dim Reade1r As MySqlDataReader = Command1.ExecuteReader
                            connection.Close()
                        End Try

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try




                Me.Dispose()
                summaries.Show()
                MsgBox("Payment was successfull")
            Catch ex As Exception
                MsgBox("Payment Failed" & ex.Message())

            Finally
                connection.Close()
            End Try


        Catch ex As Exception
            MsgBox("Invalid inputs")
        End Try

    End Sub

    Private Sub SchoolToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SchoolToolStripMenuItem.Click
        Me.Hide()
    End Sub

    Private Sub payment_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim mystatus As String = "current"
        Dim lock_key As String = ""

        connection.Open()
        Dim dr2 As MySqlDataReader
        Dim sql2 As String = "select lock_key from fees_structure where  status = '" & mystatus & "'"
        Dim cmd As MySqlCommand = New MySqlCommand(sql2, connection)
        dr2 = cmd.ExecuteReader()

        If (dr2.HasRows()) Then

            While (dr2.Read())
                lock_key = dr2("lock_key")
            End While
        End If

        connection.Close()
        connection.Open()

        Dim dr As MySqlDataReader

        Dim sql As String = "select Fee_head from fee_heads where lock_key = '" & lock_key & "'"
        Dim cmd1 As MySqlCommand = New MySqlCommand(sql, connection)
        dr = cmd1.ExecuteReader()

        If (dr.HasRows()) Then

            While (dr.Read())
                list_purpose.Items.Add(dr("Fee_head"))

            End While
            list_purpose.Items.Add("Pay all")
        End If
        connection.Close()
    End Sub

    Private Sub Data_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles data.CellContentClick

    End Sub
End Class