using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using System.Net;

public partial class SendPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string str = "http://www.chandnas.co.in/pushsms.php?username=preeti&password=140976&sender=pr&cdmasender=9413676053&to=9413676053&message=hello";
        Response.Redirect(str,false);
    }
}
