using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace Shopp_NewThings
{
    public partial class WebForm13 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USERNAME"] != null)
            {
                lblSuccess.Text = "Login Success, Welcome " + Session["USERNAME"].ToString() + "";
            }
            BindUserDetail();
        }

        public void BindUserDetail()
        {
            UserHomeDAL userHomeDAL = new UserHomeDAL();
            fviewUserDetails.DataSource = userHomeDAL.BindUserDetails();
            fviewUserDetails.DataBind();
        }


       
        protected void fviewUserDetails_ModeChanging(object sender, FormViewModeEventArgs e)
        {
            
                fviewUserDetails.ChangeMode(e.NewMode);
                BindUserDetail();
           
           
        }



        //protected void btnEdit_Click(object sender, EventArgs e)
        //{

        //        fviewUserDetails.ChangeMode(FormViewMode.Edit);
        //    BindUserDetail();
        //}

        //protected void btnCancel_Click(object sender, EventArgs e)
        //{
        //    fviewUserDetails.ChangeMode(FormViewMode.ReadOnly);
        //    BindUserDetail();
        //}
    }
}