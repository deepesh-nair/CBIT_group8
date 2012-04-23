<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckPassword.aspx.cs" Inherits="CBIT_group8.CheckPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h2>CORKBOARDIT</h2>
    <div>
    This Corkboard is Private. Please Enter the Password to view it:
        <br />
    <br />
    Password: <asp:TextBox ID="txtpass" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblResult" runat="server" ForeColor="Red"></asp:Label>
        <br />
    <br />
    <asp:Button ID="btnOk" runat="server" Text="OK" onclick="btnOk_Click"/>
    &nbsp;&nbsp;
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"/>    
    </div>
    </form>
</body>
</html>
