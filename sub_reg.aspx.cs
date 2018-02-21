using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace qmaster
{
    public partial class sub_reg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             //string connectionString = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
            if (!IsPostBack)
            {
               SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=qus;User ID=sa;Password=admin123");

                con.Open();
                string com = "Select course_name,course_id from tbl_course";
                SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                ddlcourse.DataSource = dt;
                ddlcourse.DataBind();
                ddlcourse.DataTextField = "course_name";
                ddlcourse.DataValueField = "course_name";
                ddlcourse.DataBind();
                con.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=qus;User ID=sa;Password=admin123");
            con.Open();
            string sql = "insert into tbl_sub (sub_id,sub_name,course_id,sem_id) values('" + txtcode.Text.Trim() + "','" + txtname.Text.Trim() + "','" + ddlcourse.SelectedValue + "','" + ddlsem.SelectedValue + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        protected void ddlcourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=qus;User ID=sa;Password=admin123");

            con.Open();
            string com = "Select sem_name,sem_id from tbl_sem where course_id='" + ddlcourse.SelectedValue + "' ";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            ddlsem.DataSource = dt;
            ddlsem.DataBind();
            ddlsem.DataTextField = "sem_name";
            ddlsem.DataValueField = "sem_name";
            ddlsem.DataBind();
            con.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("admin_home.aspx");
        }
    }
}