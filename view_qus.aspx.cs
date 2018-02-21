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
    public partial class view_qus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "<b><font color=Brown>" + "WELLCOME STAFF:: " + "</font>" + "<b><font color=red>" + Session["staff_id"] + "</font>";

            if (!IsPostBack)
            {
               /* SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=qus;User ID=sa;Password=admin123");

                con.Open();
                string id = Session["staff_id"].ToString();
                string com = "Select tbl_sub.sub_id,tbl_sub.sub_name,tbl_sub_allot.allot_id from tbl_sub,tbl_sub_allot where tbl_sub.sub_name=tbl_sub_allot.sub_id and tbl_sub_allot.staff_id='" + id + "'";
                SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                ddlsub.DataSource = dt;
                ddlsub.DataBind();
                ddlsub.DataTextField = "sub_name";
                ddlsub.DataValueField = "sub_name";
                ddlsub.DataBind();
                con.Close();*/


                SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=qus;User ID=sa;Password=admin123");
                con.Open();
                string id = Session["staff_id"].ToString();
                string com = "Select tbl_sub.sub_id,tbl_sub.sub_name,tbl_sub_allot.allot_id from tbl_sub,tbl_sub_allot where tbl_sub.sub_name=tbl_sub_allot.sub_id and tbl_sub_allot.staff_id='" + id + "'";
                SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                ddlsub.DataSource = dt;
                ddlsub.DataBind();
                ddlsub.DataTextField = "sub_name";
                ddlsub.DataValueField = "sub_name";
                ddlsub.DataBind();
                con.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=qus;User ID=sa;Password=admin123");
            con.Open();
            string com = "SELECT module,topic,question,mark from tbl_qus where sub_id='" + ddlsub.SelectedValue + "'";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            grvqus.DataSource = dt;
            grvqus.DataBind();
            // this.Button2.Visible = true;
            con.Close();
        }

        protected void ddlsub_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=qus;User ID=sa;Password=admin123");

            con.Open();
            string com = "Select module from tbl_qus where sub_id='" + ddlsub.SelectedValue + "' ";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            ddlsub.DataSource = dt;
            ddlsub.DataBind();
            ddlsub.DataTextField = "module";
            ddlsub.DataValueField = "module";
            ddlsub.DataBind();
            con.Close();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
         
            Response.Redirect("staff_home.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=qus;User ID=sa;Password=admin123");

            con.Open();
            foreach (GridViewRow gvrow in grvqus.Rows)
            {

                CheckBox chck = gvrow.FindControl("CheckBox2") as CheckBox;
                if (chck.Checked)
                {
                    var Label = gvrow.FindControl("Label1") as Label;

                    SqlCommand cmd = new SqlCommand("delete from tbl_qus where id=@id", con);
                    cmd.Parameters.AddWithValue("id", int.Parse(Label2.Text));
                    con.Open();
                    int id = cmd.ExecuteNonQuery();
                    con.Close();
                    


                }
            }        
        }
    }
}