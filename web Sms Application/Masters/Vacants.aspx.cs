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

public partial class Masters_Vacants : System.Web.UI.Page
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


        string insertSql = "INSERT INTO Vacancy_m(VacancyName,VacancyDescription,VacancyDate,VacancyLastDate) VALUES('" + txtname.Text.ToString() + "','" + txtDescription.Text.ToString() + "','" + Convert.ToDateTime(txtDate.Text.ToString()) + "','" + Convert.ToDateTime(txtenddate.Text.ToString()) + "')";
        using (SqlConnection myConnection = new SqlConnection(connectionString))
        {
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand(insertSql, myConnection);
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            bindgrid();
            txtname.Text = "";
            txtDescription.Text = "";
            txtDate.Text = "";
            txtenddate.Text = "";
        }
    }


    private void bindgrid()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["SmsConnectionString"].ConnectionString;
        string sql = "select * from Vacancy_m";
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
        TextBox txtname = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtname");
        TextBox txtDescription = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtDescription");
        TextBox txtDate = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtDate");
        TextBox txtEndDate = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEndDate");

        Guid unqid = new Guid(GridView1.DataKeys[e.RowIndex].Value.ToString());
        if (txtname != null)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SmsConnectionString"].ConnectionString;
            string updateSql = "update Vacancy_m set VacancyName='" + txtname.Text.ToString() + "',VacancyDescription='" + txtDescription + "',VacancyDate='" + Convert.ToDateTime(txtDate.Text.ToString()) + "',VacancyLastDate='" + Convert.ToDateTime(txtEndDate.Text.ToString()) + "' where Id='" + unqid + "'";
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

