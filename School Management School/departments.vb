Imports MySql.Data.MySqlClient
Public Class departments
    Dim con As String = "server=localhost;user id=root;database=kariangwe_high"
    Dim connection As New MySqlConnection(con)
    Dim supervisor As String



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles pay.Click
        Dim dpt As String = input_name.Text
        Dim supervisor As String = ListBox1.SelectedItem
        Dim allocation As Double = input_email.Text
        Dim year As String = "2019"
        Dim term As Integer = 1

        Try
            connection.Open()
            Dim sql As String = "insert into allocations(Department,Supervisor,Amount,Year,Term) values ('" & dpt & "','" & supervisor & "','" & allocation & "','" & year & "','" & term & "')"
            Dim Command As MySqlCommand = New MySqlCommand(sql, connection)
            Dim Reader As MySqlDataReader = Command.ExecuteReader
            MsgBox("Department successfully added")
            Me.Hide()
            Form1.Show()

            connection.Close()


        Catch ex As Exception
            MsgBox(ex.Message())

        End Try

    End Sub

    Private Sub departments_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
        End Try



    End Sub

    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub SchoolToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SchoolToolStripMenuItem.Click
        Me.Hide()
    End Sub
End Class