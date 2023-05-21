Imports System.Data.SqlClient

Public Class AccountStatement
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ddlAccountTypes.CssClass = "dropdownlist"
        If IsPostBack Then
            RetrieveDataFromDatabase()
        End If
    End Sub

    Protected Sub RetrieveDataFromDatabase()
        Dim ownerId As Integer = GetUserIdFromCookie() ' Retrieve the ownerId from the cookie or any other source
        Dim connectionString As String = "Server=localhost;Database=ASP.NET-BANK;Trusted_Connection=True;"
        Dim accountType As String = ddlAccountTypes.SelectedValue ' Get the selected account type from the dropdown list

        Dim accountIdQuery As String = "SELECT AccountId, AccountIBAN FROM BankAccounts WHERE AccountType = @AccountType AND OwnerId = @OwnerId"
        Dim accountOwnerQuery As String = "SELECT FirstName, LastName FROM AccountOwners WHERE UserId = @OwnerId"
        Dim emailQuery As String = "SELECT Email FROM Users WHERE UserId = @OwnerId"
        Dim accountInfoQuery As String = "SELECT OpeningDate, InterestRate FROM BankAccounts WHERE AccountId = @AccountId"

        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                ' Retrieve the account ID and IBAN based on the account type and owner ID
                Using accountIdCommand As New SqlCommand(accountIdQuery, connection)
                    accountIdCommand.Parameters.AddWithValue("@AccountType", accountType)
                    accountIdCommand.Parameters.AddWithValue("@OwnerId", ownerId)

                    Dim reader As SqlDataReader = accountIdCommand.ExecuteReader()

                    If reader.HasRows Then
                        reader.Read()

                        Dim accountId As Integer = CInt(reader("AccountId"))
                        Dim accountIban As String = reader("AccountIBAN").ToString()

                        lblIban.Text = "IBAN: " + accountIban
                        reader.Close()

                        ' Retrieve the account owner's first name and last name from the "Users" table
                        Using accountOwnerCommand As New SqlCommand(accountOwnerQuery, connection)
                            accountOwnerCommand.Parameters.AddWithValue("@OwnerId", ownerId)

                            Dim accountOwnerReader As SqlDataReader = accountOwnerCommand.ExecuteReader()

                            If accountOwnerReader.HasRows Then
                                accountOwnerReader.Read()

                                Dim firstName As String = accountOwnerReader("FirstName").ToString()
                                Dim lastName As String = accountOwnerReader("LastName").ToString()

                                lblAccountOwner.Text = "Who owns the account: " + firstName + " " + lastName
                            End If

                            accountOwnerReader.Close()
                        End Using

                        ' Retrieve the email from the "Users" table
                        Using emailCommand As New SqlCommand(emailQuery, connection)
                            emailCommand.Parameters.AddWithValue("@OwnerId", ownerId)

                            Dim emailReader As SqlDataReader = emailCommand.ExecuteReader()

                            If emailReader.HasRows Then
                                emailReader.Read()

                                Dim email As String = emailReader("Email").ToString()

                                lblEmail.Text = "Email associated: " + email
                            End If

                            emailReader.Close()
                        End Using

                        ' Retrieve the opening date and interest rate from the "BankAccounts" table
                        Using accountInfoCommand As New SqlCommand(accountInfoQuery, connection)
                            accountInfoCommand.Parameters.AddWithValue("@AccountId", accountId)

                            Dim accountInfoReader As SqlDataReader = accountInfoCommand.ExecuteReader()

                            If accountInfoReader.HasRows Then
                                accountInfoReader.Read()

                                Dim openingDate As DateTime = CDate(accountInfoReader("OpeningDate"))
                                Dim interestRate As Decimal = CDec(accountInfoReader("InterestRate"))

                                lblOpeningDate.Text = "Opening Date: " + openingDate.ToString("yyyy-MM-dd")
                                lblInterestRate.Text = "Interest rate on this account: " + interestRate.ToString("0.00") + "%"
                            End If

                            accountInfoReader.Close()
                        End Using

                        ' SQL query to retrieve the transactions for the specific account ID
                        Dim transactionsQuery As String = "SELECT * FROM AccountTransactions WHERE AccountId = @AccountId"

                        Using transactionsCommand As New SqlCommand(transactionsQuery, connection)
                            transactionsCommand.Parameters.AddWithValue("@AccountId", accountId)

                            Dim transactionsReader As SqlDataReader = transactionsCommand.ExecuteReader()

                            ' Bind the SqlDataReader to the GridView
                            gridViewTransactions.DataSource = transactionsReader
                            gridViewTransactions.DataBind()

                            ' Close the SqlDataReader
                            transactionsReader.Close()
                        End Using
                    End If

                    reader.Close()
                End Using
            End Using
        Catch ex As Exception
            ' Handle the exception, display an error message, or log the error
            ' You can customize this section based on your application's requirements

            MsgBox(ex.Message)
        End Try
    End Sub







    Private Function GetUserIdFromCookie() As Integer
        Dim userCookie As HttpCookie = Request.Cookies("UserInfo")
        If userCookie IsNot Nothing AndAlso Not String.IsNullOrEmpty(userCookie("UserId")) Then
            Return Integer.Parse(userCookie("UserId"))
        End If
        ' Return a default value or handle the case when the cookie or user ID is not available
        Return 0
    End Function

    Protected Sub ddlAccountTypes_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim selectedAccountType As String = ddlAccountTypes.SelectedValue

        ' Use the selectedAccountType to fetch the account information from the database
        ' and display it in the respective labels or controls on your page.
        ' You can use a similar approach as shown in your existing code to retrieve and display the information.
    End Sub

End Class