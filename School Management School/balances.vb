Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Data
Public Class balances
    Dim con As String = "server=localhost;user id=root;database=kariangwe_high"
    Dim connection As New MySqlConnection(con)
    Private Sub Balances_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
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
            My.Computer.FileSystem.WriteAllText("Balances.csv", newcsvfile, False)
            MsgBox("Report successfully created")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SchoolToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SchoolToolStripMenuItem.Click
        Me.Dispose()
    End Sub
End Class