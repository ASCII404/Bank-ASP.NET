Imports System.Data.SqlClient

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
        Dim connectionString As String = "Data Source=aspnetgunter.database.windows.net;Initial Catalog=aspnetgustav2;User ID=gunter;Password=PentaSKT12#;"

        ' SQL query to insert user's credentials
        Dim query As String = "INSERT INTO Users (UserName, Password, email) VALUES (@UserName, @Password, @email)"

        ' Create connection and command objects
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                ' Add parameters
                command.Parameters.AddWithValue("@UserName", username)
                command.Parameters.AddWithValue("@Password", password)
                command.Parameters.AddWithValue("@email", email)

                Try
                    ' Open the connection
                    connection.Open()

                    ' Execute the query
                    command.ExecuteNonQuery()

                    ' Registration successful, redirect to a success page or perform any other actions
                    Response.Redirect("LogIn.aspx")
                Catch ex As Exception
                    ' Error occurred, display error message or perform any other error handling
                    ErrorLabel.Text = "An error occurred during registration."
                End Try
            End Using
        End Using
    End Sub

End Class
