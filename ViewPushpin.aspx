<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPushpin.aspx.cs" Inherits="CBIT_group8.ViewPushpin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h2>CORKBOARDIT</h2>
        <div>
            <asp:Label ID="lblName" runat="server"></asp:Label>
            &nbsp;
            <asp:Button ID="btnFollow" Text="Follow" runat="server" />
            <br />
            Pinned <asp:Label ID="lblDateTime" runat="server"></asp:Label> &nbsp;on <asp:HyperLink ID="hlCbtitle" runat="server"></asp:HyperLink>
        </div>
     </div>
     <br /><br />
     <asp:HyperLink ID="hlImage" runat="server"></asp:HyperLink>     
     <br /><br />
     <asp:Label ID="lblDesc" runat="server"></asp:Label>
     <br /><br />
     Tags: <asp:Label ID="lblTags" runat="server"></asp:Label>
     <br /><br />
     Likes: <asp:Label ID="lblLikes" runat="server"></asp:Label>
     &nbsp;<asp:Button ID="btnLike" runat="server" Text="Like!" />
    <br /><br />
    <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Height="53px" 
        Width="266px" ></asp:TextBox>
    &nbsp;
    <asp:Button ID="btnComment" runat="server" Text="Post Comment"/>
    <br /><br />
    <asp:GridView ID="gvComments" runat="server" ShowHeader="false"></asp:GridView>
    </form>
</body>
</html>
