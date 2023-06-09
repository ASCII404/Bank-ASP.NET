﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Register.aspx.vb" Inherits="Bank.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Page</title>
    <link href="/CSS/Register.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">
</head>
<body>
    <form runat="server">
        <div class="login-box">
            <h1>Register</h1>
            <div class="textbox">
                <i class="fas fa-user"></i>
                <asp:TextBox ID="UsernameTextBox" runat="server" placeholder="Username"></asp:TextBox>
            </div>
            <div class="textbox">
                <i class="fas fa-user"></i>
                <asp:TextBox ID="LastName" runat="server" placeholder="Last name"></asp:TextBox>
            </div>
            <div class="textbox">
                <i class="fas fa-user"></i>
                <asp:TextBox ID="FirstName" runat="server" placeholder="First Name"></asp:TextBox>
            </div>
            <div class="textbox">
                <i class="fas fa-envelope"></i>
                <asp:TextBox ID="EmailTextBox" runat="server" placeholder="Email"></asp:TextBox>
            </div>
            <div class="textbox">
                <i class="fas fa-lock"></i>
                <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
            </div>
            <asp:Button ID="RegisterButton" runat="server" Text="Create Account" OnClick="RegisterButton_Click" />
            <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
            <div class="login-link">
                <a href="/Webforms/LogIn.aspx">Already have an account? Log In</a>
            </div>
        </div>
    </form>
    <script src="https://kit.fontawesome.com/yourkitid.js" crossorigin="anonymous"></script>
</body>
</html>
