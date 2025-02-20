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
    public partial class ShoppNewThings : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindCartNumber();
            BindCategories();
            if (Session["USERNAME"] != null)
            {
                btnSignup.Visible = false;
                btnSignin.Visible = false;
                btnSignOut.Visible = true;
            }
            else
            {
                btnSignup.Visible = true;
                btnSignin.Visible = true;
                btnSignOut.Visible = false;
            }
        }
        public void BindCartNumber()
        {
            if (Request.Cookies["CartPID"] != null)
            {
                HttpCookie CookiePID = Request.Cookies["CartPID"];
                string[] ProductArray = CookiePID.Value.Split(',');
                int ProductCount = ProductArray.Length;
                pCount.InnerText = ProductCount.ToString();
            }
            else
            {
                pCount.InnerText = 0.ToString();
            }
        }

       
           
        
        public void BindCategories()
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("select * from tblCategories", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dtBrands = new DataTable();
                        sda.Fill(dtBrands);
                        rptCategory.DataSource = dtBrands;
                        rptCategory.DataBind();
                    }

                }
            }
        }

        protected void OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string catId = (e.Item.FindControl("hfCatId") as HiddenField).Value;
                Repeater rptSubCategories = e.Item.FindControl("rptSubCategories") as Repeater;

                String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    using (SqlCommand cmd = new SqlCommand(string.Format("SELECT * FROM tblSubCategories WHERE CatID='{0}'", catId), con))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dtBrands = new DataTable();
                            sda.Fill(dtBrands);
                            rptSubCategories.DataSource = dtBrands;
                            rptSubCategories.DataBind();
                        }

                    }
                }
            }
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Session["USERNAME"] = null;
            Session.Abandon();
            Response.Redirect("~/Home.aspx");
        }
    }
}