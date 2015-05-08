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

public partial class Masters_Student : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["SmsConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindcombo();
            bindgrid();

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string insertSql = "INSERT INTO Student_m(StudentName,FatherName,MotherName,Address,MobileNo,qualificationId) VALUES('" + txtname.Text.ToString() + "','" + txtfather.Text.ToString() + "','" + txtmother.Text.ToString() + "','" + txtAddress.Text.ToString() + "','" + txtmobile.Text.ToString() + "','"+ddlqualification.SelectedValue.ToString()+"')";
        using (SqlConnection myConnection = new SqlConnection(connectionString))
        {
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand(insertSql, myConnection);
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            bindgrid();
            txtname.Text = "";
            txtfather.Text = "";
            txtmobile.Text = "";
            txtmother.Text = "";
            txtAddress.Text = "";
        }
    }


    private void bindgrid()
    {
        string sql = "select student_m.* ,Qualification_m.name from student_m left join  Qualification_m on student_m.QualificationId=Qualification_m.Id";
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

     protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        bindgrid();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex =-1;
        bindgrid();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txtname = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtname");
        TextBox txtfathername = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtfathername");

        TextBox txtmothername = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtmothername");

        TextBox txtmobileno = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtmobileno");

        TextBox txtAddress = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtAddress");
        Guid unqid = new Guid(GridView1.DataKeys[e.RowIndex].Value.ToString());
        if (txtname != null)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SmsConnectionString"].ConnectionString;
            string updateSql = "update student_m set StudentName='" + txtname.Text.ToString() + "', Fathername='" + txtfathername.Text.ToString()+"',Mothername='" + txtmothername.Text.ToString() + "',Address='" + txtAddress.Text.ToString() + "',MobileNo='" + txtmobileno.Text.ToString() + "'where Id='" + unqid + "'";
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
