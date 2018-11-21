<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmManageUsers.aspx.cs" Inherits="frmManageUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/CIS407A_iLab_ACITLogo.jpg" PostBackUrl="~/frmMain.aspx" />
    <div>
    
        <asp:Panel ID="Panel1" runat="server" Height="500px" Width="600px">
            <asp:Label ID="Label1" runat="server" Text="Manage Users"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="User Name" width="100px"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Password" width="100px"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Security Level" Width="100px"></asp:Label>
            &nbsp;
            <asp:DropDownList ID="ddlSecurityLevel" runat="server" DataSourceID="SqlDataSource1" DataTextField="SecurityLevel" DataValueField="SecurityLevel">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btnAddUser" runat="server" OnClick="btnAddUser_Click" Text="Add User" />
            &nbsp;
            <asp:Label ID="lblError" runat="server"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="grdUsers" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="UserID">
                <Columns>
                    <asp:BoundField DataField="UserID" HeaderText="UserID" InsertVisible="False" SortExpression="UserID" ReadOnly="True" />
                    <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                    <asp:BoundField DataField="UserPassword" HeaderText="UserPassword" SortExpression="UserPassword" />
                    <asp:BoundField DataField="SecurityLevel" HeaderText="SecurityLevel" SortExpression="SecurityLevel" />
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PayrollSystem_DBConnectionString %>" ProviderName="<%$ ConnectionStrings:PayrollSystem_DBConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [tblUserLogin]" DeleteCommand="DELETE FROM [tblUserLogin] WHERE [UserID] = ?" InsertCommand="INSERT INTO [tblUserLogin] ([UserID], [UserName], [UserPassword], [SecurityLevel]) VALUES (?, ?, ?, ?)" UpdateCommand="UPDATE [tblUserLogin] SET [UserName] = ?, [UserPassword] = ?, [SecurityLevel] = ? WHERE [UserID] = ?">
                <DeleteParameters>
                    <asp:Parameter Name="UserID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="UserID" Type="Int32" />
                    <asp:Parameter Name="UserName" Type="String" />
                    <asp:Parameter Name="UserPassword" Type="String" />
                    <asp:Parameter Name="SecurityLevel" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="UserName" Type="String" />
                    <asp:Parameter Name="UserPassword" Type="String" />
                    <asp:Parameter Name="SecurityLevel" Type="String" />
                    <asp:Parameter Name="UserID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </asp:Panel>
&nbsp;&nbsp;&nbsp;
        <br />
    
    </div>
    </form>
</body>
</html>
