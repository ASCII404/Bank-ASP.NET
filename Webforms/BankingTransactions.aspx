<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BankingTransactions.aspx.vb" Inherits="Bank.BankingTransactions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Banking</title>
    <link href="/CSS/main_page.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/BankTransactions.css" rel="stylesheet" type="text/css" />
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
                <li><a href="/Webforms/Account.aspx" class="nav-link home">Account</a></li>
                <li><a href="/Webforms/LogIn.aspx" class="log_out" id="logOut" onclick="logout()">Log out</a></li>
            </ul>
            <div id="user_div">GUEST</div>
        </nav>
    </header>
    <form id="form1" runat="server">
        <div class="container">
            <div class="filters-container">
                <div class="filters">
                    <div class="options">
                        <asp:Label runat="server" Text="Transaction Amount" CssClass="lbl-mod"></asp:Label>
                        <asp:TextBox ID="TransAmount" runat="server" CssClass="input-field"></asp:TextBox>
                    </div>
                    <div class="options">
                        <asp:Label runat="server" Text="Type of Transaction" CssClass="lbl-mod"></asp:Label>
                        <asp:DropDownList ID="ddlOptions" runat="server" CssClass="dropdown">
                            <asp:ListItem Text="Cash deposit - RON" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Cash deposit - EUR/USD" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Cash withdrawal (counter) - RON" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Cash withdrawal (ATM)- RON" Value="4"></asp:ListItem>
                            <asp:ListItem Text="Account Opening" Value="5"></asp:ListItem>
                            <asp:ListItem Text="Funds transfer" Value="6"></asp:ListItem>
                            <asp:ListItem Text="Card payment" Value="7"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="options">
                        <asp:Label runat="server" Text="Date of transaction" CssClass="lbl-mod"></asp:Label>
                        <asp:TextBox ID="startDate" runat="server" AutoPostBack="true" CssClass="input-field" TextMode="DateTimeLocal"></asp:TextBox>
                    </div>
                </div>
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="form-button" OnClick="btnSearch_Click" />
            </div>
            <div class="transaction-container">
                <asp:GridView ID="gridViewTransactions" runat="server" CssClass="transaction-grid" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
                        <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" />
                        <asp:BoundField DataField="Amount" HeaderText="Transaction Amount" />
                        <asp:BoundField DataField="TransactionType" HeaderText="Transaction Type" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>

    </form>
    <footer>
        <p>&copy; 2023 Bank. All rights reserved.</p>
    </footer>
    <script src="/JS/page_functionality.js" defer></script>
    <script src="/JS/LogIn_session.js"></script>
</body>
</html>
