Imports MySql.Data.MySqlClient
Public Class Allocations
    Dim con As String = "server=localhost;user id=root;database=kariangwe_high"
    Dim connection As New MySqlConnection(con)
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        login.Show()
    End Sub

    Private Sub Allocations_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            connection.Open()
            Dim sql As String = "select Name ,Surname,teacher_id FROM staff where Role = 'Teacher'"
            Dim cmd As MySqlCommand = New MySqlCommand(sql, connection)
            Dim dr As MySqlDataReader = cmd.ExecuteReader()

            If (dr.HasRows()) Then
                While (dr.Read())
                    Dim name As String = dr("Name")
                    Dim surname As String = dr("Surname")
                    Dim teacher As String = name + " " + surname
                    ListBox1.Items.Add(teacher)
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

    Private Sub SchoolToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim department As String = input_name.Text
        Dim supervisor As String = ListBox1.SelectedItem
        Dim allocation As String = input_allocation.Text
        Dim term As Integer = list_term.SelectedItem
        Dim year As String = list_year.SelectedItem
        Dim key As String = department + Str(term) + year



        Dim sql As String = "insert into departments(department_name,department_key) values ('" & department & "','" & key & "')"

        Try
            connection.Open()
            Dim Command As MySqlCommand = New MySqlCommand(sql, connection)
            Dim Reader As MySqlDataReader = Command.ExecuteReader
            MsgBox("Department successfully created")
            connection.Close()

            connection.Open()
            Dim sql1 As String = "SELECT Department_id FROM departments WHERE Department_key = '" & key & "'"
            Dim dr As MySqlDataReader
            Dim cmd1 As MySqlCommand = New MySqlCommand(sql1, connection)
            dr = cmd1.ExecuteReader()
            Dim department_id As String = ""

            MsgBox(key)

            If (dr.HasRows()) Then
                While (dr.Read())
                    department_id = dr("Department_id")
                End While
                connection.Close()

                Try
                    connection.Open()
                    Dim sql2 As String = "insert into allocations(Department_id,Supervisor,Amount,Year,Term) values ('" & department_id & "','" & supervisor & "','" & allocation & "','" & year & "','" & term & "')"
                    Dim Command1 As MySqlCommand = New MySqlCommand(sql2, connection)
                    Dim Reader1 As MySqlDataReader = Command1.ExecuteReader
                    MsgBox("Allocation was successfull")
                    Me.Hide()
                    Form1.Show()

                    connection.Close()


                Catch ex As Exception
                    MsgBox("Error 2 : " + ex.Message())

                End Try
            Else
                MsgBox("Intenal application error")
            End If


        Catch ex As Exception
            MsgBox("Error1 : " + ex.Message())

        End Try



    End Sub
End Class