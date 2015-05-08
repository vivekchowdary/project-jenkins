
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Untitled Document</title>
<link href="stylelog.css" rel="stylesheet" type="text/css" />
</head>

<body bgcolor="#616161">

  <form id="form1" name="form1"  runat=server>
   <table width="100%" border="1" cellspacing="0" cellpadding="0" style="top:2050">
  <tr><td><img src="HouseAd_NMG_300x250_v03.gif" style="width: 650px" /></td>
    <td> 
   <div id="div1" style="width:5%;height:5%">
     <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate"  DestinationPageUrl="~/Home.aspx" style="width=50px; Height=50px">
     </asp:Login>
    </div>
 </td>
  </tr>
</table>
      
</form>

</body>
</html>