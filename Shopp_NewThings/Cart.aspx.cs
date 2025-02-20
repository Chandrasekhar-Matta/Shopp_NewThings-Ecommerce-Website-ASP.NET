using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Reflection;

namespace Shopp_NewThings
{
    public partial class WebForm15 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCartProducts();
            }  
        }
        private void BindCartProducts()
        {
            if (Request.Cookies["CartPID"] != null)
            {
                string CookieData = Request.Cookies["CartPID"].Value.Split('=')[1];
                string[] CookieDataArray = CookieData.Split(',');
                if (CookieDataArray.Length >0)
                {
                    h5NoItems.InnerText = "MY CART (" + CookieDataArray.Length + " Items)";
                    DataTable dtBrands = new DataTable();
                    Int64 CartTotal = 0;
                    Int64 Total = 0;
                    for (int i = 0; i < CookieDataArray.Length; i++)
                    {
                        string PID = CookieDataArray[i].ToString().Split('-')[0];
                        string SizeID = CookieDataArray[i].ToString().Split('-')[1];
                        int Quantity = Convert.ToInt32( CookieDataArray[i].ToString().Split('-')[2]);

                        String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
                            using (SqlConnection con = new SqlConnection(CS))
                            {
                                using (SqlCommand cmd = new SqlCommand("select A.*,B.*,C.*, SizeName as SizeNamee,"+SizeID+ " as SizeIDD, " + Quantity + " as Quantities from tblProducts A inner join tblProductSizeQuantity C on C.SizeID =" + SizeID+ " cross apply(select top 1 * from tblProductImages B where B.PID = A.PID)B where A.PID =" + PID +"", con))
                                {
                                    cmd.CommandType = CommandType.Text;

                                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                                    {
                                        sda.Fill(dtBrands);
                                    }
                                }
                            }
                            CartTotal += Convert.ToInt64(dtBrands.Rows[i]["PPrice"]) * Quantity;
                            Total += Convert.ToInt64(dtBrands.Rows[i]["PSelPrice"]) * Quantity;
                    }

                    rptrCartProducts.DataSource = dtBrands;
                    rptrCartProducts.DataBind();
                    divPriceDetails.Visible = true;
                    spanCartTotal.InnerText = CartTotal.ToString();
                    spanTotal.InnerText = "Rs. " + Total.ToString();
                    spanDiscount.InnerText = "- " + (CartTotal - Total).ToString();
                        /*((CartTotal - Total) * 100 / CartTotal).ToString();*/
                }

                else
                {
                    //TODO Show Empty Cart
                    h5NoItems.InnerText = "Your Shopping Cart is Empty";
                    divPriceDetails.Visible = false;
                }
            }
            else
            {
                //TODO Show Empty Cart
                h5NoItems.InnerText = "Your Shopping Cart is Empty";
                divPriceDetails.Visible = false;
            }
           
        }

      
        protected void btnRemoveItem_Click(object sender, EventArgs e)
        {

            if (Request.Cookies["CartPID"] != null)
                    {
                string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
                Button btn = (Button)(sender);
                string PIDSIZE = btn.CommandArgument;

                List<String> CookiePIDList = CookiePID.Split(',').Select(i => i.Trim()).Where(i => i != string.Empty).ToList();
                CookiePIDList.Remove(PIDSIZE);
                string CookiePIDUpdated = String.Join(",", CookiePIDList.ToArray());
                if (CookiePIDUpdated != "")
                {
                    HttpCookie CartProducts = Request.Cookies["CartPID"];
                    CartProducts.Values["CartPID"] = CookiePIDUpdated;
                    CartProducts.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(CartProducts);

                }
                else
                {
                    HttpCookie CartProducts = Request.Cookies["CartPID"];
                    CartProducts.Values["CartPID"] = CookiePIDUpdated;
                    CartProducts.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(CartProducts);

                }
                Response.Redirect("~/Cart.aspx");
            }
        }
        string btnPIDMinusSizeId = string.Empty;
        string btnPlusPIDSizeID = string.Empty;
        protected void btnPlus_Click(object sender, EventArgs e)
        {
            Button btnPlus = (Button)(sender);
            btnPlusPIDSizeID = btnPlus.CommandArgument;
            UpdateQuantity();
        }

        protected void btnMinus_Click(object sender, EventArgs e)
        {
            Button btnMinus = (Button)(sender);
            btnPIDMinusSizeId = btnMinus.CommandArgument;
            UpdateQuantity();
        }
        int j = 0;
        int index = 0;
        string Quanty = string.Empty;
        string cartItems = string.Empty;
        protected void UpdateQuantity()
        {
            if (Request.Cookies["CartPID"] != null)
            {
                string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
                string[] CookieDataArray = CookiePID.Split(',');
                string[] parth1 = btnPlusPIDSizeID.Split(',');
                string[] parth2 = btnPIDMinusSizeId.Split(',');
                for ( j = 0; j < CookieDataArray.Length; j++)
                {
                    string PID = CookieDataArray[j].ToString().Split('-')[0];
                    string SizeID = CookieDataArray[j].ToString().Split('-')[1];

                    if (!string.IsNullOrEmpty(btnPlusPIDSizeID))
                    {
                        for (int k = 0; k < parth1.Length; k++)
                        {
                            string pid = parth1[k].ToString().Split('-')[0];
                            string sizepid = parth1[k].ToString().Split('-')[1];

                            if (PID == pid && SizeID == sizepid)
                            {
                                UpDateQutyTxt();
                            }
                        }
                    }
                    else if (!string.IsNullOrEmpty(btnPIDMinusSizeId))
                    {
                        for (int k = 0; k < parth2.Length; k++)
                        {
                            string pid = parth2[k].ToString().Split('-')[0];
                            string sizepid = parth2[k].ToString().Split('-')[1];
                            if (PID == pid && SizeID == sizepid)
                            {
                                UpDateQutyTxt();
                            }
                        }

                    }
                }

            }
            BindCartProducts();
        }
        protected void UpDateQutyTxt( )
        {
            if (Request.Cookies["CartPID"] != null)
            {
                string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
                List<string> CookiePIDList = CookiePID.Split(',').Select(item => item.Trim()).Where(item => item != string.Empty).ToList();
                for (int n = 0; n < rptrCartProducts.Items.Count; n++)
                {
                    index = j;
                    if (index != -1)
                    {
                        if (j == n)
                        {
                            var txtSeletedQuantity = rptrCartProducts.Items[n].FindControl("txtSeletedQuantity") as TextBox;
                            Quanty = txtSeletedQuantity.Text;
                            if (!string.IsNullOrEmpty(btnPlusPIDSizeID))
                            {
                                cartItems = btnPlusPIDSizeID;
                            }else if (!string.IsNullOrEmpty(btnPIDMinusSizeId))
                            {
                                cartItems = btnPIDMinusSizeId;
                            }
                            string cartItem = cartItems + "-" + Quanty;
                            CookiePIDList[index] = cartItem;
                            break;
                        }

                    }

                }
                // Update the quantity for the corresponding PID and SizeID

                string CookiePIDUpdated = string.Join(",", CookiePIDList.ToArray());

                if (CookiePIDUpdated != "")
                {
                    HttpCookie CartProducts = Request.Cookies["CartPID"];
                    CartProducts.Values["CartPID"] = CookiePIDUpdated;
                    CartProducts.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(CartProducts);
                }
                else
                {
                    HttpCookie CartProducts = Request.Cookies["CartPID"];
                    CartProducts.Values["CartPID"] = CookiePIDUpdated;
                    CartProducts.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(CartProducts);

                }

            }
        }
        protected void btnBuyNow_Click(object sender, EventArgs e)
        {
            if (Session["USERNAME"] != null)
            {
                Response.Redirect("~/Address.aspx");
            }
            else
            {
                Response.Redirect("~/SignIn.aspx?rurl=cart");
            }
        }

        
    }
}