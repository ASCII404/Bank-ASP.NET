Imports System.Data.SqlClient
Imports System.Net

Public Class LogIn
    Inherits System.Web.UI.Page
    Protected WithEvents LoginButton As System.Web.UI.WebControls.Button
    Protected Sub LoginButton_Click(sender As Object, e As EventArgs) Handles LoginButton.Click
        Dim username As String = UsernameTextBox.Text
        Dim password As String = PasswordTextBox.Text

        ' Create a connection to the SQL Server database
        Dim connectionString As String = "Data Source=aspnetgunter.database.windows.net;Initial Catalog=aspnetgustav2;User ID=gunter;Password=PentaSKT12#;"
        Using connection As New SqlConnection(connectionString)
            Try
                ' Open the connection
                connection.Open()

                ' Create a SQL command to retrieve the user with the entered username
                Dim command As New SqlCommand("SELECT * FROM Users WHERE UserName=@UserName", connection)
                command.Parameters.AddWithValue("@UserName", username)

                ' Execute the command and read the result
                Dim reader As SqlDataReader = command.ExecuteReader()
                If reader.Read() Then
                    ' If the user exists, check if the entered password matches the stored password
                    Dim storedPassword As String = reader("Password").ToString()
                    If storedPassword = password Then
                        ' If the password matches, set the value of the cookie
                        Dim userCookie As New HttpCookie("User", username)
                        ' Add the cookie to the response
                        Response.Cookies.Add(userCookie)

                        ' Redirect to main_page.html
                        Response.Redirect("~/main_page.html")
                    Else
                        ' If the password does not match, display an error message
                        ErrorLabel.Text = "Invalid username or password."
                        ErrorLabel.Visible = True
                    End If
                Else
                    ' If the user does not exist, display an error message
                    ErrorLabel.Text = "Invalid username or password."
                    ErrorLabel.Visible = True
                End If

            Catch ex As Exception
                ' If the connection fails, display an error message
                ErrorLabel.Text = "An error occurred while trying to connect to the database."
                ErrorLabel.Visible = True
            End Try
        End Using
    End Sub
End Class
