<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCorkboard.aspx.cs" Inherits="CBIT_group8.ViewCorkboard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h2>CORKBOARDIT</h2>
    <div>
        <asp:Label ID="lblName" runat="server"></asp:Label>
        &nbsp;
        <asp:Button ID="btnFollow" Text="Follow" runat="server" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblCategory" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblCBtitle" runat="server"></asp:Label>
        <br />
        Last Updated <asp:Label ID="lblDateTime" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAddPp" runat="server" Text="Add Pushpin" />
    </div>
    <div>
    <br /><br />
        <asp:PlaceHolder ID="phImageHolder" runat="server"></asp:PlaceHolder>
        <br /><br />
    </div>
      <p>
        This Corkboard has <asp:Label ID="lblWatchers" runat="server"></asp:Label> &nbsp;Watchers
        &nbsp;
        <asp:Button ID="btnWatch" runat="server" Text="Watch" />
    </p>
    </form>  
</body>
</html>
