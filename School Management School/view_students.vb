Imports MySql.Data.MySqlClient
Public Class view_students

    Dim con As String = "server=localhost;user id=root;database=kariangwe_high"
    Dim connection As New MySqlConnection(con)
    Private Sub view_students_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT * FROM students"

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

        Dim sql As String = "select Name,Surname,Date_of_Birth,Gender,address,form,student_class FROM students  WHERE Name like '" & search & "'"

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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        login.Show()
    End Sub

    Private Sub StaffToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Hide()
        staff.Show()
    End Sub

    Private Sub StudentsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        MsgBox("you already viewing Students")
    End Sub

    Private Sub SchoolToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SchoolToolStripMenuItem.Click
        Me.Dispose()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click

    End Sub

    Private Sub data_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles data.CellContentClick
        updatestudent.Show()
    End Sub
End Class