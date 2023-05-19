<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LogIn.aspx.vb" Inherits="Bank.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <link href="/CSS/LogIn.css" rel="stylesheet" type="text/css" />
</head>
<body>

    <form runat="server">
        <div class="login-box">
            <h1>Login</h1>
            <div class="textbox">
                <i class="fas fa-user"></i>
                <asp:TextBox ID="UsernameTextBox" runat="server" placeholder="Username"></asp:TextBox>
            </div>
            <div class="textbox">
                <i class="fas fa-lock"></i>
                <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
            </div>
            <asp:Button ID="LoginButton" runat="server" Text="Log In" OnClick="LoginButton_Click" />
            <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
            <div class="register-link">
                 <a href="/Webforms/Register.aspx">Don't have an account? Register</a>
            </div>
        </div>
    </form>

</body>
</html>
