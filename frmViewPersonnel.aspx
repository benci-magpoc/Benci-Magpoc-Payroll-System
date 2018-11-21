<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmViewPersonnel.aspx.cs" Inherits="frmViewPersonnel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/CIS407A_iLab_ACITLogo.jpg" PostBackUrl="~/frmMain.aspx" />
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="View Personnel"></asp:Label>
        <br />
        <asp:GridView ID="grdViewPersonnel" runat="server">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
