<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CreditSimulator.aspx.vb" Inherits="Bank.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Credit simulator</title>
    <link href="/CSS/main_page.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/CreditSimulator.css" rel="stylesheet" type="text/css" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="/JS/page_functionality.js" defer></script>
    <script src="/JS/credit_validator.js"></script>
</head>
<body>
    <header>
        <nav>
            <ul>
                <li><a href="/HTML/main_page.html" class="nav-link">Home</a></li>
                <li><a href="/HTML/about.html" class="nav-link">About</a></li>
                <li><a href="/Webforms/CreditSimulator.aspx" class="nav-link">Loan</a></li>
                <li><a href="/Webforms/Account.aspx" class="nav-link">Account</a></li>
                <li><a href="/Webforms/LogIn.aspx" class="log_out" id="logOut" onclick="logout()">Log out</a></li>
            </ul>
            <div id="user_div">GUEST</div>
        </nav>
    </header>
    <form id="CalculatePayment" runat="server">
        <div class="container">
            <div>
                <div class="center">
                    <asp:Label runat="server" Text="Your full name" CssClass=""></asp:Label>
                    <asp:TextBox ID="txtName" runat="server" CssClass="input-field"></asp:TextBox>
                    <asp:Label ID="NameError" runat="server" Text="Name invalid!" CssClass="error-label" Visible="false"></asp:Label>
                </div>

                <div class="center">
                    <asp:Label runat="server" Text="Amount of money in $" CssClass=""></asp:Label>
                    <asp:TextBox ID="txtAmount" runat="server" CssClass="input-field"></asp:TextBox>
                    <asp:Label ID="AmountError" runat="server" Text="Amount invalid!" CssClass="error-label" Visible="false"></asp:Label>
                </div>
            </div>

            <asp:Label runat="server" Text="Loan type" CssClass="center-label"></asp:Label>
            <div class="loans">
                <div class="loan-f">
                    <asp:RadioButton ID="radio1" runat="server" Text="Personal loan --- 5% interest" GroupName="loanType" Checked="True" />
                </div>
                <div class="loan-f">
                    <asp:RadioButton ID="radio2" runat="server" Text="'First House' loan --- 3% interest" GroupName="loanType" />
                </div>
                <div class="loan-f">
                    <asp:RadioButton ID="radio3" runat="server" Text="Business loan --- 2% interest" GroupName="loanType" />
                </div>
                <div class="loan-f">
                    <asp:RadioButton ID="radio4" runat="server" Text="Student loan --- 1% interest" GroupName="loanType" />
                </div>
            </div>

            <div class="incomes">
                <asp:CheckBoxList ID="checkboxList" runat="server">
                  <asp:ListItem Text="Option 1" Value="1"></asp:ListItem>
                  <asp:ListItem Text="Option 2" Value="2"></asp:ListItem>
                  <asp:ListItem Text="Option 3" Value="3"></asp:ListItem>
                  <asp:ListItem Text="Option 4" Value="4"></asp:ListItem>
                </asp:CheckBoxList>
            </div>
            <div class="center">
                <asp:Label runat="server" Text="Start of the contract period" CssClass=""></asp:Label>
                <asp:TextBox ID="startDate" runat="server" AutoPostBack="true" OnTextChanged="DatePicker_focus" CssClass="input-field" TextMode="DateTimeLocal"></asp:TextBox>
            </div>


            <div class="center">
                <asp:Label runat="server" Text="End of the contract period" CssClass=""></asp:Label>
                <asp:TextBox ID="endDate" runat="server" AutoPostBack="true" OnTextChanged="DatePicker_focus" CssClass="input-field" TextMode="DateTimeLocal"></asp:TextBox>
            </div>

            <div class="error-container">
                <asp:Label ID="DateError" runat="server" CssClass="error-label" Text="" Visible="false"></asp:Label>
            </div>

            <div class="center">
                <asp:Button ID="btnCalculate" runat="server" Text="Calculate" OnClientClick="return validateAmount();" />
            </div>

            <asp:Label ID="lblResult" CssClass="result-label"></asp:Label>
        </div>
    </form>

    <footer>
        <p>Copyright &copy; 2023</p>
    </footer>
    <script src="/JS/LogIn_session.js"></script>

</body>
</html>
