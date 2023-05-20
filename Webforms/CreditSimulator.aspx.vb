Imports Microsoft.Ajax.Utilities

Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub DatePicker_focus(sender As Object, e As EventArgs)
        DateError.Text = ""
        DateError.Visible = False
    End Sub

    Protected Sub Amount_focus(sender As Object, e As EventArgs)
        AmountError.Text = ""
        AmountError.Visible = False
    End Sub

    Protected Sub Name_focus(sender As Object, e As EventArgs)
        NameError.Visible = False
    End Sub

    Function validate_Startdate(startDate As String) As Integer
        Dim startDateTime As DateTime
        If Not String.IsNullOrWhiteSpace(startDate) Then
            If DateTime.TryParse(startDate, startDateTime) Then
                Return startDateTime.Year
            End If
        End If

        Return 0
    End Function

    Function validate_EndDate(endDate As String) As Integer
        Dim endDateTime As DateTime
        If Not String.IsNullOrWhiteSpace(endDate) Then
            If DateTime.TryParse(endDate, endDateTime) Then
                Return endDateTime.Year
            End If
        End If

        Return 0
    End Function
    Protected Sub btnCalculate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCalculate.Click

        Dim interest_rate As Double
        Dim paranthesis As Double
        Dim result As Double

        Dim income_selected As Integer = 0
        Dim customer_name = txtName.Text
        Dim amount As Decimal

        Dim endDateValue As String = endDate.Text
        'Dim endDateDateTime As DateTime = DateTime.Parse(endDateValue)
        'Dim endYear As Integer = endDateDateTime.Year

        Dim startDateValue As String = startDate.Text
        'Dim startDateDateTime As DateTime = DateTime.Parse(startDateValue)
        'Dim startYear As Integer = startDateDateTime.Year

        Dim flag As Boolean = True
        If (validate_EndDate(endDateValue) - validate_Startdate(startDateValue)) < 1 Then
            DateError.Text = "Period should be at least 1 year!"
            DateError.Visible = True
            flag = False
        End If

        If String.IsNullOrEmpty(txtName.Text) Then
            flag = False
            NameError.Visible = True
            NameError.Text = "Enter a valid name!"
        Else
            NameError.Visible = False
            NameError.Text = ""
        End If


        If String.IsNullOrEmpty(txtAmount.Text) Then
            flag = False
            AmountError.Visible = True
            AmountError.Text = "Invalid amount! Please enter a valid number"
        Else
            AmountError.Visible = False
            AmountError.Text = ""
            amount = Integer.Parse(txtAmount.Text)
        End If

        Select Case True
            Case radio1.Checked
                interest_rate = 0.05
            Case radio2.Checked
                interest_rate = 0.03
            Case radio3.Checked
                interest_rate = 0.02
            Case radio4.Checked
                interest_rate = 0.01
            Case Else
                MsgBox("dada")
        End Select

        IncomeError.Visible = False
        Dim selectedValues As New List(Of String)()

        For Each checkbox As ListItem In checkboxList.Items
            If checkbox.Selected Then
                selectedValues.Add(checkbox.Value)
            End If
        Next

        Select Case selectedValues.Count
            Case 0
                IncomeError.Visible = True
                Return
            Case 1
                ' Code when exactly one value is selected
                income_selected += Integer.Parse(selectedValues(0))
            Case 2
                ' Code when exactly two values are selected
                income_selected += (Integer.Parse(selectedValues(1)) + Integer.Parse(selectedValues(0)))

            Case 3
                income_selected += (Integer.Parse(selectedValues(1)) + Integer.Parse(selectedValues(0)) + Integer.Parse(selectedValues(2)))

            Case 4
                income_selected += (Integer.Parse(selectedValues(1)) + Integer.Parse(selectedValues(0)) + Integer.Parse(selectedValues(2)) + Integer.Parse(selectedValues(3)))
            Case Else
                For Each selectedValue As String In selectedValues
                    ' Use the selectedValue for further processing
                Next
        End Select

        paranthesis = Math.Pow(1 + interest_rate, validate_EndDate(endDateValue) - validate_Startdate(startDateValue))
        result = -(amount * interest_rate * paranthesis) / (1 - paranthesis)
        result = Math.Round(result, 2)

        If flag Then
            Response.Redirect("/Webforms/Info.aspx?monthlyPayment=" & result & "&fullname=" & customer_name & "&incV=" & income_selected & "&interest=" & interest_rate)
        Else
            Return
        End If

    End Sub

End Class