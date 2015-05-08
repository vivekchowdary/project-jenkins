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
using System.IO;
using System.Net;


public partial class Transactions_SendMsg : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["SmsConnectionString"].ConnectionString;
 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindcombo();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
      
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        //sendmsg();
        string sql = "select * from student_m where QualificationId='" + ddlqualification.SelectedValue.ToString() + "'";
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        string mobilenos = "";
        using (SqlConnection myConnection = new SqlConnection(connectionString))
        {
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand(sql, myConnection);
            myCommand.ExecuteNonQuery();
            da.SelectCommand = myCommand;
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 1; i <= ds.Tables[0].Rows.Count; i++)
                {
                    if (i != ds.Tables[0].Rows.Count)
                    {
                        mobilenos = mobilenos + ds.Tables[0].Rows[i - 1]["MobileNo"].ToString() + ',';
                    }

                    else
                    {
                        mobilenos = mobilenos + ds.Tables[0].Rows[i - 1]["MobileNo"].ToString();

                    }
                }
            }

            myConnection.Close();

        }
        Session["flag"] = false;
        string str = "http://www.chandnas.co.in/pushsms.php?username=preeti&password=xxxxx&sender=pr&cdmasender=9413676053&to=" + mobilenos + "&message=" + txtmessage.Text.ToString() + "";


        try
        {
            //Create the request and send data to  SMS Server by HTTP connection
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(str);
            //Get response from SMS Gateway Server and read the answer
            HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
            System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = respStreamReader.ReadToEnd();
            respStreamReader.Close();
            myResp.Close();

            //inform the user
            textboxError.Text = responseString;
            textboxError.Visible = true;
        }
        catch (Exception)
        {
            //if sending request or getting response is not successful, Ozeki NG - SMS Gateway Server may not be running
            textboxError.Text = "SMS Server is not running!";
            textboxError.Visible = true;
        }

       //Response.Write("<iframe src="+ str +" width='500'>");
       //Response.Redirect("SendMsg.aspx");

        //ClientScript.RegisterClientScriptBlock(this.GetType(), "key", "<script>var mywindow=window.open('" + str + "');setTimeout('mywindow.close()',4000); </script>");
        txtmessage.Text = "";
        //ClientScript.RegisterClientScriptBlock(this.GetType(), "key", "<script>alert('Message Send Successfully'); </script>");
        Session["flag"] = true;
                
    }
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
       
    }

    private void bindcombo()
    {
        string sql = "select * from qualification_m";
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection myConnection = new SqlConnection(connectionString))
        {
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand(sql, myConnection);
            myCommand.ExecuteNonQuery();
            da.SelectCommand = myCommand;
            da.Fill(ds);
            ddlqualification.DataSource = ds;
            ddlqualification.DataBind();
            myConnection.Close();
        }
    }
        public string sendmsg()
        {
            string sql = "select * from student_m where QualificationId='" + ddlqualification.SelectedValue.ToString() + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            string mobilenos = "";
            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand(sql, myConnection);
                myCommand.ExecuteNonQuery();
                da.SelectCommand = myCommand;
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 1; i <= ds.Tables[0].Rows.Count; i++)
                    {
                        if (i != ds.Tables[0].Rows.Count)
                        {
                            mobilenos = mobilenos + ds.Tables[0].Rows[i - 1]["MobileNo"].ToString() + ',';
                        }

                        else
                        {
                            mobilenos = mobilenos + ds.Tables[0].Rows[i - 1]["MobileNo"].ToString();

                        }
                    }
                }
                myConnection.Close();

        }
            return ("http://www.chandnas.co.in/pushsms.php?username=preeti&password=140976&sender=pr&cdmasender=9829567898&to=" + mobilenos+"&message="+txtmessage.Text.ToString()+"");

        }
}

