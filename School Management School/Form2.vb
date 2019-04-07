Imports MySql.Data.MySqlClient
Public Class new_staff
    Dim con As String = "server=localhost;user id=root;database=kariangwe_high"
    Dim connection As New MySqlConnection(con)

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles list_gender.SelectedIndexChanged

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles input_phone.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim name As String = input_name.Text
        Dim surname As String = input_surname.Text
        Dim ec_number As String = input_staffnum.Text
        Dim nat_id As String = input_nationaid.Text
        Dim email As String = input_email.Text
        Dim phone As String = input_phone.Text
        Dim gender As String = list_gender.SelectedItem
        Dim role As String = list_role.SelectedItem
        Dim qualifications As String = input_qualifications.Text


        If (name = "" Or surname = "" Or ec_number = "" Or nat_id = "" Or email = "" Or phone = "" Or gender = "" Or role = "" Or qualifications = "") Then
            lblmessage.Text = "Please fill all the fields"
            lblmessage.Visible = True
        Else
            Dim sql As String = "INSERT INTO staff(Name,Surname,ec_number,National_id,email,phone,gender,role,qualifications) VALUES('" & name & "','" & surname & "','" & ec_number & "','" & nat_id & "','" & email & "','" & phone & "','" & gender & "','" & role & "','" & qualifications & "');"

            Try
                connection.Open()
                Dim Command As MySqlCommand = New MySqlCommand(sql, connection)
                Dim Reader As MySqlDataReader = Command.ExecuteReader
                lblgood.Text = "Staff member successfully added"
                lblmessage.Visible = False
                lblgood.Visible = True

                input_name.ResetText()
                input_surname.ResetText()
                input_staffnum.ResetText()
                input_nationaid.ResetText()
                input_email.ResetText()
                input_phone.ResetText()
                list_gender.ResetText()
                list_role.ResetText()
                input_qualifications.ResetText()

            Catch ex As Exception
                MsgBox(ex.Message())

            Finally
                connection.Close()

            End Try

        End If

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Panel12_Paint(sender As Object, e As PaintEventArgs) Handles Panel12.Paint

    End Sub

    Private Sub Panel9_Paint(sender As Object, e As PaintEventArgs) 

    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub MenuStrip3_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) 

    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub Panel8_Paint(sender As Object, e As PaintEventArgs) 

    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) 

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub Panel7_Paint(sender As Object, e As PaintEventArgs) 

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub TeachersToolStripMenuItem_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

    End Sub

    Private Sub StaffToolStripMenuItem_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) 

    End Sub

    Private Sub Panel11_Paint(sender As Object, e As PaintEventArgs) 

    End Sub

    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub MenuStrip5_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) 

    End Sub

    Private Sub ToolStripMenuItem13_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub ToolStripMenuItem14_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub ToolStripMenuItem15_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub ToolStripMenuItem16_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub Panel10_Paint(sender As Object, e As PaintEventArgs) 

    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub MenuStrip4_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) 

    End Sub

    Private Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub ToolStripMenuItem10_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub ToolStripMenuItem11_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub ToolStripMenuItem12_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) 

    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub MenuStrip2_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) 

    End Sub

    Private Sub SchoolToolStripMenuItem_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub StudentsToolStripMenuItem_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click

    End Sub

    Private Sub input_qualifications_TextChanged(sender As Object, e As EventArgs) Handles input_qualifications.TextChanged

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub list_role_SelectedIndexChanged(sender As Object, e As EventArgs) Handles list_role.SelectedIndexChanged

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub input_nationaid_TextChanged(sender As Object, e As EventArgs) Handles input_nationaid.TextChanged

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub input_email_TextChanged(sender As Object, e As EventArgs) Handles input_email.TextChanged

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub input_surname_TextChanged(sender As Object, e As EventArgs) Handles input_surname.TextChanged

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub input_staffnum_TextChanged(sender As Object, e As EventArgs) Handles input_staffnum.TextChanged

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub input_name_TextChanged(sender As Object, e As EventArgs) Handles input_name.TextChanged

    End Sub

    Private Sub lblmessage_Click(sender As Object, e As EventArgs) Handles lblmessage.Click

    End Sub

    Private Sub lblgood_Click(sender As Object, e As EventArgs) Handles lblgood.Click

    End Sub

    Private Sub SchoolToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles SchoolToolStripMenuItem.Click
        Me.Hide()
    End Sub
End Class