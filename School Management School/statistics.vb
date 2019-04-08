Imports MySql.Data.MySqlClient
Public Class statistics
    Dim con As String = "server=localhost;user id=root;database=kariangwe_high"
    Dim connection As New MySqlConnection(con)
    Private Sub SchoolToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SchoolToolStripMenuItem.Click
        Me.Dispose()

    End Sub

    Private Sub statistics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dr2 As MySqlDataReader
        Dim sql As String = "select Gender,form , sponsor from students"
        Dim gender As String = ""
        Dim males As Integer = 0
        Dim females As Integer = 0
        Dim form1 As Integer = 0
        Dim form2 As Integer = 0
        Dim form3 As Integer = 0
        Dim form4 As Integer = 0
        Dim form5 As Integer = 0
        Dim form6 As Integer = 0
        Dim graduates As Integer = 0
        Dim sponsor As Integer = 0
        Dim Parent As Integer = 0
        Dim donors As Integer = 0


        Try
            connection.Open()

            Dim cmd As MySqlCommand = New MySqlCommand(sql, connection)
            dr2 = cmd.ExecuteReader()


            If (dr2.HasRows()) Then

                While (dr2.Read())
                    gender = dr2("Gender")
                    If (gender = "Male") Then
                        males = males + 1
                        my_name.Text = Str(males)
                    Else
                        females = females + 1
                        my_grade.Text = Str(females)
                    End If

                    If (dr2("form") = 1) Then
                        form1 = form1 + 1
                        paid_amount.Text = form1

                    ElseIf (dr2("form") = 2) Then
                        form2 = form2 + 1
                        Label10.Text = form2

                    ElseIf (dr2("form") = 3) Then
                        form3 = form3 + 1
                        Label8.Text = form3
                    ElseIf (dr2("form") = 4) Then
                        form4 = form4 + 1
                        Label6.Text = form4
                    ElseIf (dr2("form") = 5) Then
                        form5 = form5 + 1
                        Label2.Text = form5
                    ElseIf (dr2("form") = 6) Then
                        form6 = form6 + 1
                        Label12.Text = form6
                    Else
                        graduates = graduates + 1
                        Label16.Text = graduates
                    End If

                    If (dr2("sponsor") = "Parent") Then
                        Parent = Parent + 1
                    ElseIf (dr2("sponsor") = "Donor") Then
                        donors = donors + 1
                    Else
                        donors = donors + 1
                    End If




                End While
            End If
            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub
End Class