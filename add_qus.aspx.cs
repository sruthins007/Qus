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
    public partial class add_qus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "<b><font color=Brown>" + "WELLCOME STAFF:: " + "</font>" + "<b><font color=red>" + Session["staff_id"] + "</font>";

            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=qus;User ID=sa;Password=admin123");

                con.Open();
                string id = Session["staff_id"].ToString();
                string com = "Select tbl_sub.sub_id,tbl_sub.sub_name,tbl_sub_allot.allot_id from tbl_sub,tbl_sub_allot where tbl_sub.sub_name=tbl_sub_allot.sub_id and tbl_sub_allot.staff_id='" + id+"'";
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=qus;User ID=sa;Password=admin123");
            con.Open();
            string sql = "insert into tbl_qus (sub_id,module,topic,question,mark,complexity,lvl) values('" + ddlsub.SelectedValue + "','" + ddlmodule.SelectedValue + "','" + txttopic.Text.Trim() + "',N'" + txtqus.Text.Trim() + "','" + ddlmark.SelectedValue + "','" + ddlcom.SelectedValue + "','" + ddllvl.SelectedValue + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("staff_home.aspx");
        }

        
    }
}