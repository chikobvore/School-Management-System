Imports MySql.Data.MySqlClient
Public Class sponsored
    Dim con As String = "server=localhost;user id=root;database=kariangwe_high"
    Dim connection As New MySqlConnection(con)
    Public Property sponsor_id = sponsors.id

    Private Sub list_sponsor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles list_type.SelectedIndexChanged
        If (list_type.SelectedItem = "Money") Then
            lbl2.Text = "Amount"
        ElseIf (list_type.SelectedItem = "Goods") Then
            lbl2.Text = "Goods"
        Else
            lbl2.Text = "Service"
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim type As String = list_type.SelectedItem
        Dim amount As String = input_money.Text
        Dim description As String = input_more.Text

        If (type = "Money") Then

            Try
                Dim sql As String = "INSERT INTO sponsored_funds (sponsor_id,type,amount,description) VALUES ('" & sponsor_id & "','" & type & "','" & amount & "','" & description & "')"
                connection.Open()
                Dim Command As MySqlCommand = New MySqlCommand(sql, connection)
                Dim Reader As MySqlDataReader = Command.ExecuteReader

                connection.Close()
                MsgBox("Special thanks to our sponsors")
                Me.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message())
            End Try

        ElseIf (type = "Goods") Then
            Try
                Dim sql As String = "INSERT INTO sponsored_items (sponsor_id,type,item,description) VALUES ('" & sponsor_id & "','" & type & "','" & amount & "','" & description & "')"
                connection.Open()
                Dim Command As MySqlCommand = New MySqlCommand(sql, connection)
                Dim Reader As MySqlDataReader = Command.ExecuteReader

                connection.Close()
                MsgBox("Special thanks to our sponsors")
                Me.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message())
            End Try

        Else
            Try
                Dim sql As String = "INSERT INTO sponsored_service (sponsor_id,type,service,description) VALUES ('" & sponsor_id & "','" & type & "','" & amount & "','" & description & "')"
                connection.Open()
                Dim Command As MySqlCommand = New MySqlCommand(sql, connection)
                Dim Reader As MySqlDataReader = Command.ExecuteReader

                connection.Close()
                MsgBox("Special thanks to our sponsors")
                Me.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message())
            End Try
        End If
    End Sub

    Private Sub SchoolToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SchoolToolStripMenuItem.Click
        Me.Hide()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub sponsored_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MsgBox(sponsor_id)
    End Sub
End Class