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

public partial class Masters_CreateUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            bindgrid();

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["SmsConnectionString"].ConnectionString;
        string checksql = "select * from users where UserName='" + txtusername.Text.ToString() + "'";
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

                ClientScript.RegisterClientScriptBlock(this.GetType(), "key", "<script>alert('This UserName Already Exists Choose Another'); </script>");

                return;
            }

        }

        string insertSql = "INSERT INTO Users(UserName,Password) VALUES('" + txtusername.Text.ToString() + "','"+txtpassword.Text.ToString()+"')";
        using (SqlConnection myConnection = new SqlConnection(connectionString))
        {
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand(insertSql, myConnection);
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            bindgrid();
            txtusername.Text = "";
            txtpassword.Text = "";
        }
    }


    private void bindgrid()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["SmsConnectionString"].ConnectionString;
        string sql = "select * from Users";
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection myConnection = new SqlConnection(connectionString))
        {
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand(sql, myConnection);


            myCommand.ExecuteNonQuery();
            da.SelectCommand = myCommand;
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            myConnection.Close();
        }



    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        bindgrid();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        bindgrid();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txtname = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtusername");
        Guid unqid = new Guid(GridView1.DataKeys[e.RowIndex].Value.ToString());
        if (txtname != null)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SmsConnectionString"].ConnectionString;
            string updateSql = "update Users set UserName='" + txtname.Text.ToString() + "' where Id='" + unqid + "'";
            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand(updateSql, myConnection);
                myCommand.ExecuteNonQuery();
                myConnection.Close();
                GridView1.EditIndex = -1;
                bindgrid();
            }
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        bindgrid();
    }
}

