<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPushpin.aspx.cs" Inherits="CBIT_group8.ViewPushpin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script language="javascript" type="text/javascript">


function SetButtonStatus(sender, target)

{

if ( sender.value.length >= 1 )

document.getElementById(target).disabled = false;

else

document.getElementById(target).disabled = true;

}

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
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
     <asp:UpdatePanel runat="server">
     <ContentTemplate>
         Likes: <asp:Label ID="lblLikes" runat="server"></asp:Label>
         &nbsp;<asp:Button ID="btnLike" runat="server" Text="Like" 
            onclick="btnLike_Click" />
    </ContentTemplate>
    </asp:UpdatePanel>
    <br /><br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Height="53px" 
        Width="266px" onkeyup="SetButtonStatus(this, 'btnComment')" ></asp:TextBox>
        &nbsp;    
        <asp:Button ID="btnComment" runat="server" Text="Post Comment" Enabled="false" 
            onclick="btnComment_Click"/>
        <br /><br />
        <asp:GridView ID="gvComments" runat="server" ShowHeader="false"></asp:GridView>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
