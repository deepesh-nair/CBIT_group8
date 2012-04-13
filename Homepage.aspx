<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="CBIT_group8.Homepage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Home page for <asp:Label runat="server" ID="lblName" ></asp:Label>
    </div>
    <br />
    <div>
        CORKBOARDIT
    </div>
    <br />
    <div>
        Recent CorkBoard Updates
        <asp:Button ID="btnPopularTags" Text="Popular Tags" runat="server" />
        <br />
        <br />
        <asp:GridView ID="gvRecentCB" runat="server" ShowHeader="false" 
        onrowdatabound="gvRecentCB_RowDataBound" >        
        </asp:GridView>
    </div>
    <br />
    <div>
        My CorkBoards
        <asp:Button ID="btnAddCB" runat="server" Text="Add CorkBoard" />
        <br />
        <br />
    </div>
    <div>
        <asp:GridView ID="gvMyCB" runat="server" ShowHeader="false" 
            onrowdatabound="gvMyCB_RowDataBound">
        </asp:GridView>
        <br />
    </div>
    <div>
    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
    &nbsp;
    <asp:Button ID="btnSearch" runat="server" Text="PushPin Search" />
    </div>
    </form>
</body>
</html>
