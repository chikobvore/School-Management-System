Imports MySql.Data.MySqlClient
Public Class goods
    Dim con As String = "server=localhost;user id=root;database=kariangwe_high"
    Dim connection As New MySqlConnection(con)
    Private Sub goods_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim sql As String = "select Name,Surname,Email,Phone,sponsor_details.type,item,description FROM sponsor_details, sponsored_items WHERE sponsor_details.sponsor_id = sponsored_items.sponsor_id"
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

    Private Sub SchoolToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SchoolToolStripMenuItem.Click
        Me.Dispose()
    End Sub
End Class