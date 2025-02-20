using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shopp_NewThings
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UNAME"] != null && Request.Cookies["PWD"] != null)
                {
                    txtEmail.Text = Request.Cookies["UNAME"].Value;
                    Password.Attributes["value"] = Request.Cookies["PWD"].Value;
                    CheckBox1.Checked = true;
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from tblUsers where Email='" + txtEmail.Text + "' and Password='" + Password.Text + "'", con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count != 0)
                {
                    Session["USERID"] = dt.Rows[0]["Uid"].ToString();
                    Session["USEREMAIL"] = dt.Rows[0]["Email"].ToString();

                    if (CheckBox1.Checked)
                    {
                        Response.Cookies["UNAME"].Value = dt.Rows[0]["FirstName"].ToString();
                        Response.Cookies["PWD"].Value = Password.Text;

                        Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(15);
                        Response.Cookies["PWD"].Expires = DateTime.Now.AddDays(15);
                    }
                    else
                    {
                        Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["PWD"].Expires = DateTime.Now.AddDays(-1);
                    }
                    string Utype;
                    Utype = dt.Rows[0][6].ToString().Trim();

                    if (Utype == "U")
                    {
                        Session["USERNAME"] = dt.Rows[0]["FirstName"].ToString();
                        if (Request.QueryString["rurl"] != null)
                        {
                            if (Request.QueryString["rurl"] == "cart")
                            {
                                Response.Redirect("~/Cart.aspx");
                            }
                        }
                        else
                        {
                            Response.Redirect("~/UserHome.aspx");
                        }
                    }
                    if (Utype == "A")
                    {
                        Session["USERNAME"] = dt.Rows[0]["FirstName"].ToString();
                        Response.Redirect("~/AdminHome.aspx");
                    }


                }
                else
                {
                    lblError.Text = "Invalid Username or Password !";
                }
            }
        }
    }
}