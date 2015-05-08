<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CreateUsers.aspx.cs" Inherits="Masters_CreateUsers" Title="Untitled Page" %>
<asp:Content    ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table align=center border=1  bgcolor="#ffffff" style="width: 342px">
<tr><td colspan=2 align=center >Create Users</td>
<tr><td><asp:Label ID="lblname" runat="server" Text="User" Font-Bold="True"></asp:Label></td><td style="width: 158px"><asp:TextBox ID="txtusername" runat="server"></asp:TextBox></td></tr>
    
    
    <tr><td><asp:Label ID="lblpass" runat="server" Text="Password" Font-Bold="True"></asp:Label></td><td style="width: 158px"><asp:TextBox ID="txtpassword" runat="server" TextMode=Password></asp:TextBox></td></tr>
    <tr><td colspan=2 align=center style="height: 26px"><asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save" BackColor="PeachPuff" BorderStyle="Solid" Width="73px" /></td></tr>
    <tr><td colspan=2 align=center width=100%> <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns=False  DataKeyNames="Id" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" Width="271px">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" SortExpression="Id" Visible=False />
            <asp:TemplateField HeaderText="Users" >
                <EditItemTemplate>
                    <asp:TextBox ID="txtusername" runat="server" Text='<%# Eval("UserName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblusername" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField HeaderText="Edit" ShowEditButton="True" ShowHeader="True" />
        </Columns>
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
    </asp:GridView></td></tr>
    </table>
   
    
    
</asp:Content>

