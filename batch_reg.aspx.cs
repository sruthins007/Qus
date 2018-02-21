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
    public partial class batch_reg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                ddl1.DataSource = dt;
                ddl1.DataBind();
                ddl1.DataTextField = "course_name";
                ddl1.DataValueField = "course_name";
                ddl1.DataBind();
                con.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=qus;User ID=sa;Password=admin123");
            con.Open();
            string sql = "insert into tbl_batch (batch_name,course_id) values('" + txtbname.Text.Trim() + "','" + ddlcourse.SelectedItem.Value + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=qus;User ID=sa;Password=admin123");
            con.Open();
            string com = "SELECT course_id,batch_name from tbl_batch where course_id='" + ddl1.SelectedValue + "'";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            gvbatch.DataSource = dt;
            gvbatch.DataBind();
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