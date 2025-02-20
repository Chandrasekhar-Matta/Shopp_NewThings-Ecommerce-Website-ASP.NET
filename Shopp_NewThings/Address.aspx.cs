using System;
using System.Collections.Generic;
using System.Data;
using DataAccessLayer;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using System.Security.Cryptography;
using System.Configuration;
using System.Data.SqlClient;

namespace Shopp_NewThings
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProductDetails();
                
            }
            addNewAddress.Visible = false;
            lnkbAddYourAddress.Visible = false;
        }
        ProductViewBL productViewBL = new ProductViewBL();
        private void BindProductDetails()
        {
            if (Request.Cookies["CartPID"] != null)
            {
                string CookieData = Request.Cookies["CartPID"].Value.Split('=')[1];
                string[] CookieDataArray = CookieData.Split(',');
                if (CookieDataArray.Length > 0)
                {
                    h5NoItems.InnerText = "MY Product (" + CookieDataArray.Length + " Items)";
                    DataTable dtBrands = new DataTable();
                    Int64 CartTotal = 0;
                    Int64 Total = 0;
                    for (int i = 0; i < CookieDataArray.Length; i++)
                    {
                        Int64 PID = Convert.ToInt64( CookieDataArray[i].ToString().Split('-')[0]);
                     
                        String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(CS))
                        {
                            using (SqlCommand cmd = new SqlCommand("select * from tblProducts where PID =" + PID + "", con))
                            {
                                cmd.CommandType = CommandType.Text;

                                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                                {
                                    sda.Fill(dtBrands);
                                }
                            }
                        }
                        CartTotal += Convert.ToInt64(dtBrands.Rows[i]["PPrice"]);
                        Total += Convert.ToInt64(dtBrands.Rows[i]["PSelPrice"]);
                    }
                    rptrProductDetails.DataSource = dtBrands;
                    rptrProductDetails.DataBind();
                    divPriceDetails.Visible = true;
                    spanCartTotal.InnerText = CartTotal.ToString();
                    spanTotal.InnerText = "Rs. " + Total.ToString();
                    spanDiscount.InnerText = "- " + (CartTotal - Total).ToString();

                }
            } 
               
        }

        protected void lnkbAddNewAddress_Click(object sender, EventArgs e)
        {
            addNewAddress.Visible = true;
            addYourAddress.Visible = false;
            lnkbAddYourAddress.Visible = true;
            lnkbAddNewAddress.Visible = false;

        }

        protected void lnkbAddYourAddress_Click(object sender, EventArgs e)
        {
            addNewAddress.Visible = false;
            addYourAddress.Visible = true;
            lnkbAddNewAddress.Visible = true;
            lnkbAddYourAddress.Visible = false;
        }
    }
}