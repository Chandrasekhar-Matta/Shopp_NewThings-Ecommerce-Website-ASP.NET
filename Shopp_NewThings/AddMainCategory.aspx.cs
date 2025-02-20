using BusinessLogicLayer;
using DataObjectLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shopp_NewThings
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMainCategoryGrdView();

            }
        }
        addMainCategoryBL _addMainCategoryBL = new addMainCategoryBL();
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            shoppNewDOL objDateDOL = new shoppNewDOL()
            {
                MainCategories = new MainCategory
                {
                    MainCatName = txtMainCatName.Text,
                }
            };
            _addMainCategoryBL.InsertMainCategory(objDateDOL);
            BindMainCategoryGrdView();
        }
        private void BindMainCategoryGrdView()
        {
            grdVeiwMainCategories.DataSource = _addMainCategoryBL.BindMainCategoryGrdViw();
            grdVeiwMainCategories.DataBind();
        }
        protected void grdVeiwMainCategories_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdVeiwMainCategories.EditIndex = e.NewEditIndex;
            BindMainCategoryGrdView();
        }

        protected void grdVeiwMainCategories_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdVeiwMainCategories.EditIndex = -1;
            BindMainCategoryGrdView();
        }

        protected void grdVeiwMainCategories_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label lblMainCatID = (Label)grdVeiwMainCategories.Rows[e.RowIndex].FindControl("lblMainCatID");
            TextBox txtEditMainCatName = (TextBox)grdVeiwMainCategories.Rows[e.RowIndex].FindControl("txtEditMainCatName");
            shoppNewDOL objDateUpdDOL = new shoppNewDOL()
            {
                MainCategories = new MainCategory
                {
                    MainCatID = Convert.ToInt64(lblMainCatID.Text),
                    MainCatName = txtEditMainCatName.Text
                }
            };
            _addMainCategoryBL.UpDateMainCategory(objDateUpdDOL);
            grdVeiwMainCategories.EditIndex = -1;
            BindMainCategoryGrdView();
        }

        protected void grdVeiwMainCategories_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label lblMainCatID = (Label)grdVeiwMainCategories.Rows[e.RowIndex].FindControl("lblMainCatID");
            shoppNewDOL objDateDelDOL = new shoppNewDOL()
            {
                MainCategories = new MainCategory
                {
                    MainCatID = Convert.ToInt64(lblMainCatID.Text),
                }
            };
            _addMainCategoryBL.DeleteMainCategory(objDateDelDOL);
        }
    }
}