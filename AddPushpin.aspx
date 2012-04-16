<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPushpin.aspx.cs" Inherits="CBIT_group8.AddPushpin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Pushin to CorkBoard</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat = "server" ID = "lblAddPP" Text = "Add PushPin"></asp:Label>
        <br />
        <asp:Label runat = "server" ID = "lblCBName" Text = "G"></asp:Label>
        <br />
        <asp:Label runat = "server" ID = "lblURL" Text = "URL"></asp:Label>
        <asp:TextBox runat = "server" ID = "txtURL"></asp:TextBox>
        <asp:RequiredFieldValidator runat ="server" ControlToValidate = "txtURL" ErrorMessage = "URL is mandatory"></asp:RequiredFieldValidator>
        <br />
        <asp:Label runat = "server" ID = "lblDescription" Text = "Description"></asp:Label>
        <asp:TextBox runat = "server" ID = "txtDesc" MaxLength="200" 
            ontextchanged="txtDesc_TextChanged"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat ="server" ControlToValidate = "txtDesc" ErrorMessage = "Description is mandatory"></asp:RequiredFieldValidator>
        <br />
        <asp:Label runat = "server" ID = "lblTags" Text = "Tags"></asp:Label>
        <asp:TextBox runat = "server" ID = "txtTags"></asp:TextBox>
        <br />
        <asp:Button runat = "server" ID = "btnAdd" Text = "Add" 
            onclick="btnAdd_Click" />

    </div>
    </form>
</body>
</html>
