﻿Imports System.Data.SqlClient

Public Class Register
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    Protected Sub RegisterButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Retrieve user input
        Dim username As String = UsernameTextBox.Text.Trim()
        Dim password As String = PasswordTextBox.Text.Trim()
        Dim email As String = EmailTextBox.Text.Trim()

        ' Database connection string
        Dim connectionString As String = "Server=localhost;Database=ASP.NET-BANK;Trusted_Connection=True;"

        ' SQL query to insert user's credentials
        Dim query As String = "INSERT INTO Users (UserName, Password, email) VALUES (@UserName, @Password, @email)"

        ' Create connection and command objects
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)

                command.Parameters.AddWithValue("@UserName", username)
                command.Parameters.AddWithValue("@Password", password)
                command.Parameters.AddWithValue("@email", email)

                Try
                    connection.Open()
                    command.ExecuteNonQuery()

                    ' Registration successful, redirect to a success page or perform any other actions
                    Response.Redirect("/Webforms/LogIn.aspx")
                Catch ex As Exception
                    ' Error occurred, display error message
                    ErrorLabel.Text = "An error occurred during registration."
                End Try
            End Using
        End Using
    End Sub

End Class
