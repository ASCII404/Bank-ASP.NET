Public Class Info
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim clientName As String = Request.QueryString("fullname")
            Dim monthlyPayment As String = Request.QueryString("monthlyPayment")
            Dim income As String = Request.QueryString("incV")
            Dim irate As String = Request.QueryString("interest")

            Dim random As New Random()
            Dim applicationNumber As Integer = random.Next(1, 10000)
            Dim currentDate As String = DateTime.Now.ToString("MMMM dd, yyyy")

            Dim message As String = "Dear " & clientName & ", we inform you that, according to the data from the credit application no. " &
                                        applicationNumber & " from " & currentDate & ", the value of the monthly payment is: " & monthlyPayment & "$"

            Dim notAllowed_message As String = "Dear " & clientName & ", we inform you that, according to the data from the credit application no. " &
                                        applicationNumber & " from " & currentDate & ", the value of the monthly payment is: " &
                                        monthlyPayment & "$."

            Dim notAllowed_messageC As String = "After carefully analyzing your income, we regret to inform you that it may not 
                                                 be sufficient to sustain the proposed credit. Please consider an alternative loan option."
            Try
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
                    lblMessageN.Text = notAllowed_messageC
                End If
            Catch ex As Exception
                'won't handle this, not enough time left 
            End Try


        End If
    End Sub
    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        ' Redirect to the previous page
        Response.Redirect("/Webforms/CreditSimulator.aspx")
    End Sub




End Class