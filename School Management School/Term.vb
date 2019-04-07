Imports MySql.Data.MySqlClient
Public Class Term
    Dim con As String = "server=localhost;user id=root;database=kariangwe_high"
    Dim connection As New MySqlConnection(con)

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            Dim dr As MySqlDataReader
            connection.Open()

            Dim sql As String = "Select student_id, form from students"
            Dim cmd As MySqlCommand = New MySqlCommand(sql, connection)
            dr = cmd.ExecuteReader()


            Dim id(10) As String
            Dim forms(10) As Integer
            Dim i As Integer = 0




            If (dr.HasRows()) Then

                While (dr.Read())

                    Dim student_id As String = dr("student_id")
                    Dim form As Integer = dr("form")
                    id(i) = student_id
                    forms(i) = form
                    i = i + 1

                End While

                MsgBox("Updating all students grades")
                connection.Close()

                i = 0

                While (id(i) IsNot Nothing)
                    If (forms(i) <> 4 Or forms(i) <> 6) Then
                        connection.Open()
                        Dim newform As Integer = forms(i) + 1
                        Dim sql1 As String = "update students SET form = '" & newform & "' WHERE student_id = '" & id(i) & "'"
                        Dim Command As MySqlCommand = New MySqlCommand(sql1, connection)
                        Dim Reader As MySqlDataReader = Command.ExecuteReader
                        connection.Close()
                        i = i + 1
                    Else

                        connection.Open()
                        Dim newform As Integer = 0
                        Dim sql1 As String = "update students SET form = '" & newform & "' WHERE student_id = '" & id(i) & "'"
                        Dim Command As MySqlCommand = New MySqlCommand(sql1, connection)
                        Dim Reader As MySqlDataReader = Command.ExecuteReader
                        connection.Close()
                        i = i + 1
                    End If
                End While
                MsgBox("Updates was successfull")
                Me.Dispose()

                connection.Close()

            Else

                MsgBox("no students found")

            End If







        Catch ex As Exception

            MsgBox(ex.Message())

        Finally
            connection.Close()
        End Try





    End Sub

    Private Sub Term_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class