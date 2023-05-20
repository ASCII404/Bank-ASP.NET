Public Class Info
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim clientName As String = Request.QueryString("fullname")
            Dim random As New Random()
            Dim applicationNumber As Integer = random.Next(1, 10000)
            Dim monthlyPayment As String = Request.QueryString("monthlyPayment")
            Dim income As String = Request.QueryString("incV")
            Dim currentDate As String = DateTime.Now.ToString("MMMM dd, yyyy")
            Dim irate As String = Request.QueryString("interest")
            Dim message As String = "Dear " & clientName & ", we inform you that, according to the data from the credit application no. " &
                                        applicationNumber & " from " & currentDate & ", the value of the monthly payment is: " & monthlyPayment & " $"

            Dim notAllowed_message As String = "Dear " & clientName & ", we inform you that, according to the data from the credit application no. " &
                                        applicationNumber & " from " & currentDate & ", the value of the monthly payment is: " &
                                        monthlyPayment & " $" & "Which your income, based on our analysis will not be able to sustain the credit. Please pick another loan!"

            If (Integer.Parse(income) = 5 And Decimal.Parse(irate) <= 0.01) Then
                lblMessage.Text = message
            ElseIf (Integer.Parse(income) = 10 And Decimal.Parse(irate) <= 0.03) Then
                lblMessage.Text = message
            ElseIf (Integer.Parse(income) = 15 And Decimal.Parse(irate) <= 0.03) Then
                lblMessage.Text = message
            ElseIf (Integer.Parse(income) > 15 And Decimal.Parse(irate) <= 0.05) Then
                lblMessage.Text = message
            Else
                lblMessage.Text = notAllowed_message
            End If


        End If
    End Sub

    Private Function GetClientNameFromCookie() As String
        Dim clientName As String = ""
        Dim cookie As HttpCookie = Request.Cookies("User")

        If cookie IsNot Nothing Then
            clientName = cookie.Value
        End If

        Return clientName
    End Function

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        ' Redirect to the previous page
        Response.Redirect("/Webforms/CreditSimulator.aspx")
    End Sub




End Class