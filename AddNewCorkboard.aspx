<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewCorkboard.aspx.cs" Inherits="CBIT_group8.AddNewCorkboard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Corkboard</title>
</head>
<body>
    <form id="form1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server"/>
    <div>
        <asp:Label runat = "server" ID = "lblCB" >Add Corkboard </asp:Label>
        <br />
        <asp:Label runat = "server" ID = "lblTitle" >Title</asp:Label>
        <asp:TextBox runat = "server" ID = "txtTitle"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle" ErrorMessage="Title is mandatory"></asp:RequiredFieldValidator>
        <br />
        <asp:Label runat = "server" ID = "lblCategory" >Category</asp:Label>
        <asp:DropDownList runat = "server" ID = "ddlCategory">
            <asp:ListItem Selected = "True">Select a Category</asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator runat = "server" ControlToValidate = "ddlCategory" ErrorMessage = "Choose a category" InitialValue = "Select a Category"></asp:RequiredFieldValidator>  
        <br />
        <asp:Label runat = "server" ID = "lblVisibility" >Visibility</asp:Label>
          
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <asp:RadioButton runat ="server"  ID = "rbPublic" GroupName = "publicOrPvt" 
                Text = "Public" AutoPostBack="true" oncheckedchanged="rbPublic_CheckedChanged"/>
        <br />
            <asp:RadioButton runat = "server" ID = "rbPrivate" GroupName = "publicOrPvt" 
                Text = "Private" AutoPostBack="true" 
                oncheckedchanged="rbPrivate_CheckedChanged" />        
            <asp:TextBox runat = "server" ID = "txtPassword" TextMode="Password" 
                Enabled="False"></asp:TextBox>
        </ContentTemplate>
        </asp:UpdatePanel>

        <asp:Label runat = "server" ID = "lblEmptyPassword" ></asp:Label>
        <br />
        <asp:Button runat = "server" ID = "btnAdd" Text = "Add" 
            onclick="btnAdd_Click" />
    </div>

    </form>

</body>
</html>
