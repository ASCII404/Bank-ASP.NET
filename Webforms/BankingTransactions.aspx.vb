Imports System.Data.SqlClient
Imports System.Globalization

Public Class BankingTransactions
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            RetrieveDataFromDatabase()
        End If
    End Sub

    Protected Sub RetrieveDataFromDatabase()
        Dim connectionString As String = "Server=localhost;Database=ASP.NET-BANK;Trusted_Connection=True;" ' Replace with your actual connection string

        ' Get the user ID from the cookie
        Dim userId As Integer = GetUserIdFromCookie()

        ' Create a SqlConnection object
        Using connection As New SqlConnection(connectionString)
            ' Create a SqlCommand object to execute the SQL query with a parameter
            Dim command As New SqlCommand("SELECT * FROM dbo.AccountTransactions WHERE AccountId = @AccountId", connection)
            command.Parameters.AddWithValue("@AccountId", userId)

            ' Open the database connection
            connection.Open()

            ' Execute the SQL query and get the results into a SqlDataReader
            Dim reader As SqlDataReader = command.ExecuteReader()

            ' Bind the SqlDataReader to the GridView
            gridViewTransactions.DataSource = reader
            gridViewTransactions.DataBind()

            ' Close the SqlDataReader and the database connection
            reader.Close()
            connection.Close()
        End Using
    End Sub

    Private Function GetUserIdFromCookie() As Integer
        Dim userCookie As HttpCookie = Request.Cookies("UserInfo")
        If userCookie IsNot Nothing AndAlso Not String.IsNullOrEmpty(userCookie("UserId")) Then
            Return Integer.Parse(userCookie("UserId"))
        End If
        ' Return a default value or handle the case when the cookie or user ID is not available
        Return 0
    End Function

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

    End Sub


End Class
