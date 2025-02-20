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
using DataObjectLayer;
using DataAccessLayer;

namespace Shopp_NewThings
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMainCategory();
                BindBrandsSize();
                ddlGender.Enabled = false;
            }
        }
        addSizeBL _addSizeBL= new addSizeBL();
        addGenderBL _addGenderBL = new addGenderBL();
        ddlBaindBrandsDAL _ddlBaindBrandsDAL = new ddlBaindBrandsDAL();
        ddlBindMainCategoryDAL _ddlBindMainCategoryDAL = new ddlBindMainCategoryDAL();
      

        private void BindMainCategory()
        {
            if (ddlMainCategory != null) 
            {
                ddlMainCategory.DataSource = _ddlBindMainCategoryDAL.DdlBindMainCategory();
                ddlMainCategory.DataTextField = "MainCatName";
                ddlMainCategory.DataValueField = "MainCatID";
                ddlMainCategory.DataBind();
                ddlMainCategory.Items.Insert(0, new ListItem("-Select-", "0"));
            }      
                
        }
        protected void ddlMainCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int MainCategoryID = Convert.ToInt32(ddlMainCategory.SelectedItem.Value);
            BindCatByMainCat(MainCategoryID);
        }
        private void BindCatByMainCat(int MainCategoryID)
        {
            if (ddlCategory != null)
            {
                ddlCategory.DataSource = _addSizeBL.BindCatbyMainCat(MainCategoryID);
                ddlCategory.DataTextField = "CatName";
                ddlCategory.DataValueField = "CatID";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("-Select-", "0"));
            }
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategory != null)
            {
                int MainCategoryID = Convert.ToInt32(ddlMainCategory.SelectedItem.Value);
                int CategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);
                BindBrandByMainCatAndCat(MainCategoryID, CategoryID);
                BindSubCatByMainCatNadCat(MainCategoryID, CategoryID);
            }
        }
        private void BindBrandByMainCatAndCat(int MainCategoryID, int CategoryID)
        {
            if (ddlBrand != null)
            {
                ddlBrand.DataSource = _ddlBaindBrandsDAL.BindBrandsByMainCatAndCat(MainCategoryID, CategoryID);
                ddlBrand.DataTextField = "BrandName";
                ddlBrand.DataValueField = "BrandID";
                ddlBrand.DataBind();
                ddlBrand.Items.Insert(0, new ListItem("-Select-", "0"));
            }
           
        }
        protected void BindSubCatByMainCatNadCat(int MainCategoryID, int CategoryID)
        {
            if (ddlSubCat != null)
            {

                ddlSubCat.DataSource = _addSizeBL.BindSubCatByMainCatAndcat(MainCategoryID, CategoryID);
                ddlSubCat.DataTextField = "SubCatName";
                ddlSubCat.DataValueField = "SubCatID";
                ddlSubCat.DataBind();
                ddlSubCat.Items.Insert(0, new ListItem("-Select-", "0"));
            }
          

        }

        protected void ddlSubCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindGender();
            ddlGender.Enabled = true;
        }
        private void bindGender()
        {
            if (ddlGender != null)
            {
                ddlGender.DataSource = _addGenderBL.BindGendersRptr();
                ddlGender.DataTextField = "Gendername";
                ddlGender.DataValueField = "GenderID";
                ddlGender.DataBind();
                ddlGender.Items.Insert(0, new ListItem("-Select-", "0"));
            }
            else
            {
                ddlGender.ClearSelection();
                ddlGender.Items.FindByValue("0").Selected = true;
                ddlGender.Items.Clear();
            }


        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            shoppNewDOL _shoppNewDOL = new shoppNewDOL() 
            {
                Sizes = new Size
                {
                    SizeName = txtSize.Text,
                    MainCategoryID = Convert.ToInt64(ddlMainCategory.SelectedItem.Value),
                    CategoryID = Convert.ToInt64(ddlCategory.SelectedItem.Value),
                    BrandID = Convert.ToInt32(ddlBrand.SelectedItem.Value),
                    SubCategoryID = Convert.ToInt64(ddlSubCat.SelectedItem.Value),
                    GenderID = Convert.ToInt32(ddlGender.SelectedItem.Value),
                }
            };

          
                addSizeBL _addSizeBL = new addSizeBL();
                _addSizeBL.InsertSize(_shoppNewDOL);
                BindBrandsSize();

                //ckblSizeName.Text = string.Empty;
                ddlBrand.ClearSelection();
                ddlBrand.Items.FindByValue("0").Selected = true;
                ddlCategory.ClearSelection();
                ddlCategory.Items.FindByValue("0").Selected = true;
            ddlMainCategory.ClearSelection();
            ddlMainCategory.Items.FindByValue("0").Selected = true; 
                ddlSubCat.ClearSelection();
                ddlSubCat.Items.FindByValue("0").Selected = true;
                ddlGender.ClearSelection();
                ddlGender.Items.FindByValue("0").Selected = true;

            
        }
        protected void BindBrandsSize()
        {
            rptrSize.DataSource = _addSizeBL.BindBrandSize();
            rptrSize.DataBind();

        }

    }
}