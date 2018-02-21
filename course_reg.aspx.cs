using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace qmaster
{
    public partial class course_reg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=qus;User ID=sa;Password=admin123");

                con.Open();
                string com = "Select dept_name from tbl_dept";
                SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                ddldept.DataSource = dt;
                ddldept.DataBind();
                ddldept.DataTextField = "dept_name";
                ddldept.DataValueField = "dept_name";
                ddldept.DataBind();
                ddl1.DataSource = dt;
                ddl1.DataBind();
                ddl1.DataTextField = "dept_name";
                ddl1.DataValueField = "dept_name";
                ddl1.DataBind();
                con.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=qus;User ID=sa;Password=admin123");
            con.Open();
            string sql = "insert into tbl_course (course_id,course_name,dept_id) values('" + txtcode.Text.Trim() + "','" + txtname.Text.Trim() + "','" + ddldept.SelectedItem.Value + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=qus;User ID=sa;Password=admin123");
            con.Open();
            string com = "SELECT course_id,course_name,dept_id from tbl_course where dept_id = '" +ddl1.SelectedItem.Value + "'";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            gvcourse.DataSource = dt;
            gvcourse.DataBind();
            // this.Button2.Visible = true;
            con.Close();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            
                Session.Abandon();
                Session.Clear();
                Response.Redirect("admin_home.aspx");
            
        }
    }
}