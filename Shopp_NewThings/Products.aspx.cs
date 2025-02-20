using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;

namespace Shopp_NewThings
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Int64 PCatID = Request.QueryString["cat"] == null ? 0 : Convert.ToInt64(Request.QueryString["cat"]);
            Int64 PSubCatID = Request.QueryString["subcat"] == null ? 0 : Convert.ToInt64(Request.QueryString["subcat"]);

            if (!IsPostBack)
            {
                BindProductRepeater(PCatID, PSubCatID);
            }
        }
        private void BindProductRepeater(Int64 Sub1CatID, Int64 Sub2CatID)
        {

                        ProductsBL productsBL = new ProductsBL();
                        rptrProducts.DataSource = productsBL.BindProductRepeater(Sub1CatID, Sub2CatID);
                        rptrProducts.DataBind();
        }
    }
}