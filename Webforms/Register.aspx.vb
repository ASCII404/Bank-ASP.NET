Imports System.Data.SqlClient

Public Class Register
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub RegisterButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Retrieve user input
        Dim username As String = UsernameTextBox.Text.Trim()
        Dim password As String = PasswordTextBox.Text.Trim()
        Dim last_name As String = LastName.Text.Trim()
        Dim first_name As String = FirstName.Text.Trim()
        Dim email As String = EmailTextBox.Text.Trim()

        Dim connectionString As String = "Server=localhost;Database=ASP.NET-BANK;Trusted_Connection=True;"

        ' SQL query to insert user's credentials
        Dim query As String = "INSERT INTO Users (UserName, Password, email) VALUES (@UserName, @Password, @Email)"
        Dim fullName As String = "INSERT INTO AccountOwners (LastName, FirstName) VALUES (@LastName, @FirstName)"

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            ' Insert full name into AccountOwners table
            Using fullnameC As New SqlCommand(fullName, connection)
                fullnameC.Parameters.AddWithValue("@LastName", last_name)
                fullnameC.Parameters.AddWithValue("@FirstName", first_name)
                Try
                    fullnameC.ExecuteNonQuery()
                    MsgBox("Success!")
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using

            ' Insert user credentials into Users table
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@UserName", username)
                command.Parameters.AddWithValue("@Password", password)
                command.Parameters.AddWithValue("@Email", email)

                Try
                    command.ExecuteNonQuery()
                    Response.Redirect("/Webforms/LogIn.aspx", False)
                    HttpContext.Current.ApplicationInstance.CompleteRequest()
                Catch ex As Exception
                    ErrorLabel.Text = "An error occurred during registration."
                End Try
            End Using
        End Using
    End Sub
End Class
