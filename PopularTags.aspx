﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PopularTags.aspx.cs" Inherits="CBIT_group8.PopularTags" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h2>CORKBOARDIT <asp:HyperLink ID="HyperLink1" ImageUrl="http://edmontonlocal.mobi/templates/mobiview/images/home.png" Text="Go to Homepage" runat="server" NavigateUrl="Homepage.aspx"></asp:HyperLink></h2>
    <div>
    <h4>Popular Tags</h4>
    <br /><br />
    <asp:GridView ID="gvTags" runat="server" onrowdatabound="gvTags_RowDataBound"></asp:GridView>
    </div>
    </form>
</body>
</html>
