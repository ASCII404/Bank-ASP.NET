Imports System.Data.SqlClient

Public Class New_BankTransactions
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnTransaction_Click(sender As Object, e As EventArgs)
        Dim connectionString As String = "Server=localhost;Database=ASP.NET-BANK;Trusted_Connection=True;"

        Dim accountQuery As String = "SELECT AccountId FROM BankAccounts WHERE OwnerId = @UserId"
        Dim transactionQuery As String = "INSERT INTO AccountTransactions (AccountId, TransactionType, TransactionDate, Amount, Explanation) VALUES (@AccountId, @TransactionType, @TransactionDate, @Amount, @Explanation)"

        Dim userId As Integer = GetUserIdFromCookie()

        Using connection As New SqlConnection(connectionString)
            Dim accountId As Integer = 0

            Using accountCommand As New SqlCommand(accountQuery, connection)
                accountCommand.Parameters.AddWithValue("@UserId", userId)
                connection.Open()
                Dim reader As SqlDataReader = accountCommand.ExecuteReader()
                If reader.Read() Then
                    accountId = reader.GetInt32(0)
                End If
                reader.Close()
            End Using

            If accountId <> 0 Then
                Using command As New SqlCommand(transactionQuery, connection)
                    ' Retrieve the values from the TextBox and DropDownList controls
                    Dim amount As Decimal = Decimal.Parse(txtBoxAmount.Text)
                    Dim transactionType As String = ddlOptions.SelectedValue
                    Dim transactionDate As DateTime = DateTime.Now
                    Dim explanation As String = txtBoxExpl.Text

                    command.Parameters.AddWithValue("@AccountId", accountId)
                    command.Parameters.AddWithValue("@TransactionType", transactionType)
                    command.Parameters.AddWithValue("@TransactionDate", transactionDate)
                    command.Parameters.AddWithValue("@Amount", amount)
                    command.Parameters.AddWithValue("@Explanation", explanation)

                    Try
                        command.ExecuteNonQuery()
                        MsgBox("Success! Your money went righ where you sent them!")
                    Catch ex As Exception
                        MsgBox("Sorry we encountered some problems with the transaction.")
                    End Try
                End Using
            Else
                'Account not found, no more time to handle
            End If
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