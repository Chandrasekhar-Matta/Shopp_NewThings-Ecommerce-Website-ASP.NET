using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataObjectLayer;
using BusinessLogicLayer;

namespace Shopp_NewThings
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        addGenderBL _addGenderBL= new addGenderBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindBrandsRptr();

        }
        private void BindBrandsRptr()
        {
                     rptrCategory.DataSource = _addGenderBL.BindGendersRptr();
                        rptrCategory.DataBind();
                    
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            shoppNewDOL shoppNewDOL = new shoppNewDOL()
            {
                Genders = new Gender
                {
                    GenderName = txtGenderName.Text,
                }
            };
            _addGenderBL.InsertGenders(shoppNewDOL);
            txtGenderName.Text = string.Empty;
            BindBrandsRptr();

        }
    }
}