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
    public partial class sub_allot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=qus;User ID=sa;Password=admin123");

                con.Open();
                string com = "Select staff_name,staff_id from tbl_staff where type = 'STAFF' ";
                SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                ddlstaff.DataSource = dt;
                ddlstaff.DataBind();
                ddlstaff.DataTextField = "staff_name";
                ddlstaff.DataValueField = "staff_id";
                ddlstaff.DataBind();
                con.Close();
            }
            
            if (!IsPostBack)
            {
                SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=qus;User ID=sa;Password=admin123");
                conn.Open();
                string comm = "Select course_name,course_id from tbl_course ";
                SqlDataAdapter adptt = new SqlDataAdapter(comm, conn);
                DataTable dtt = new DataTable();
                adptt.Fill(dtt);
                ddlcourse.DataSource = dtt;
                ddlcourse.DataBind();
                ddlcourse.DataTextField = "course_name";
                ddlcourse.DataValueField = "course_name";
                ddlcourse.DataBind();
                conn.Close();
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=qus;User ID=sa;Password=admin123");
            con.Open();
            string sql = "insert into tbl_sub_allot (sub_id,staff_id,course_id,batch_id) values('" + ddlsub.SelectedValue + "','" + ddlstaff.SelectedValue + "','" + ddlcourse.SelectedValue + "','" + ddlbatch.SelectedValue + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

    

       

        protected void ddlcourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=qus;User ID=sa;Password=admin123");

            con.Open();
            string com = "Select sub_name,sub_id from tbl_sub where course_id='" + ddlcourse.SelectedValue + "' ";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            ddlsub.DataSource = dt;
            ddlsub.DataBind();
            ddlsub.DataTextField = "sub_name";
            ddlsub.DataValueField = "sub_name";
            ddlsub.DataBind();
            com = "Select batch_name,batch_id from tbl_batch where course_id='" + ddlcourse.SelectedValue + "' ";
            adpt = new SqlDataAdapter(com, con);
            dt = new DataTable();
            adpt.Fill(dt);
            ddlbatch.DataSource = dt;
            ddlbatch.DataBind();
            ddlbatch.DataTextField = "batch_name";
            ddlbatch.DataValueField = "batch_name";
            ddlbatch.DataBind();
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