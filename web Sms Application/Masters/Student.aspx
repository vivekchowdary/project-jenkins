
<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Student.aspx.cs"
    Inherits="Masters_Student" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table align="center" border="1" bgcolor="#ffffff" >
        <tr>
            <td colspan="2" align="center" style="font-size:la larger;font-weight:bold" >
                Student Details</td>
            <tr>
                <td>
                    <asp:Label ID="lblstudentname" runat="server" Text="Student Name" Font-Bold=true>
                    </asp:Label></td>
                <td style="width: 158px">
                    <asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
            </tr>
            
            <tr><td style="height: 26px">
                    <asp:Label ID="lblCategory" runat="server" Text="Category" Font-Bold=true>
                    </asp:Label></td>
                <td style="width: 158px; height: 26px;">
                    <asp:DropDownList ID="ddlqualification" runat="server" DataTextField="Name" DataValueField="Id" >
                    </asp:DropDownList>
                    </td></tr>
            
            <tr>
                <td>
                    <asp:Label ID="lblfathername" runat="server" Text="Father Name" Font-Bold=true>
                    </asp:Label></td>
                <td style="width: 158px">
                    <asp:TextBox ID="txtfather" runat="server"></asp:TextBox></td>
            </tr>
            
            
            
            
             <tr>
                <td>
                    <asp:Label ID="lblMotherName" runat="server" Text="Mother Name" Font-Bold="True"></asp:Label></td>
                <td style="width: 158px">
                    <asp:TextBox ID="txtmother" runat="server"></asp:TextBox></td>
            </tr>
            
            
            
             <tr>
                <td>
                    <asp:Label ID="lblAddress" runat="server" Text="Address" Font-Bold=true >
                    </asp:Label></td>
                <td style="width: 158px">
                    <asp:TextBox ID="txtAddress" runat="server" TextMode=MultiLine></asp:TextBox></td>
            </tr>
            
            
             <tr>
                <td>
                    <asp:Label ID="lblmobile" runat="server" Text="Mobile No" Font-Bold=true>
                    </asp:Label></td>
                <td style="width: 158px">
                    <asp:TextBox ID="txtmobile" runat="server"></asp:TextBox></td>
            </tr>
        <tr>
            <td colspan="2" align="center" style="height: 26px">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save" BackColor="PeachPuff" BorderStyle="Solid" Width="88px" /></td>
        </tr>
        <tr>
            <td colspan="2" align="center" width="100%">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  DataKeyNames="Id" BackColor="#DEBA84"
                    BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" PageSize="20">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" SortExpression="Id"
                            Visible="False" />
                        <asp:TemplateField HeaderText="Student Name">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtname" runat="server" Text='<%# Eval("StudentName") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblname" runat="server" Text='<%# Eval("StudentName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        
                        
                        
                        <asp:TemplateField HeaderText="Father Name">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtfathername" runat="server" Text='<%# Eval("FatherName") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblfathername" runat="server" Text='<%# Eval("FatherName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        
                        
                        
                         <asp:TemplateField HeaderText="Mother Name">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtmothername" runat="server" Text='<%# Eval("MotherName") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblMothername" runat="server" Text='<%# Eval("MotherName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        
                        
                         <asp:TemplateField HeaderText="Address">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtAddress" runat="server" Text='<%# Eval("Address") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        
                        
                         <asp:TemplateField HeaderText="MobileNo">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtMobileNo" runat="server" Text='<%# Eval("MobileNo") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblMobileNo" runat="server" Text='<%# Eval("MobileNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:BoundField DataField="name" HeaderText="Qualification" ReadOnly="True" SortExpression="name"
                             />
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
    </table>
</asp:Content>
