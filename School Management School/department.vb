Imports MySql.Data.MySqlClient
Public Class department
    Dim con As String = "server=localhost;user id=root;database=kariangwe_high"
    Dim connection As New MySqlConnection(con)
    Private Sub SchoolToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SchoolToolStripMenuItem.Click
        Me.Hide()
    End Sub

    Private Sub department_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT Term,Department_name, Amount FROM allocations,departments WHERE allocations.Department_id = departments.Department_id"

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
End Class