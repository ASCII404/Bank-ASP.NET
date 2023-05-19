<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="New_BankTransactions.aspx.vb" Inherits="Bank.New_BankTransactions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/CSS/main_page.css" rel="stylesheet" type="text/css">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
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
        <div>
        </div>
    </form>
    <footer>
        <p>&copy; 2023 Bank. All rights reserved.</p>
    </footer>
    <script src="/JS/page_functionality.js" defer></script>
    <script src="/JS/LogIn_session.js"></script>
</body>
</html>
