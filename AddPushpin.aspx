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
        <br />
        <asp:Label runat = "server" ID = "lblDescription" Text = "Description"></asp:Label>
        <br />
        <asp:Label runat = "server" ID = "lblTags" Text = "Tags"></asp:Label>

    </div>
    </form>
</body>
</html>
