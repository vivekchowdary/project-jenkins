<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SendMsg.aspx.cs" Inherits="Transactions_SendMsg" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border=1 width=100% bgcolor="#ffffff">
<tr><td colspan=2 align=center style="font-weight: bold" > Compose Message</td></tr>
<tr><td ><asp:Label ID="lblcategory" runat="server" Text="Category" Font-Bold=true>
                    </asp:Label></td><td>
                    
                
                    <asp:DropDownList ID="ddlqualification" runat="server" DataTextField="Name" DataValueField="Id" >
                    </asp:DropDownList></td>
                    </tr>


<tr><td><asp:Label ID="Label1" runat="server" Text="Message" Font-Bold=true>
                    </asp:Label></td><td><asp:TextBox ID="txtmessage" runat="server" TextMode=multiline></asp:TextBox></td></tr>
                    <tr><td colspan=2 align=center style="height: 21px"><asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" OnCommand="LinkButton1_Command">Send Message</asp:LinkButton></td></tr>
                    <tr style="visibility:hidden" ><td><asp:Label ID="lblTo" runat="server" Text="To" Font-Bold=true>
                    </asp:Label></td><td>   <asp:TextBox ID="txtto" runat="server"  ></asp:TextBox></td></tr>
</table>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Send" Visible=false />
    <asp:TextBox ID="textboxError" runat="server" Visible=false></asp:TextBox>
    
</asp:Content>

