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
using System.Data.SqlClient;
public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["SmsConnectionString"].ConnectionString;
        string checksql = "select * from users where UserName='" + Login1.UserName.ToString() + "' and password='" + Login1.Password.ToString() + "'";
        using (SqlConnection myConnection = new SqlConnection(connectionString))
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand(checksql, myConnection);
            myCommand.ExecuteNonQuery();
            da.SelectCommand = myCommand;
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                myConnection.Close();
                Response.Redirect("Home.aspx");

            }


            else
            {

                return;
            }
        }
    }
}
