Imports System.Data.SqlClient

Public Class AccountStatement
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            RetrieveDataFromDatabase()
        End If
    End Sub

    Protected Sub RetrieveDataFromDatabase()
        Dim connectionString As String = "Server=localhost;Database=ASP.NET-BANK;Trusted_Connection=True;"

        Dim userId As Integer = GetUserIdFromCookie()
        Dim account_id As Integer

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Dim ibanCommand As New SqlCommand("SELECT AccountIban, AccountId FROM dbo.BankAccounts WHERE OwnerId = @OwnerId", connection)
            ibanCommand.Parameters.AddWithValue("@OwnerId", userId)
            Dim iban_reader As SqlDataReader = ibanCommand.ExecuteReader()
            ' Check if there are rows returned
            If iban_reader.HasRows Then
                iban_reader.Read()

                Dim iban_value As Object = iban_reader("AccountIBAN").ToString()
                account_id = iban_reader("AccountId")

                ' Check if the value is not null
                If iban_value IsNot Nothing Then
                    lblIban.Text = "IBAN:" + " " + iban_value
                Else
                    lblIban.Text = "No IBAN found for this account!"
                End If
            Else
                lblIban.Text = "No IBAN found for this account!"
            End If

            iban_reader.Close()

            Dim acctypeCommand As New SqlCommand("SELECT AccountType FROM dbo.BankAccounts WHERE OwnerId = @AccountId", connection)
            acctypeCommand.Parameters.AddWithValue("@AccountId", userId)
            Dim acctypeReader As SqlDataReader = acctypeCommand.ExecuteReader()

            If acctypeReader.HasRows Then
                acctypeReader.Read()

                Dim columnValue As Object = acctypeReader(0)

                If columnValue IsNot Nothing Then

                    lblAccountType.Text = "Account type:" + " " + columnValue.ToString()
                Else
                    lblAccountType.Text = "No Account type found for this account!"
                End If
            Else
                lblAccountType.Text = "No Account type found for this account!"
            End If

            acctypeReader.Close()

            ' Retrieve the email
            Dim emailCommand As New SqlCommand("SELECT email FROM dbo.Users WHERE UserId = @UserId", connection)
            emailCommand.Parameters.AddWithValue("@UserId", userId)
            Dim email_reader As SqlDataReader = emailCommand.ExecuteReader()

            If email_reader.HasRows Then
                email_reader.Read()

                Dim columnValue As Object = email_reader(0)

                ' Check if the value is not null
                If columnValue IsNot Nothing Then
                    ' Print the value
                    lblEmail.Text = "Email associated:" + " " + columnValue.ToString()
                Else
                    lblEmail.Text = "Email associated not found!"
                End If
            Else
                lblEmail.Text = "Email associated:"
            End If

            email_reader.Close()

            ' Retrieve the account owner
            Dim accountOwnerCommand As New SqlCommand("SELECT LastName, FirstName FROM AccountOwners WHERE UserId = @UserId", connection)
            accountOwnerCommand.Parameters.AddWithValue("@UserId", userId)
            Dim accountOwnerReader As SqlDataReader = accountOwnerCommand.ExecuteReader()

            If accountOwnerReader.HasRows Then
                accountOwnerReader.Read()

                Dim lastName As String = accountOwnerReader("LastName").ToString()
                Dim firstName As String = accountOwnerReader("FirstName").ToString()

                ' Check if the values are not null
                If Not String.IsNullOrEmpty(lastName) AndAlso Not String.IsNullOrEmpty(firstName) Then
                    lblAccountOwner.Text = "Account owner: " & firstName & " " & lastName
                Else
                    lblAccountOwner.Text = "No name registered found for this account!"
                End If
            Else
                lblAccountOwner.Text = "No name registered found for this account!"
            End If

            accountOwnerReader.Close()

            'Get the Opening Date from the account
            Dim getDate As New SqlCommand("SELECT OpeningDate FROM dbo.BankAccounts WHERE AccountId = @AccountId", connection)
            getDate.Parameters.AddWithValue("@AccountId", account_id)
            Dim DateReader As SqlDataReader = getDate.ExecuteReader()

            If DateReader.HasRows Then
                DateReader.Read()

                Dim columnValue As Object = DateReader(0)

                ' Check if the value is not null
                If columnValue IsNot Nothing Then
                    lblOpeningDate.Text = "Opening Date:" + " " + columnValue.ToString()
                Else
                    lblOpeningDate.Text = "Opening Date not found!"
                End If
            Else
                lblOpeningDate.Text = "Opening Date:"
            End If
            DateReader.Close()

            'Get the interest rate of the account
            Dim getRate As New SqlCommand("SELECT InterestRate FROM dbo.BankAccounts WHERE AccountId = @AccountId", connection)
            getRate.Parameters.AddWithValue("@AccountId", account_id)
            Dim RateReader As SqlDataReader = getRate.ExecuteReader()

            If RateReader.HasRows Then
                RateReader.Read()

                Dim columnValue As Object = RateReader(0)

                ' Check if the value is not null
                If columnValue IsNot Nothing Then
                    lblInterestRate.Text = "Interest rate:" + " " + columnValue.ToString()
                Else
                    lblInterestRate.Text = "Interest rate not found!"
                End If
            Else
                lblInterestRate.Text = "Interest rate:"
            End If
            RateReader.Close()

            Dim gridcommand As New SqlCommand("SELECT * FROM dbo.AccountTransactions WHERE AccountId = @AccountId", connection)
            gridcommand.Parameters.AddWithValue("@AccountId", account_id)

            Dim grid_reader As SqlDataReader = gridcommand.ExecuteReader()

            ' Bind the SqlDataReader to the GridView
            gridViewTransactions.DataSource = grid_reader
            gridViewTransactions.DataBind()

            ' Close the SqlDataReader and the database connection
            grid_reader.Close()
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
End Class