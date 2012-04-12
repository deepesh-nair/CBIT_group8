<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="CBIT_group8.Homepage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Home page for 
    <asp:Label runat="server" ID="lblName" ></asp:Label>
    &nbsp;CORKBOARDIT<br />
        <br />
        Recent CorkBoard Updates
        <asp:Button ID="btnPopularTags" Text="Tags" runat="server" />

    </div>
    </form>
</body>
</html>
