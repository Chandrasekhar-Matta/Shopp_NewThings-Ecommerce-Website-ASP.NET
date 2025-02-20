using System;
using DataObjectLayer;
using BusinessLogicLayer;
using DataAccessLayer;
using System.Web.UI.WebControls;
namespace Shopp_NewThings
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBrandsGrdView();
                BindMainCategory();
            }
        }
        addBrandsBL addBrandBL = new addBrandsBL();
        ddlBindMainCategoryDAL _ddlBindMainCategoryDAL = new ddlBindMainCategoryDAL();
        private void BindMainCategory()
        {
            ddlMainCategory.DataSource = _ddlBindMainCategoryDAL.DdlBindMainCategory();
            ddlMainCategory.DataTextField = "MainCatName";
            ddlMainCategory.DataValueField = "MainCatID";
            ddlMainCategory.DataBind();
            ddlMainCategory.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        protected void ddlMainCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int MainCategoryID = Convert.ToInt32(ddlMainCategory.SelectedItem.Value);
            BindCatByMainCat(MainCategoryID);
        }
        protected void BindCatByMainCat(int MainCategoryID)
        {
            ddlCategory.DataSource = addBrandBL.BindCatByMainCat(MainCategoryID);
            ddlCategory.DataTextField = "CatName";
            ddlCategory.DataValueField = "CatID";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        private void BindBrandsGrdView()
        {
            grdVeiwBrands.DataSource = addBrandBL.BindBrandGrdV();
            grdVeiwBrands.DataBind();           
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            
                shoppNewDOL objData = new shoppNewDOL()
                {
                    Brands = new Brand
                    {
                        BrandName = txtBrandName.Text,
                        MainCatId = Convert.ToInt32(ddlMainCategory.SelectedItem.Value),
                        CatId = Convert.ToInt32(ddlCategory.SelectedItem.Value)
                    }
                };
                addBrandBL.ADDBrands(objData);
                BindBrandsGrdView();
            
        }
        protected void grdVeiwBrands_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdVeiwBrands.EditIndex = e.NewEditIndex;
            BindBrandsGrdView();
        }
        protected void grdVeiwBrands_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdVeiwBrands.EditIndex = -1;
            BindBrandsGrdView();
        }
        protected void grdVeiwBrands_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtEditBrandName = (TextBox)grdVeiwBrands.Rows[e.RowIndex].FindControl("txtEditBrandName");
            Label lblBrandID = (Label)grdVeiwBrands.Rows[e.RowIndex].FindControl("lblBrandID");
            shoppNewDOL objData = new shoppNewDOL()
            {
                Brands = new Brand
                {
                    BrandID = Convert.ToInt32(lblBrandID.Text),
                    BrandName = txtEditBrandName.Text
                }
            };
            addBrandBL.UPDateBrands(objData);
            grdVeiwBrands.EditIndex = -1;
            BindBrandsGrdView();
        }

        protected void grdVeiwBrands_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label lblEditBrandID = (Label)grdVeiwBrands.Rows[e.RowIndex].FindControl("lblEditBrandID");
           
            shoppNewDOL objData = new shoppNewDOL()
            {
                Brands = new Brand
                {
                    BrandID = Convert.ToInt32(lblEditBrandID.Text)
                }
            };
            addBrandBL.DeleteBrands(objData);
            BindBrandsGrdView();
        }

       
    }
}