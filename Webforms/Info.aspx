<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Info.aspx.vb" Inherits="Bank.Info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/CSS/Info.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="card">
                <h1>Message</h1>
                <asp:Label ID="lblMessage" runat="server" CssClass="message-label"></asp:Label>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn-submit" OnClick="btnSubmit_Click" />
            </div>
        </div>
    </form>
</body>
</html>
