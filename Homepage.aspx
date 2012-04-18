<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="CBIT_group8.Homepage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script language="javascript" type="text/javascript">


    function SetButtonStatus(sender, target) {

        if (sender.value.length >= 1)

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
    <div>
        <h2>CORKBOARDIT  <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="http://www.digitaldarkness.com/images/logout.bw.png" Text="Log Out" NavigateUrl="~/Login.aspx"></asp:HyperLink></h2>
        <br />
        Home page for <asp:Label runat="server" ID="lblName" ></asp:Label>       
    </div>
    <br />
    <br />
    <div>
        Recent CorkBoard Updates
        <asp:Button ID="btnPopularTags" Text="Popular Tags" runat="server" 
            onclick="btnPopularTags_Click" />
        <br />
        <br />
        <asp:GridView ID="gvRecentCB" runat="server" ShowHeader="false" 
        onrowdatabound="gvRecentCB_RowDataBound" >        
        </asp:GridView>
    </div>
    <br />
    <div>
        My CorkBoards
        <asp:Button ID="btnAddCB" runat="server" Text="Add CorkBoard" 
            onclick="btnAddCB_Click" />
        <br />
        <br />
    </div>
    <div>
        <asp:GridView ID="gvMyCB" runat="server" ShowHeader="false" 
            onrowdatabound="gvMyCB_RowDataBound">
        </asp:GridView>
        <asp:Label ID="lblMyCB" runat="server"></asp:Label>
        <br />
        <br />
    </div>
    <div>
    <asp:TextBox ID="txtSearch" runat="server" onkeyup="SetButtonStatus(this, 'btnSearch')"></asp:TextBox>
    &nbsp;
    <asp:Button ID="btnSearch" runat="server" Text="PushPin Search" 
            onclick="btnSearch_Click"  Enabled="false"/>
    </div>
    </form>
</body>
</html>
