Imports MySql.Data.MySqlClient
Public Class expense
    Dim con As String = "server=localhost;user id=root;database=kariangwe_high"
    Dim connection As New MySqlConnection(con)
    Private Sub SchoolToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SchoolToolStripMenuItem.Click
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            Dim department As String = list_dpt.SelectedItem
            Dim amount As Double = input_amount.Text
            Dim purpose As String = input_purpose.Text
            Dim method As String = list_method.SelectedItem
            Dim ec_number As String = input_ecnumber.Text
            Dim dpt_id As String = ""

            Try
                connection.Open()
                Dim dr As MySqlDataReader
                Dim sql As String = "select department_id from departments where department_name = '" & department & "'"
                Dim cmd As MySqlCommand = New MySqlCommand(sql, connection)
                dr = cmd.ExecuteReader()
                If (dr.HasRows()) Then
                    While (dr.Read())
                        dpt_id = dr("department_id")
                    End While
                    MsgBox("Matching Department id : " + Str(dpt_id))

                    connection.Close()

                Else
                    MsgBox("The department could not be found")

                End If
            Catch ex As Exception
                MsgBox("Error1 : " + ex.Message())
            End Try


            connection.Open()
            Dim dr1 As MySqlDataReader
            Dim sql1 As String = "select Amount from  withdraws where department_id = '" & dpt_id & "'"
            Dim cmd1 As MySqlCommand = New MySqlCommand(sql1, connection)
            dr1 = cmd1.ExecuteReader()

            Dim total As Double = 0

            If (dr1.HasRows()) Then
                While (dr1.Read())
                    total = total + dr1("Amount")
                End While
            End If
            MsgBox("Total withdraws: " + Str(total))
            connection.Close()


            Try
                connection.Open()
                Dim dr2 As MySqlDataReader
                Dim sql2 As String = "Select Amount FROM allocations WHERE Department_id = '" & dpt_id & "'"
                Dim cmd2 As MySqlCommand = New MySqlCommand(sql2, connection)
                dr2 = cmd2.ExecuteReader()

                Dim allocated As Double = 0

                If (dr2.HasRows()) Then
                    While (dr2.Read())
                        allocated = dr2("Amount")
                    End While

                    MsgBox("Allocated : " + Str(allocated))
                    connection.Close()

                    If (allocated = total) Then
                        MsgBox("Department has reached its Maximum withdrawals")
                    Else
                        Dim available As Double = 0
                        available = allocated - total

                        If (amount > available) Then
                            MsgBox("You cannot withdraw amount greater than " + Str(available))
                        Else
                            connection.Open()
                            Dim timeStamp As DateTime = DateTime.Now
                            Dim sql4 As String = "Insert into withdraws (Transaction_date,department_id,Amount,Purpose,Mathod)Values('" & timeStamp & "','" & dpt_id & "','" & amount & "','" & purpose & "','" & method & "')"
                            Dim Command As MySqlCommand = New MySqlCommand(sql4, connection)
                            Dim Reader As MySqlDataReader = Command.ExecuteReader
                            MsgBox("Withdrawal was successfull")
                            connection.Close()
                            Me.Dispose()
                            Me.Hide()

                        End If
                    End If
                Else
                    MsgBox("You cannot withdraw from an un allocated department")
                End If



            Catch ex As Exception
                MsgBox("here:" + ex.Message())
            End Try

        Catch ex As Exception
            MsgBox("Invalid amount")
        End Try




    End Sub

    Private Sub expense_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            connection.Open()
            Dim sql As String = "select Department_name FROM departments"
            Dim cmd As MySqlCommand = New MySqlCommand(sql, connection)
            Dim dr As MySqlDataReader = cmd.ExecuteReader()

            If (dr.HasRows()) Then
                While (dr.Read())
                    Dim name As String = dr("Department_name")
                    list_dpt.Items.Add(name)
                End While
            Else
                MsgBox("No coordinators found")
            End If
            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message())

        Finally
            connection.Close()
        End Try

    End Sub
End Class