Imports System.Data.SqlClient
Imports System.Globalization

Public Class BankingTransactions
    Inherits System.Web.UI.Page

    Dim accountId As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            RetrieveDataFromDatabase()
        End If
    End Sub

    Protected Sub RetrieveDataFromDatabase()
        Dim connectionString As String = "Server=localhost;Database=ASP.NET-BANK;Trusted_Connection=True;"
        Dim userId As Integer = GetUserIdFromCookie()

        Using connection As New SqlConnection(connectionString)
            Dim getAccID As New SqlCommand("SELECT AccountId FROM dbo.BankAccounts WHERE OwnerId = @OwnerId", connection)
            getAccID.Parameters.AddWithValue("@OwnerId", userId)

            connection.Open()

            Using getAccIDReader As SqlDataReader = getAccID.ExecuteReader()
                If getAccIDReader.Read() Then
                    accountId = CInt(getAccIDReader("AccountId"))
                Else
                    ' Handle the case when no account ID is found for the given owner ID no more time
                End If
            End Using

            Dim command As New SqlCommand("SELECT * FROM dbo.AccountTransactions WHERE AccountId = @AccountId", connection)
            command.Parameters.AddWithValue("@AccountId", accountId)

            connection.Close()

            ' Execute the second query and process the results as needed
            connection.Open()

            Dim reader As SqlDataReader = command.ExecuteReader()
            ' Bind the SqlDataReader to the GridView
            gridViewTransactions.DataSource = reader
            gridViewTransactions.DataBind()

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

    Protected Sub btnSearchAmount_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim connectionString As String = "Server=localhost;Database=ASP.NET-BANK;Trusted_Connection=True;"
        Dim userId As Integer = GetUserIdFromCookie()

        Using connection As New SqlConnection(connectionString)
            Dim accountId As Integer
            Dim getAccID As New SqlCommand("SELECT AccountId FROM dbo.BankAccounts WHERE OwnerId = @OwnerId", connection)
            getAccID.Parameters.AddWithValue("@OwnerId", userId)

            connection.Open()

            Using getAccIDReader As SqlDataReader = getAccID.ExecuteReader()
                If getAccIDReader.Read() Then
                    accountId = CInt(getAccIDReader("AccountId"))
                Else
                    ' Handle the case when no account ID is found for the given owner ID
                    ' You can raise an exception, display an error message, or handle it in a way that fits your application's logic
                End If
            End Using

            Dim command As New SqlCommand("SELECT * FROM dbo.AccountTransactions WHERE AccountId = @AccountId AND Amount = @Amount", connection)
            command.Parameters.AddWithValue("@AccountId", accountId)
            command.Parameters.AddWithValue("@Amount", Decimal.Parse(TransAmount.Text))

            Dim reader As SqlDataReader = command.ExecuteReader()

            ' Bind the SqlDataReader to the GridView
            gridViewTransactions.DataSource = reader
            gridViewTransactions.DataBind()

            ' Close the SqlDataReader
            reader.Close()
        End Using
    End Sub
    Protected Sub btnSearchType_Click(sender As Object, e As EventArgs) Handles btnSearch2.Click
        Dim connectionString As String = "Server=localhost;Database=ASP.NET-BANK;Trusted_Connection=True;"
        Dim userId As Integer = GetUserIdFromCookie()

        Using connection As New SqlConnection(connectionString)
            Dim accountId As Integer
            Dim getAccID As New SqlCommand("SELECT AccountId FROM dbo.BankAccounts WHERE OwnerId = @OwnerId", connection)
            getAccID.Parameters.AddWithValue("@OwnerId", userId)

            connection.Open()

            Using getAccIDReader As SqlDataReader = getAccID.ExecuteReader()
                If getAccIDReader.Read() Then
                    accountId = CInt(getAccIDReader("AccountId"))
                Else
                    ' Handle the case when no account ID is found for the given owner ID
                    ' You can raise an exception, display an error message, or handle it in a way that fits your application's logic
                    Return ' Exit the function if no AccountId is found
                End If
            End Using

            ' Convert the selected value of ddlOptions to string
            Dim accountType As String = ddlOptions.SelectedItem.Text.Trim()

            Dim command As New SqlCommand("SELECT * FROM dbo.AccountTransactions WHERE AccountId = @AccountId AND TransactionType = @AccountType", connection)
            command.Parameters.AddWithValue("@AccountId", accountId)
            command.Parameters.AddWithValue("@AccountType", accountType)

            Dim dataAdapter As New SqlDataAdapter(command)

            Dim dataTable As New DataTable()

            ' Fill the DataTable with the data from the SqlDataAdapter
            dataAdapter.Fill(dataTable)

            ' Set the DataSource and DataMember properties of the GridView to display the data
            gridViewTransactions.DataSource = dataTable
            gridViewTransactions.DataBind()

            connection.Close()
        End Using
    End Sub




    Protected Sub btnSearchDate_Click(sender As Object, e As EventArgs) Handles btnSearch3.Click
        Dim connectionString As String = "Server=localhost;Database=ASP.NET-BANK;Trusted_Connection=True;"
        Dim userId As Integer = GetUserIdFromCookie()

        Using connection As New SqlConnection(connectionString)
            Dim accountId As Integer
            Dim getAccID As New SqlCommand("SELECT AccountId FROM dbo.BankAccounts WHERE OwnerId = @OwnerId", connection)
            getAccID.Parameters.AddWithValue("@OwnerId", userId)

            connection.Open()

            Using getAccIDReader As SqlDataReader = getAccID.ExecuteReader()
                If getAccIDReader.Read() Then
                    accountId = CInt(getAccIDReader("AccountId"))
                Else
                    ' Handle the case when no account ID is found for the given owner ID
                    ' You can raise an exception, display an error message, or handle it in a way that fits your application's logic
                End If
            End Using

            Dim transactionDate As DateTime
            If DateTime.TryParse(startDate.Text, transactionDate) Then
                Dim command As New SqlCommand("SELECT * FROM dbo.AccountTransactions WHERE AccountId = @AccountId AND CONVERT(datetime, TransactionDate, 120) = @TransactionDate", connection)
                command.Parameters.AddWithValue("@AccountId", accountId)
                command.Parameters.AddWithValue("@TransactionDate", transactionDate)

                Dim reader As SqlDataReader = command.ExecuteReader()

                ' Bind the SqlDataReader to the GridView
                gridViewTransactions.DataSource = reader
                gridViewTransactions.DataBind()

                ' Close the SqlDataReader
                reader.Close()
            Else
                ' Handle the case when the entered date is not in a valid format
                ' Display an error message or take appropriate action
            End If
        End Using
    End Sub




End Class
