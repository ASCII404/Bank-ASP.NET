Imports System.Data.SqlClient
Imports System.Security.Cryptography.X509Certificates

Public Class LogIn
    Inherits System.Web.UI.Page

    Protected WithEvents LoginButton As System.Web.UI.WebControls.Button
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        ' Set the value of the cookie
        Dim user_name As String = UsernameTextBox.Text
        Dim message As String = user_name
        Dim myCookie As New HttpCookie("User", message)
        Response.AppendHeader("Set-Cookie", myCookie.ToString())

        Response.Cookies.Add(myCookie)

        ' Set the expiration date of the cookie to 1 day from now
        Response.Cookies("User").Expires = DateTime.Now.AddDays(1)

        ' Add the cookie to the Session object
        Session("User") = myCookie.Value
    End Sub


    Protected Sub LoginButton_Click(sender As Object, e As EventArgs) Handles LoginButton.Click
        Dim username As String = UsernameTextBox.Text
        Dim password As String = PasswordTextBox.Text

        'create a connection to the SQL Server database
        Dim connectionString As String = "Data Source=aspnetgunter.database.windows.net;Initial Catalog=aspnetgustav2;User ID=gunter;Password=PentaSKT12#;"
        Dim connection As New SqlConnection(connectionString)

        Try
            'open the connection
            connection.Open()

            'create a SQL command to retrieve the user with the entered username
            Dim command As New SqlCommand("SELECT * FROM Users WHERE UserName=@UserName", connection)
            command.Parameters.AddWithValue("@UserName", username)

            'execute the command and read the result
            Dim reader As SqlDataReader = command.ExecuteReader()
            If reader.Read() Then
                'if the user exists, check if the entered password matches the stored password
                Dim storedPassword As String = reader("Password").ToString()
                If storedPassword = password Then
                    'if the password matches, set a session variable with the username and redirect to main_page.html
                    Session("Username") = username
                    Response.Redirect("~/main_page.html")
                Else
                    'if the password does not match, display an error message
                    ErrorLabel.Text = "Invalid username or password."
                    ErrorLabel.Visible = True
                End If
            Else
                'if the user does not exist, display an error message
                ErrorLabel.Text = "Invalid username or password."
                ErrorLabel.Visible = True
            End If

        Catch ex As Exception
            'if the connection fails, display an error message
            ErrorLabel.Text = "An error occurred while trying to connect to the database."
            ErrorLabel.Visible = True
        Finally
            'close the connection
            connection.Close()
        End Try
    End Sub


End Class
