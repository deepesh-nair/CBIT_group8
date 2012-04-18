<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCorkboard.aspx.cs" Inherits="CBIT_group8.ViewCorkboard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <h2>CORKBOARDIT <asp:HyperLink ID="HyperLink1" ImageUrl="http://edmontonlocal.mobi/templates/mobiview/images/home.png" Text="Go to Homepage" runat="server" NavigateUrl="Homepage.aspx"></asp:HyperLink></h2>    
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <asp:Label ID="lblName" runat="server"></asp:Label>
        &nbsp;
        <asp:Button ID="btnFollow" Text="Follow" runat="server" 
            onclick="btnFollow_Click" />            
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblCategory" runat="server"></asp:Label>
        </ContentTemplate>
            </asp:UpdatePanel>
        <br />
        <br />
        <asp:Label ID="lblCBtitle" runat="server"></asp:Label>
        <br />
        Last Updated <asp:Label ID="lblDateTime" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAddPp" runat="server" Text="Add Pushpin" 
            onclick="btnAddPp_Click" />
    </div>
    <div>
    <br /><br />
        <asp:PlaceHolder ID="phImageHolder" runat="server"></asp:PlaceHolder>
        <br /><br />
    </div>
      <p>
        <asp:UpdatePanel runat="server">
        <ContentTemplate>
        This Corkboard has <asp:Label ID="lblWatchers" runat="server"></asp:Label> &nbsp;Watchers
        &nbsp;
        <asp:Button ID="btnWatch" runat="server" Text="Watch" onclick="btnWatch_Click" />
        </ContentTemplate>
        </asp:UpdatePanel>
    </p>
    </form>  
</body>
</html>
