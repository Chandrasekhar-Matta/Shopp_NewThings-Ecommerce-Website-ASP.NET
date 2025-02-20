using BusinessLogicLayer;
using DataAccessLayer;
using DataObjectLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shopp_NewThings
{
    public partial class WebForm16 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMainCategory();
                BindSubCategoriesGrdView();
            }
        }
        addSubCategoryBL _addSubCategoryBL = new addSubCategoryBL();
        private void BindSubCategoriesGrdView()
        {
            grdVeiwSubCategories.DataSource = _addSubCategoryBL.BindSubCategoryGrdVw();
            grdVeiwSubCategories.DataBind();

        }
        private void BindMainCategory()
        {
            ddlBindMainCategoryDAL _ddlBindMainCategoryDAL = new ddlBindMainCategoryDAL();
            ddlMainCategory.DataSource = _ddlBindMainCategoryDAL.DdlBindMainCategory();
            ddlMainCategory.DataTextField = "MainCatName";
            ddlMainCategory.DataValueField = "MainCatID";
            ddlMainCategory.DataBind();
            ddlMainCategory.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        protected void ddlMainCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMainCategory != null)
            {
                int MainCategoryID = Convert.ToInt32(ddlMainCategory.SelectedItem.Value);
                BindCatByMainCat(MainCategoryID);

            }
        }

        private void BindCatByMainCat(int MainCategoryID)
        {
            if (ddlCategory != null)
            {
                ddlCategory.DataSource = _addSubCategoryBL.BindCatandMainCategory(MainCategoryID);
                ddlCategory.DataTextField = "CatName";
                ddlCategory.DataValueField = "CatID";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("-Select-", "0"));
            }
            else
            {
                ddlCategory.Items.Clear();
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
           
                shoppNewDOL shoppNewDOL = new shoppNewDOL()
                {
                    SubCategories = new SubCategory
                    {
                        SubCatName = txtSubCatName.Text,
                        MainCatID = Convert.ToInt32(ddlMainCategory.SelectedItem.Value),
                        CatID = Convert.ToInt32(ddlCategory.SelectedItem.Value)
                    }
                };

                _addSubCategoryBL.InsertSubCategory(shoppNewDOL);
                BindSubCategoriesGrdView();

           
                txtSubCatName.Text = string.Empty;
                ddlCategory.ClearSelection();
                ddlCategory.Items.FindByValue("0").Selected = true;
                BindSubCategoriesGrdView();
            
        }
        protected void grdVeiwSubCategories_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdVeiwSubCategories.EditIndex = e.NewEditIndex;
            BindSubCategoriesGrdView();
        }

        protected void grdVeiwSubCategories_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdVeiwSubCategories.EditIndex = -1;
            BindSubCategoriesGrdView();
        }

        protected void grdVeiwSubCategories_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label lblSubCatID = (Label)grdVeiwSubCategories.Rows[e.RowIndex].FindControl("lblSubCatID");
            TextBox txtEditSubCatName = (TextBox)grdVeiwSubCategories.Rows[e.RowIndex].FindControl("txtEditSubCatName");
            shoppNewDOL shoppNewDOL = new shoppNewDOL()
            {
                SubCategories = new SubCategory
                {
                    SubCatID = Convert.ToInt64(lblSubCatID.Text),
                    SubCatName = txtEditSubCatName.Text,
                }
            };
            _addSubCategoryBL.UpDateSubCategory(shoppNewDOL);
            grdVeiwSubCategories.EditIndex = -1;
            BindSubCategoriesGrdView();
        }

        protected void grdVeiwSubCategories_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label lblSubCatID = (Label)grdVeiwSubCategories.Rows[e.RowIndex].FindControl("lblSubCatID");
            shoppNewDOL objData = new shoppNewDOL()
            {
                SubCategories = new SubCategory
                {
                    SubCatID = Convert.ToInt64(lblSubCatID.Text),
                }
            };
            _addSubCategoryBL.DeleteSubCategory(objData);
            BindSubCategoriesGrdView();
        }
    }
}