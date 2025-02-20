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
using DataAccessLayer;

namespace Shopp_NewThings
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategoryGrdView();
                BindMainCategory();
            }
        }
        addCategoryBL _addCategoryBL = new addCategoryBL();
        ddlBindMainCategoryDAL _ddlBindMainCategoryDAL = new ddlBindMainCategoryDAL();
        private void BindCategoryGrdView()
        {
            grdVeiwCategories.DataSource = _addCategoryBL.BindCategoryGrdVw();
            grdVeiwCategories.DataBind();
                    
        }
        private void BindMainCategory()
        {
            ddlMainCategory.DataSource = _ddlBindMainCategoryDAL.DdlBindMainCategory();
            ddlMainCategory.DataTextField = "MainCatName";
            ddlMainCategory.DataValueField = "MainCatID";
            ddlMainCategory.DataBind();
            ddlMainCategory.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            shoppNewDOL objDateDOL = new shoppNewDOL()
            {
                Categories = new Category
                {
                    CatName = txtCatName.Text,
                    MainCatID = Convert.ToInt64(ddlMainCategory.SelectedItem.Value)
                }
            };
            _addCategoryBL.InsertCategory(objDateDOL);
            BindCategoryGrdView();
        }

        protected void grdVeiwCategories_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdVeiwCategories.EditIndex = e.NewEditIndex;
            BindCategoryGrdView();
        }

        protected void grdVeiwCategories_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdVeiwCategories.EditIndex = -1;
            BindCategoryGrdView();
        }

        protected void grdVeiwCategories_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label lblCatID = (Label)grdVeiwCategories.Rows[e.RowIndex].FindControl("lblCatID");
            TextBox txtEditCatName = (TextBox)grdVeiwCategories.Rows[e.RowIndex].FindControl("txtEditCatName");

            shoppNewDOL objData = new shoppNewDOL()
            {
                Categories = new Category
                {
                    CatID = Convert.ToInt64(lblCatID.Text),
                    CatName = txtEditCatName.Text
                }
            };
            _addCategoryBL.UpDateCategory(objData);
            grdVeiwCategories.EditIndex = -1;
            BindCategoryGrdView();

        }

        protected void grdVeiwCategories_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label lblCatID = (Label)grdVeiwCategories.Rows[e.RowIndex].FindControl("lblCatID");
            shoppNewDOL objDate = new shoppNewDOL()
            {
                Categories = new Category
                {
                    CatID = Convert.ToInt32(lblCatID.Text),
                }
            };
            _addCategoryBL.DeleteCategory(objDate);
            BindCategoryGrdView();

        }
    }
}