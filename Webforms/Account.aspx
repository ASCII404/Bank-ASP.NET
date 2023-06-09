﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Account.aspx.vb" Inherits="Bank.Account" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Account</title>
    <link href="/CSS/main_page.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/Account.css" rel="stylesheet" type="text/css" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="/JS/page_functionality.js" defer></script>
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
    <form id="accountForms" runat="server">
        <div class="form-container">
            <div class="card-container">
                <div class="card">
                    <div class="card-header">
                        <h2>Account Options</h2>
                    </div>
                    <div class="card-body">
                        <asp:Button ID="btnTransactions" runat="server" Text="Banking Transactions" CssClass="form-button" OnClick="BankingTransactions" />
                        <asp:Button ID="btnNewAcc" runat="server" Text="New Bank Account" CssClass="form-button" OnClick="NewBankAccount" />
                        <asp:Button ID="btnNewTransaction" runat="server" Text="New Bank Transaction" CssClass="form-button" OnClick="NewTransactions" />
                        <asp:Button ID="btnAccountStatement" runat="server" Text="Account Statement" CssClass="form-button" OnClick="AccountStatement" />
                        <asp:Button ID="btnCounterparts" runat="server" Text="Counterparts Management" CssClass="form-button" OnClick="CounterpartsManagement" />
                    </div>
                </div>
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
