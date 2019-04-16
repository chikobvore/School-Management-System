Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Data
Public Class summaries
    Dim con As String = "server=localhost;user id=root;database=kariangwe_high"
    Dim connection As New MySqlConnection(con)
    Private Sub summaries_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT Name,Surname,students.student_id ,amount,purpose,methods,payment_date from payments INNER JOIN students ON students.student_id = payments.student_id"

        Try
            Dim adapater As New MySqlDataAdapter(sql, connection)
            Dim table As New DataTable()
            Dim ds As New DataSet

            adapater.Fill(table)
            data.DataSource = table

            Dim count As Integer = adapater.Fill(ds, "MY TABLE FROM DB")


        Catch ex As Exception
            MsgBox(ex.Message())
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim search As String = input_search.Text

        Dim sql As String = "SELECT student_id,amount,purpose,methods,payment_date,student_class from payments where student_id like '" & search & "' 
                                OR student_class  like'" & search & "'
                                OR  combination like '" & search & "'
                                OR Term like '" & search & "'"


        Try
            connection.Open()
            Dim adapater As New MySqlDataAdapter(sql, connection)
            Dim table As New DataTable()
            Dim ds As New DataSet

            adapater.Fill(table)
            data.DataSource = table
            connection.Close()
            Try
                connection.Open()
                Dim dr As MySqlDataReader
                Dim sql1 As String = "SELECT amount from payments where student_id like '" & search & "'"

                Dim cmd As MySqlCommand = New MySqlCommand(sql1, connection)
                dr = cmd.ExecuteReader()
                Dim total As Double = 0


                If (dr.HasRows()) Then

                    While (dr.Read())
                        total = total + dr("amount")
                    End While


                End If
                connection.Close()

                Label5.Visible = True
                total_balance.Visible = True

                paid_amount.Text = "$ " + Str(total)
                paid_amount.Visible = True
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
                    areas.Text = balance
                    areas.Visible = True

                    connection.Close()

                    connection.Open()
                    Dim dr2 As MySqlDataReader
                    Dim sql3 As String = "Select Name,Surname,form, student_class from students where student_id = '" & search & "'"
                    Dim cmd2 As MySqlCommand = New MySqlCommand(sql3, connection)
                    dr2 = cmd2.ExecuteReader()

                    Dim myname As String = ""
                    Dim surname As String = ""
                    Dim form As String = ""
                    Dim student_class As String = ""

                    If (dr2.HasRows()) Then
                        While (dr2.Read())
                            myname = dr2("Name")
                            surname = dr2("Surname")
                            form = dr2("form")
                            student_class = dr2("student_class")
                        End While


                        name_label.Visible = True
                        my_name.Text = myname + " " + surname
                        my_name.Visible = True

                        form_label.Visible = True
                        my_grade.Text = form + " " + student_class
                        my_grade.Visible = True
                        Button2.Visible = True

                    End If




                Catch ex As Exception
                    MsgBox(ex.Message())
                Finally
                    connection.Close()
                End Try



                areas.Visible = True

            Catch ex As Exception
                MsgBox(ex.Message())

            Finally
                connection.Close()
            End Try




        Catch ex As Exception
            MsgBox(ex.Message())
        Finally
            connection.Close()
        End Try
    End Sub

    Private Sub name_label_Click(sender As Object, e As EventArgs) Handles name_label.Click

    End Sub

    Private Sub SchoolToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SchoolToolStripMenuItem.Click
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sql As String = "SELECT Name,Surname,amount,purpose,methods,payment_date from payments INNER JOIN students ON students.student_id = payments.student_id"

        Try
            Dim adapater As New MySqlDataAdapter(sql, connection)
            Dim table As New DataTable()
            Dim ds As New DataSet

            adapater.Fill(table)
            data.DataSource = table

            Dim count As Integer = adapater.Fill(ds, "MY TABLE FROM DB")

            name_label.Visible = False
            my_name.Visible = False

            form_label.Visible = False
            my_grade.Visible = False


        Catch ex As Exception
            MsgBox(ex.Message())
        End Try

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Try
            Dim newcsvfile As String = String.Empty

            For Each column As DataGridViewColumn In data.Columns
                newcsvfile = newcsvfile & column.HeaderText & ","

            Next

            newcsvfile = newcsvfile.TrimEnd(",")
            newcsvfile = newcsvfile & vbCr & vbLf

            For Each row As DataGridViewRow In data.Rows
                For Each cell As DataGridViewCell In row.Cells

                    newcsvfile = newcsvfile & cell.FormattedValue & ","

                Next

                newcsvfile = newcsvfile.TrimEnd(",")
                newcsvfile = newcsvfile & vbCr & vbLf
            Next
            My.Computer.FileSystem.WriteAllText("../../../payment.csv", newcsvfile, False)
            MsgBox("Report successfully created")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click

    End Sub

    Private Sub ViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewToolStripMenuItem.Click
        Dim sql As String = "SELECT Name,Surname,students.student_id,Paid_amount,Balance from student_portal
                        INNER JOIN students ON students.student_id =  student_portal.student_id WHERE Balance > 0"

        Try
            connection.Open()
            Dim adapater As New MySqlDataAdapter(sql, connection)
            Dim table As New DataTable()
            Dim ds As New DataSet

            adapater.Fill(table)
            data.DataSource = table

            Dim count As Integer = adapater.Fill(ds, "MY TABLE FROM DB")
            connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message())
        End Try



    End Sub
End Class