using System;
using System.Web;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using DataObjectLayer;
using Newtonsoft.Json;
using System.Linq;
using System.Diagnostics;

namespace Shopp_NewThings
{
     public partial class WebForm2 : System.Web.UI.Page
     {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["PID"] != null)
            {
                if (!IsPostBack)
                {
                    BindProductDetails();
                    BindProductImages();

                }
            }
            else
            {
                Response.Redirect("~/ProductView.aspx");
            }
        }
        ProductViewBL productViewBL = new ProductViewBL();
        private void BindProductDetails()
        {
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
            rptrProductDetails.DataSource = productViewBL.BindProductDetails(PID);
            rptrProductDetails.DataBind();
        }
        private void BindProductImages()
        {
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
            Repeater1.DataSource = productViewBL.BindProductImages(PID);
            Repeater1.DataBind();
        }

        protected string GetActiveClass(int ItemIndex)
        {
            if (ItemIndex == 0)
            {
                return "active";
            }
            else
            {
                return "";
            }
        }
        protected void rptrProductDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //string BrandID = (e.Item.FindControl("hfBrandID") as HiddenField).Value;
                //string CatID = (e.Item.FindControl("hfCatID") as HiddenField).Value;
                //string SubCatID = (e.Item.FindControl("hfSubCatID") as HiddenField).Value;
                //string GenderID = (e.Item.FindControl("hfGenderID") as HiddenField).Value;
                RadioButtonList rblSize = e.Item.FindControl("rblSize") as RadioButtonList;
                rptrProductSizesDetails( rblSize);

            }
        }
        public void rptrProductSizesDetails(RadioButtonList rblSize)
        {
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
            rblSize.DataSource = productViewBL.rptrProductSizesDetails(PID);
            rblSize.DataTextField = "SizeName";
            rblSize.DataValueField = "SizeID";
            rblSize.DataBind();
        }
         protected void btnAddToCart_Click(object sender, EventArgs e)
         {
            string SizeID = string.Empty;
            string SelectedQuantity = string.Empty;
            foreach (RepeaterItem item in rptrProductDetails.Items)
            {
                if(item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    var rbLitSize = item.FindControl("rblSize") as RadioButtonList;
                    SizeID = rbLitSize.SelectedItem.Value;
                    var Quantity = item.FindControl("txtQuantity") as TextBox;
                    SelectedQuantity =  Quantity.Text;
                    var lblError = item.FindControl("lblError") as Label;
                    lblError.Text = "";
                }
            }
            int PID = Convert.ToInt32(Request.QueryString["PID"]);

            if ( PID != 0 && !string.IsNullOrEmpty(SizeID) && !string.IsNullOrEmpty(SelectedQuantity))
            {
                AddUpdateCheckQunty(PID, SizeID, SelectedQuantity);
                
            } 
         }
        protected void AddUpdateCheckQunty(int PID, string SizeID, string SelectedQuantity)
        {
            if (Request.Cookies["CartPID"] !=null)
            {
                string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
                List<string> CookiePIDList = CookiePID.Split(',').Select(item => item.Trim()).Where(item => item != string.Empty).ToList();
                string[] CookieDataArray = CookiePID.Split(',');

                    for (int i = 0; i < CookieDataArray.Length; i++)
                    {
                        int PId = Convert.ToInt32(CookieDataArray[i].ToString().Split('-')[0]);
                        string SizePId = CookieDataArray[i].ToString().Split('-')[1];
                        string SizePIdQuty = CookieDataArray[i].ToString().Split('-')[2];

                        if (PID == PId && SizeID == SizePId)
                        {

                            string qutny = Convert.ToString(Convert.ToInt32(SizePIdQuty) + Convert.ToInt32(SelectedQuantity));
                            CookiePIDList[i] = PID + "-" + SizeID + "-" + qutny;
                            // Update the quantity for the corresponding PID and SizeID
                            string CookiePIDUpdated = string.Join(",", CookiePIDList.ToArray());
                            HttpCookie CartProducts = new HttpCookie("CartPID");
                            CartProducts.Values["CartPID"] = CookiePIDUpdated;
                            CartProducts.Expires = DateTime.Now.AddDays(1);
                            Response.Cookies.Add(CartProducts);
                            Response.Redirect("~/ProductView.aspx?PID=" + PID);

                        }
                    }

            }
            AddCookies(PID, SizeID, SelectedQuantity);
        }
        protected void AddCookies(int PID, string SizeID, string SelectedQuantity)
        {
            if (PID != 0 && !string.IsNullOrEmpty(SizeID) && !string.IsNullOrEmpty(SelectedQuantity))
            { 
                if (Request.Cookies["CartPID"] != null)
                {
                    string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
                    CookiePID = CookiePID + "," + PID + "-" + SizeID + "-" + SelectedQuantity;
                    HttpCookie CartProducts = new HttpCookie("CartPID");
                    CartProducts.Values["CartPID"] = CookiePID;
                    CartProducts.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(CartProducts);
                }
                else
                {
                    HttpCookie CartProducts = new HttpCookie("CartPID");
                    CartProducts.Values["CartPID"] = PID.ToString() + "-" + SizeID + "-" + SelectedQuantity;
                    CartProducts.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(CartProducts);
                }
                Response.Redirect("~/ProductView.aspx?PID=" + PID);
            }
            else
            {
                foreach (RepeaterItem item in rptrProductDetails.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        var lblError = item.FindControl("lblError") as Label;
                        lblError.Text = "Please select a size";
                    }
                }
            }
        }
       
     }
}