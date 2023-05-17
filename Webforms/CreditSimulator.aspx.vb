Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub DatePicker_focus(sender As Object, e As EventArgs)
        DateError.Text = ""
        DateError.Visible = False
    End Sub

    Protected Sub CalculateCredit()

    End Sub



End Class