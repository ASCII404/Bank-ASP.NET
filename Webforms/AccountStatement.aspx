<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AccountStatement.aspx.vb" Inherits="Bank.AccountStatement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/CSS/main_page.css" rel="stylesheet" type="text/css">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link href="/CSS/AccountStatement.css" rel="stylesheet" />
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
    <form id="AccountStatement" runat="server">
        <div class="container">
            <div class="label-container">
                <div class="lbl-g">
                    <asp:Label ID="lblIban" runat="server" Text="IBAN:" CssClass="lbl-c"></asp:Label>
                </div>
                <div class="lbl-g">
                    <asp:Label ID="lblAccountOwner" runat="server" Text="Who owns the account:" CssClass="lbl-c"></asp:Label>
                </div>

                <div class="lbl-g">
                    <asp:Label ID="lblEmail" runat="server" Text="Email associated:" CssClass="lbl-c"></asp:Label>
                </div>

                <div class="lbl-g">
                    <asp:Label ID="lblAccountType" runat="server" Text="Type of account:" CssClass="lbl-c"></asp:Label>
                </div>

                <div class="lbl-g">
                    <asp:Label ID="lblOpeningDate" runat="server" Text="Opening Date:" CssClass="lbl-c"></asp:Label>
                </div>

                 <div class="lbl-g">
                    <asp:Label ID="lblInterestRate" runat="server" Text="Interest rate on this account:" CssClass="lbl-c"></asp:Label>
                </div>

            </div>
            <div class="label-transactions">
                <asp:Label ID="lblTransactions" runat="server" Text="Account transactions"></asp:Label>
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
