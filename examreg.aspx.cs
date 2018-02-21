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
    public partial class examreg : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=qus;User ID=sa;Password=admin123");
        protected void Page_Load(object sender, EventArgs e)
        {
            

            con.Open();
            if (!IsPostBack)
            {
               
                string com = "Select course_name,course_id from tbl_course";
                SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                ddlcourse.DataSource = dt;
                ddlcourse.DataBind();
                ddlcourse.DataTextField = "course_name";
                ddlcourse.DataValueField = "course_name";
                ddlcourse.DataBind();
               // con.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

           // SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=qus;User ID=sa;Password=admin123");
           // con.Open();
            string sql = "insert into tbl_exam (exam_name,duration,batch_id,course_id,sem_id,max_mark) values('" + txtname.Text.Trim() + "','" + txtdur.Text.Trim() + "','" + ddlbatch.SelectedValue + "','" + ddlcourse.SelectedValue + "','" + ddlsem.SelectedValue + "','" + txtmark.Text.Trim() + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        protected void ddlcourse_SelectedIndexChanged(object sender, EventArgs e)
        {
           // SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=qus;User ID=sa;Password=admin123");
            //con.Open();
            string com = "Select batch_name,batch_id from tbl_batch where course_id='" + ddlcourse.SelectedValue + "' ";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            ddlbatch.DataSource = dt;
            ddlbatch.DataBind();
            ddlbatch.DataTextField = "batch_name";
            ddlbatch.DataValueField = "batch_name";
            ddlbatch.DataBind();

            com = "Select sem_name,sem_id from tbl_sem where course_id ='" + ddlcourse.SelectedValue + "' ";
            adpt = new SqlDataAdapter(com, con);
            dt = new DataTable();
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
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=qus;User ID=sa;Password=admin123");
            con.Open();
            string com = "SELECT exam_name,course_id,batch_id,sem_id,max_mark from tbl_exam ";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            gvexam.DataSource = dt;
            gvexam.DataBind();
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