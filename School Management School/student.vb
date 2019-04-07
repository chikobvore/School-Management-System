Imports MySql.Data.MySqlClient
Public Class student
    Dim con As String = "server=localhost;user id=root;database=kariangwe_high"
    Dim connection As New MySqlConnection(con)
    Private Sub Label9_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub list_gender_SelectedIndexChanged(sender As Object, e As EventArgs) Handles list_sponsor.SelectedIndexChanged
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim name As String = input_name.Text
        Dim surname As String = input_surname.Text
        Dim dob As String = input_dob.Text
        Dim address As String = input_address.Text
        Dim form As Integer = list_form.SelectedItem
        Dim gender As String = list_gender.SelectedItem
        Dim student_class As String = list_class.SelectedItem
        Dim sponsor As String = list_sponsor.SelectedItem

        Dim sql As String = "SELECT * FROM students"

        Try
            Dim adapater As New MySqlDataAdapter(sql, connection)
            Dim table As New DataTable()
            Dim ds As New DataSet

            adapater.Fill(table)
            Dim count As Integer = adapater.Fill(ds, "MY TABLE FROM DB")


            Dim class_letter As String

            If (student_class = "BLUE") Then
                class_letter = "B"
            ElseIf (student_class = "RED") Then
                class_letter = "R"
            Else
                class_letter = "G"
            End If

            Dim num As String = Str(count)
            Dim init As String = "190"

            Dim Id As String = init + num + class_letter
            Id = Id.Replace(" ", "")
            MsgBox("Student successfully added" & vbCrLf & "Registration number :" + Id)
            If (name = "" Or surname = "" Or dob = "" Or address = "" Or gender = "" Or student_class = "" Or sponsor = "") Then
                MsgBox("Please fill all the Fields")
            Else
                Try

                    Dim mysql As String = "INSERT INTO students(Student_id,Name, Surname,Date_of_Birth,Gender,Address,Form,Student_class,Sponsor)
                                VALUES('" & Id & "','" & name & "','" & surname & "','" & dob & "','" & gender & "','" & address & "','" & form & "','" & student_class & "','" & sponsor & "')"
                    connection.Open()
                    Dim Command As MySqlCommand = New MySqlCommand(mysql, connection)
                    Dim Reader As MySqlDataReader = Command.ExecuteReader
                    view_students.Show()
                    Me.Hide()
                Catch ex As Exception
                    MsgBox("Error2" + ex.Message())
                End Try

            End If



        Catch ex As Exception
            MsgBox("Error1" + ex.Message())

        Finally
            connection.Close()
        End Try

        name = ""
        surname = ""
        dob = ""
        address = ""
        gender = ""
        student_class = ""
        sponsor = ""






    End Sub

    Private Sub SchoolToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub StaffToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Hide()
        staff.Show()
    End Sub

    Private Sub list_gender_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles list_gender.SelectedIndexChanged

    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Hide()
        sponsors.Show()
    End Sub

    Private Sub SchoolToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles SchoolToolStripMenuItem.Click
        Me.Hide()
    End Sub
End Class