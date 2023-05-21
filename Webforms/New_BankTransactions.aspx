<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="New_BankTransactions.aspx.vb" Inherits="Bank.New_BankTransactions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/CSS/main_page.css" rel="stylesheet" type="text/css">
    <link href="/CSS/New_BankTransactions.css" rel="stylesheet" type="text/css">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">
</head>
<body>
    <header>
        <nav>
            <ul>
                <li><a href="/HTML/main_page.html" class="nav-link">Home</a></li>
                <li><a href="/HTML/about.html" class="nav-link">About</a></li>
                <li><a href="/Webforms/CreditSimulator.aspx" class="nav-link">Loan</a></li>
                <li><a href="/Webforms/Account.aspx" class="nav-link home">Account</a></li>
                <li><a href="/Webforms/LogIn.aspx" class="log_out" id="logOut" onclick="logout()">Log out</a></li>
            </ul>
            <div id="user_div">GUEST</div>

        </nav>
    </header>
    <form id="form1" runat="server" class="form-card">
        <h1>New transaction</h1>
        <div class="wrapper-c">
            <div class="options">
                <asp:Label ID="lblAmount" runat="server" Text="Amount"></asp:Label>
                <asp:TextBox ID="txtBoxAmount" runat="server"></asp:TextBox>
            </div>

            <div class="options">
                <asp:Label ID="lblExpl" runat="server" Text="Explanation for the transaction"></asp:Label>
                <asp:TextBox ID="txtBoxExpl" runat="server"></asp:TextBox>
            </div>

            <div class="options">
                <asp:Label runat="server" Text="Type of Transaction" CssClass="lbl-mod"></asp:Label>
                <asp:DropDownList ID="ddlOptions" runat="server" CssClass="dropdown">
                    <asp:ListItem Text="Cash deposit - RON" Value="Cash deposit - RON"></asp:ListItem>
                    <asp:ListItem Text="Cash deposit - EUR/USD" Value="Cash deposit - EUR/USD"></asp:ListItem>
                    <asp:ListItem Text="Cash withdrawal (counter) - RON" Value="Cash withdrawal (counter) - RON"></asp:ListItem>
                    <asp:ListItem Text="Cash withdrawal (ATM)- RON" Value="Cash withdrawal (ATM)- RON"></asp:ListItem>
                    <asp:ListItem Text="Account Opening" Value="Account Opening"></asp:ListItem>
                    <asp:ListItem Text="Funds transfer" Value="Funds transfer"></asp:ListItem>
                    <asp:ListItem Text="Card payment" Value="Card payment"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="btn-create">
            <asp:Button ID="btnTransaction" runat="server" Text="Create transaction" OnClick="btnTransaction_Click" />
        </div>
    </form>
    <footer>
        <p>
            <i class="fab fa-github"></i>
            <strong>
                <a href="https://github.com/ASCII404">Made by ASCII404</a>
            </strong>
        </p>
        <p>Copyright &copy; 2023</p>
    </footer>
    <script src="/JS/page_functionality.js" defer></script>
    <script src="/JS/LogIn_session.js"></script>
</body>
</html>
