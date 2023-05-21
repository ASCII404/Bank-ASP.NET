Imports System.Data.SqlClient

Public Class New_BankAccount
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub btnCreate_Click(sender As Object, e As EventArgs)
        ' Retrieve user input
        Dim accountType As String = ddlOptions.SelectedValue
        Dim ownerId As Integer = GetUserIdFromCookie()
        Dim todayDate As DateTime = DateTime.Today
        Dim interestRate As Decimal = 78.3
        Dim randomDigits As Integer = New Random().Next(1000, 9999)
        Dim iban As String = "RO62 BNKX 0062 0023 2323 " & randomDigits.ToString()

        Dim connectionString As String = "Server=localhost;Database=ASP.NET-BANK;Trusted_Connection=True;"

        ' SQL query to insert transaction information
        Dim transactionQuery As String = "INSERT INTO BankAccounts (AccountType, OwnerId, OpeningDate, InterestRate, AccountIBAN) VALUES (@AccountType, @OwnerId, @TransactionDate, @InterestRate, @Iban)"

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            ' Insert transaction information into BankAccounts table
            Using command As New SqlCommand(transactionQuery, connection)
                command.Parameters.AddWithValue("@AccountType", accountType)
                command.Parameters.AddWithValue("@OwnerId", ownerId)
                command.Parameters.AddWithValue("@TransactionDate", todayDate)
                command.Parameters.AddWithValue("@InterestRate", interestRate)
                command.Parameters.AddWithValue("@Iban", iban)

                Try
                    command.ExecuteNonQuery()
                    MsgBox("Success!")
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub
    Private Function GetUserIdFromCookie() As Integer
        Dim userCookie As HttpCookie = Request.Cookies("UserInfo")
        If userCookie IsNot Nothing AndAlso Not String.IsNullOrEmpty(userCookie("UserId")) Then
            Return Integer.Parse(userCookie("UserId"))
        End If

        Return 0
    End Function
End Class