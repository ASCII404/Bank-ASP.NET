Public Class Account
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub BankingTransactions()
        Response.Redirect("/Webforms/BankingTransactions.aspx")
    End Sub

    Protected Sub NewTransactions()
        Response.Redirect("/Webforms/New_BankTransactions.aspx")
    End Sub

    Protected Sub AccountStatement()
        Response.Redirect("/Webforms/AccountStatement.aspx")
    End Sub

    Protected Sub CounterpartsManagement()
        Response.Redirect("/Webforms/CounterpartsManagement.aspx")
    End Sub
    Protected Sub NewBankAccount()
        Response.Redirect("/Webforms/New_BankAccount.aspx")
    End Sub
End Class