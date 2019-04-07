Imports MySql.Data.MySqlClient
Public Class manager
    Dim con As String = "server=localhost;user id=root;database=kariangwe_high"
    Dim connection As New MySqlConnection(con)
    Private Sub manager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "select Year,Term,department,Supervisor,Amount FROM allocations"


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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        login.Show()
    End Sub

    Private Sub SchoolToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SchoolToolStripMenuItem.Click
        Me.Hide()
    End Sub
End Class