<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Info.aspx.vb" Inherits="Bank.Info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/CSS/Info.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="card">
                <h1>Loan Application</h1>
                <div class="message-labels">
                    <asp:Label ID="lblMessage" runat="server" CssClass="message-label"></asp:Label>
                    <asp:label ID="lblMessageN" runat="server" CssClass="message-label"></asp:label>
                </div>
                <asp:Button ID="btnSubmit" runat="server" Text="Go back to loan calculator" CssClass="btn-submit" OnClick="btnSubmit_Click" />
            </div>
        </div>
    </form>
</body>
</html>
