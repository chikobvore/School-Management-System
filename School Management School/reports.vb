Public Class reports
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Dispose()
        Form1.Dispose()
        login.Show()
    End Sub

    Private Sub CrystalReportViewer1_Load(sender As Object, e As EventArgs) Handles CrystalReportViewer1.Load
        MsgBox("Error retrieving information from dataset")
    End Sub
End Class