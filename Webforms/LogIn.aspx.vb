Imports System.Data.SqlClient
Imports System.Net

Public Class LogIn
    Inherits System.Web.UI.Page

    Protected WithEvents LoginButton As System.Web.UI.WebControls.Button

    Protected Sub LoginButton_Click(sender As Object, e As EventArgs) Handles LoginButton.Click
        Dim username As String = UsernameTextBox.Text
        Dim password As String = PasswordTextBox.Text
        Dim lastName As String = ""
        Dim firstName As String = ""

        Dim connectionString As String = "Server=localhost;Database=ASP.NET-BANK;Trusted_Connection=True;"
        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()
                Dim command As New SqlCommand("SELECT * FROM Users WHERE UserName=@UserName", connection)
                command.Parameters.AddWithValue("@UserName", username)

                Dim reader As SqlDataReader = command.ExecuteReader()
                If reader.Read() Then
                    ' If the user exists, check if the entered password matches the stored password
                    Dim storedPassword As String = reader("Password").ToString()
                    If storedPassword = password Then
                        ' If the password matches, retrieve the user ID
                        Dim userId As Integer = Convert.ToInt32(reader("UserID"))

                        reader.Close()

                        ' Create a new SQL command to retrieve the last name and first name from the AccountOwner table
                        Dim getFullNameCommand As New SqlCommand("SELECT LastName, FirstName FROM AccountOwners WHERE OwnerId = @OwnerId", connection)
                        getFullNameCommand.Parameters.AddWithValue("@OwnerId", userId)

                        ' Create the cookie
                        Dim userCookie As New HttpCookie("UserInfo")

                        Dim fullNameReader As SqlDataReader = getFullNameCommand.ExecuteReader()
                        If fullNameReader.Read() Then
                            lastName = fullNameReader("LastName").ToString()
                            firstName = fullNameReader("FirstName").ToString()
                            userCookie.Values("Username") = lastName & " " & firstName
                        Else
                            userCookie.Values("Username") = username
                        End If
                        fullNameReader.Close()

                        userCookie.Values("UserID") = userId.ToString()

                        ' Add the cookie to the response
                        Response.Cookies.Add(userCookie)

                        Response.Redirect("/HTML/main_page.html")
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
                ' If an exception occurs, display the exception message
                ErrorLabel.Text = "An error occurred: Failed to connect to server"
                ErrorLabel.Visible = True
            End Try
        End Using
    End Sub
End Class
