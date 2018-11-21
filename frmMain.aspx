<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmMain.aspx.cs" Inherits="frmMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/Images/CIS407A_iLab_ACITLogo.jpg" NavigateUrl="~/frmMain.aspx">HyperLink</asp:HyperLink>
    
    </div>
        <asp:Panel ID="Panel1" runat="server" Height="1400px" Width="500px">
            <asp:ImageButton ID="imgbtnCalculator" runat="server" ImageUrl="~/Images/calculator.jpg" PostBackUrl="~/frmSalaryCalculator.aspx" />
            &nbsp;<asp:LinkButton ID="lnkbtnCalculator" runat="server" PostBackUrl="~/frmSalaryCalculator.aspx">Annual Salary Calculator</asp:LinkButton>
            <br />
            <asp:ImageButton ID="imgbtnNewEmployee" runat="server" height="180px" ImageUrl="~/Images/newemployee.jpg" PostBackUrl="~/frmPersonnel.aspx" width="180px" />
            &nbsp;<asp:LinkButton ID="lnkbtnNewEmployee" runat="server" PostBackUrl="~/frmPersonnel.aspx">Add New Employee</asp:LinkButton>
            <br />
            <asp:ImageButton ID="imgbtnUserActivity" runat="server" Height="180px" ImageUrl="~/Images/userActivity.jpg" PostBackUrl="~/frmUserActivity.aspx" Width="180px" />
            <asp:LinkButton ID="lnkbtnUserActivity" runat="server" PostBackUrl="~/frmUserActivity.aspx">View User Activity</asp:LinkButton>
            <br />
            <asp:ImageButton ID="imgbtnViewPersonnel" runat="server" Height="180px" ImageUrl="~/Images/employees.jpg" PostBackUrl="~/frmViewPersonnel.aspx" Width="180px" />
            <asp:LinkButton ID="lnkbtnViewPersonnel" runat="server" PostBackUrl="~/frmViewPersonnel.aspx">View Personnel</asp:LinkButton>
            <br />
            <asp:ImageButton ID="imgbtnSearch" runat="server" Height="180px" ImageUrl="~/Images/search.jpg" PostBackUrl="~/frmSearchPersonnel.aspx" Width="180px" />
            <asp:LinkButton ID="lnkbtnSearch" runat="server" PostBackUrl="~/frmSearchPersonnel.aspx">Search Personnel</asp:LinkButton>
            <br />
            <asp:ImageButton ID="imgbtnEditEmployees" runat="server" Height="180px" ImageUrl="~/Images/editemployees.jpg" PostBackUrl="~/frmEditPersonnel.aspx" Width="180px" />
            <asp:LinkButton ID="lnkbtnEditEmployees" runat="server" PostBackUrl="~/frmEditPersonnel.aspx">Edit Personnel</asp:LinkButton>
            <br />
            <asp:ImageButton ID="imgbtnManageUsers" runat="server" Height="180px" ImageUrl="~/Images/manageusers.jpg" PostBackUrl="~/frmManageUsers.aspx" Width="180px" />
            <asp:LinkButton ID="lnkbtnManageUsers" runat="server" PostBackUrl="~/frmManageUsers.aspx">Manage Users</asp:LinkButton>
        </asp:Panel>
    </form>
</body>
</html>
