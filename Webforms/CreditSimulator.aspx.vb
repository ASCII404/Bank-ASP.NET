Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub DatePicker_focus(sender As Object, e As EventArgs)
        DateError.Text = ""
        DateError.Visible = False
    End Sub
    Protected Sub btnCalculate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCalculate.Click

    End Sub

End Class