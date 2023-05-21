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
        Dim query As String = "INSERT INTO Users (UserName, Password, email) VALUES (@UserName, @Password, @Email); SELECT SCOPE_IDENTITY()"

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            ' Insert user credentials into Users table and retrieve the generated UserId
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@UserName", username)
                command.Parameters.AddWithValue("@Password", password)
                command.Parameters.AddWithValue("@Email", email)

                Dim userId As Integer = CInt(command.ExecuteScalar())

                ' Insert full name and UserId into AccountOwners table
                Dim fullNameQuery As String = "INSERT INTO AccountOwners (LastName, FirstName, UserId) VALUES (@LastName, @FirstName, @UserId)"

                Using fullNameCommand As New SqlCommand(fullNameQuery, connection)
                    fullNameCommand.Parameters.AddWithValue("@LastName", last_name)
                    fullNameCommand.Parameters.AddWithValue("@FirstName", first_name)
                    fullNameCommand.Parameters.AddWithValue("@UserId", userId)

                    Try
                        fullNameCommand.ExecuteNonQuery()
                        Response.Redirect("/Webforms/LogIn.aspx", False)
                        HttpContext.Current.ApplicationInstance.CompleteRequest()
                    Catch ex As Exception
                        ErrorLabel.Text = "An error occurred during registration."
                    End Try
                End Using
            End Using
        End Using
    End Sub



End Class
