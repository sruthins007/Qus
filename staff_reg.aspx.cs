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
    public partial class staff_reg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=qus;User ID=sa;Password=admin123");

                con.Open();
                string com = "Select dept_name,dept_id from tbl_dept";
                SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                ddldept.DataSource = dt;
                ddldept.DataBind();
                ddldept.DataTextField = "dept_name";
                ddldept.DataValueField = "dept_name";
                ddldept.DataBind();
                con.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=qus;User ID=sa;Password=admin123");
            con.Open();
            string sql = "insert into tbl_staff (staff_id,staff_name,dept_id,username,password,type) values('" + txtid.Text.Trim() + "','" + txtname.Text.Trim() + "','" + ddldept.SelectedItem.Value + "','" + txtusername.Text.Trim() + "','" + txtpassword.Text.Trim() + "','" + ddlType.SelectedItem.Value + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            txtid.Text = String.Empty;
            txtname.Text = String.Empty;
            txtusername.Text = String.Empty;
            txtpassword.Text = String.Empty;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=qus;User ID=sa;Password=admin123");
            con.Open();
            string com = "SELECT staff_id,staff_name,username,dept_id from tbl_staff where type = 'STAFF'";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            gvstaff.DataSource = dt;
            gvstaff.DataBind();
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