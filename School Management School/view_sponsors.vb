Imports MySql.Data.MySqlClient
Public Class view_sponsors
    Dim con As String = "server=localhost;user id=root;database=kariangwe_high"
    Dim connection As New MySqlConnection(con)

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        login.Show()
    End Sub

    Private Sub view_sponsors_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT Name,Surname,Phone,Email,type from sponsor_details"

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

    Private Sub data_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles data.CellContentClick

    End Sub

    Private Sub SchoolToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SchoolToolStripMenuItem.Click
        Me.Hide()
    End Sub
End Class