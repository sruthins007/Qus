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
    public partial class login : System.Web.UI.Page
    {
        int RowCount, id;
        string UserName, Password;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=qus;User ID=sa;Password=admin123");
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from tbl_staff", con);



            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new System.Data.DataTable();
            sda.Fill(dt);

            RowCount = dt.Rows.Count;

            for (int i = 0; i < RowCount; i++)
            {

                UserName = dt.Rows[i]["username"].ToString();

                Password = dt.Rows[i]["password"].ToString();
                id = Int32.Parse(dt.Rows[i]["staff_id"].ToString());


                if (UserName == txtname.Text && Password == txtpass.Text)
                {

                    Session["staff_id"] = id;

                    if (dt.Rows[i]["type"].ToString() == "ADMIN")

                        Response.Redirect("admin_home.aspx");

                    else if (dt.Rows[i]["type"].ToString() == "STAFF")

                        Response.Redirect("staff_home.aspx");



                }

                else
                {

                    Label1.Text = "Invalid User Name or Password! Please try again!";

                }

            }
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=qus;User ID=sa;Password=admin123");
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from tbl_staff", con);



            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new System.Data.DataTable();
            sda.Fill(dt);

            RowCount = dt.Rows.Count;

            for (int i = 0; i < RowCount; i++)
            {

                UserName = dt.Rows[i]["username"].ToString();

                Password = dt.Rows[i]["password"].ToString();
                id = Int32.Parse(dt.Rows[i]["staff_id"].ToString());


                if (UserName == txtname.Text && Password == txtpass.Text)
                {

                    Session["staff_id"] = id;

                    if (dt.Rows[i]["type"].ToString() == "ADMIN")

                        Response.Redirect("admin_home.aspx");

                    else if (dt.Rows[i]["type"].ToString() == "STAFF")

                        Response.Redirect("staff_home.aspx");



                }

                else
                {

                    Label1.Text = "Invalid User Name or Password! Please try again!";

                }
            }
        }
    }
}