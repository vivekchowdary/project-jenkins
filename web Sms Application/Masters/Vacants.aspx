<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Vacants.aspx.cs"
    Inherits="Masters_Vacants" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table align="center" border="1" bgcolor="#ffffff">
        <tr>
            <td colspan="2" align="center" style="font-size: la larger; font-weight: bold">
                Job Details</td>
            <tr>
                <td>
                    <asp:Label ID="lblVacancyname" runat="server" Text="Job Name" Font-Bold="true">
                    </asp:Label>
                    </td>
                <td style="width: 158px">
                    <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                    </td>
            </tr>
        <tr>
            <td style="height: 26px">
                <asp:Label ID="lblDescription" runat="server" Text="Desccription" Font-Bold="true">
                </asp:Label></td>
            <td style="width: 158px; height: 26px;">
                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDate" runat="server" Text="Posted Date" Font-Bold="true">
                </asp:Label></td>
            <td style="width: 158px">
                <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
            </td>
            <tr>
                <td>
                    <asp:Label ID="lblEndDate" runat="server" Text="End Date" Font-Bold="True">
                    </asp:Label>
                </td>
                <td style="width: 158px">
                    <asp:TextBox ID="txtenddate" runat="server"></asp:TextBox>
                </td>
            </tr>
        <tr>
            <td colspan="2" align="center" style="height: 26px">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save" BackColor="PeachPuff"
                    BorderStyle="Solid" Width="88px" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" width="100%">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                    BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px"
                    CellPadding="3" CellSpacing="2" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                    OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" AllowPaging="True"
                    OnPageIndexChanging="GridView1_PageIndexChanging" Width="271px">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" SortExpression="Id"
                            Visible="False" />
                        <asp:TemplateField HeaderText="Vacancy Name">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtname" runat="server" Text='<%# Eval("VacancyName") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblname" runat="server" Text='<%# Eval("VacancyName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Vacancy Description">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDescription" runat="server" Text='<%# Eval("VacancyDescription") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("VacancyDescription") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Vacancy Date">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDate" runat="server" Text='<%# Eval("VacancyDate","{0:MM/dd/yyyy}") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDate" runat="server" Text='<%# Eval("VacancyDate","{0:MM/dd/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Vacancy End Date">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEndDate" runat="server" Text='<%# Eval("VacancyLastDate","{0:MM/dd/yyyy}") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblEndDate" runat="server" Text='<%# Eval("VacancyLastDate","{0:MM/dd/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField HeaderText="Edit" ShowEditButton="True" ShowHeader="True" />
                    </Columns>
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" width="100%">
            </td>
        </tr>
    </table>
</asp:Content>
