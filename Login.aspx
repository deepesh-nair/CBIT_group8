<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CBIT_group8.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        CORKBOARDIT<br /><br />
        <asp:Label ID="lblEmail" Text="Email" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br /><br />
        <asp:Label ID="lblPin" Text="PIN" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtPIN" runat="server" TextMode="Password"></asp:TextBox><br /><br />
        <asp:Label ID="lblResult" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnLogin" runat="server" Text="LOGIN" 
            onclick="btnLogin_Click" />
    </div>
    </form>
</body>
</html>
