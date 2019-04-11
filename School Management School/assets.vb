Imports MySql.Data.MySqlClient
Public Class assets
    Dim con As String = "server=localhost;user id=root;database=kariangwe_high"
    Dim connection As New MySqlConnection(con)
    Private Sub MenuStrip2_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip2.ItemClicked

    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint

    End Sub

    Private Sub SchoolToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SchoolToolStripMenuItem.Click
        Me.Dispose()

    End Sub

    Private Sub assets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim sql As String = " select * from asserts"
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

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        addassert.Show()
        Me.Dispose()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Dispose()
    End Sub
End Class