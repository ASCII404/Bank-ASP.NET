<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CounterpartsManagement.aspx.vb" Inherits="Bank.CounterpartsManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/CSS/main_page.css" rel="stylesheet" type="text/css">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">
    <style>
        #noclue {
            display: block;
            font-size: 18px;
            font-weight: bold;
            color: #333;
            margin-bottom: 10px;
            text-align: center;
    }
    </style>
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
            <asp:Label ID="noclue" runat="server" Text="Coming soon? I got no clue on what I am supposed to do on this page" Visible="true"></asp:Label>
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
