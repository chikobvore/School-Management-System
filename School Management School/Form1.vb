Imports MySql.Data.MySqlClient
Public Class Form1
    Dim con As String = "server=localhost;user id=root;database=kariangwe_high"
    Dim connection As New MySqlConnection(con)

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        view_sponsors.Show()
    End Sub

    Private Sub ToolStripMenuItem13_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem13.Click

    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        login.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        student.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        new_staff.Show()
    End Sub

    Private Sub StaffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StaffToolStripMenuItem.Click
        staff.Show()
    End Sub

    Private Sub StudentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StudentsToolStripMenuItem.Click
        view_students.Show()
    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint

    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        sponsors.Show()
    End Sub

    Private Sub Panel9_Paint(sender As Object, e As PaintEventArgs) Handles Panel9.Paint

    End Sub

    Private Sub ToolStripMenuItem12_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click
        departments.Show()
    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click
        manager.Show()
    End Sub

    Private Sub BalanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BalanToolStripMenuItem.Click

    End Sub

    Private Sub ToolStripMenuItem14_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        Allocations.Show()
    End Sub

    Private Sub ToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem10.Click
        fees.Show()
    End Sub

    Private Sub TeachersToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs)
        MsgBox("dont forget me")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        department.Show()
    End Sub

    Private Sub GoodsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GoodsToolStripMenuItem.Click
        goods.Show()
    End Sub

    Private Sub FundsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FundsToolStripMenuItem.Click
        sponsoredfunds.Show()

    End Sub

    Private Sub ServicesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ServicesToolStripMenuItem.Click
        sponsoredservices.Show()
    End Sub

    Private Sub TransfersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransfersToolStripMenuItem.Click
        Transfers.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Term.Show()
    End Sub

    Private Sub ToolStripMenuItem15_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem15.Click
        statistics.Show()
    End Sub

    Private Sub ReportsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportsToolStripMenuItem.Click
        reports.Show()
    End Sub
End Class
