Public Class Account
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub BankingTransactions()
        Server.TransferRequest("/Webforms/BankingTransactions.aspx")
    End Sub

    Protected Sub NewTransactions()
        Server.TransferRequest("/Webforms/New_BankTransactions.aspx")
    End Sub

    Protected Sub AccountStatement()
        Server.TransferRequest("/Webforms/AccountStatement.aspx")
    End Sub

    Protected Sub CounterpartsManagement()
        Server.TransferRequest("/Webforms/CounterpartsManagement.aspx")
    End Sub
End Class