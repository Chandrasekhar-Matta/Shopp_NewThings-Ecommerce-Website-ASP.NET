using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using DataAccessLayer;
using DataObjectLayer;
using static System.Net.Mime.MediaTypeNames;


namespace Shopp_NewThings
{
    public partial class WebForm5 : System.Web.UI.Page
    {
         String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMainCategory();
                txtCashOnDelivery.Enabled = false;
                ddlGender.Enabled = false;
            }
        }
         addProductBL _addProductBL = new addProductBL();
        ddlBaindBrandsDAL _ddlBaindBrandsDAL = new ddlBaindBrandsDAL();
        private void BindMainCategory()
        {
            if (ddlCategory != null)
            {
                ddlBindMainCategoryDAL _ddlBindMainCategoryDAL = new ddlBindMainCategoryDAL();
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
                ddlCategory.DataSource = _addProductBL.BindCatbyMainCat(MainCategoryID);
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
            if (ddlBrands != null)
            {
                ddlBrands.DataSource = _ddlBaindBrandsDAL.BindBrandsByMainCatAndCat(MainCategoryID, CategoryID);
                ddlBrands.DataTextField = "BrandName";
                ddlBrands.DataValueField = "BrandID";
                ddlBrands.DataBind();
                ddlBrands.Items.Insert(0, new ListItem("-Select-", "0"));
            }

        }
        protected void BindSubCatByMainCatNadCat(int MainCategoryID, int CategoryID)
        {
            if (ddlSubCategory != null)
            {

                ddlSubCategory.DataSource = _addProductBL.BindSubCatByMainCatAndcat(MainCategoryID, CategoryID);
                ddlSubCategory.DataTextField = "SubCatName";
                ddlSubCategory.DataValueField = "SubCatID";
                ddlSubCategory.DataBind();
                ddlSubCategory.Items.Insert(0, new ListItem("-Select-", "0"));
            }

        }

        protected void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int MainCategory = Convert.ToInt32(ddlMainCategory.SelectedItem.Value);
            int Category = Convert.ToInt32(ddlCategory.SelectedItem.Value);
            int SubCategory = Convert.ToInt32(ddlSubCategory.SelectedItem.Value);
            bindsizeidcbkl(MainCategory, Category, SubCategory);
            ddlGender.Enabled = true;
            bindGender();
        }
        private void bindGender()
        {
            if (ddlGender != null)
            {
                addGenderBL _addGenderBL = new addGenderBL();
                ddlGender.DataSource = _addGenderBL.BindGendersRptr();
                ddlGender.DataTextField = "GenderName";
                ddlGender.DataValueField = "GenderID";
                ddlGender.DataBind();
                ddlGender.Items.Insert(0, new ListItem("-Select-", "0"));
            }

        }
      
        public void bindsizeidcbkl(int MainCategory, int Category, int SubCategory)
        {
            if (ckblSize != null)
            {
                try
                {
                    ckblSize.DataSource = _addProductBL.GetSizesByCategories(MainCategory, Category, SubCategory);
                    ckblSize.DataTextField = "SizeName"; // Replace with the actual column name in your DataTable
                    ckblSize.DataValueField = "SizeID";  // Replace with the actual column name in your DataTable
                    ckblSize.DataBind();

                }
                catch (Exception ex)
                {
                    // Handle the exception, log it, or display an error message as needed
                    throw new Exception("Error in BindSizesToCheckBoxList", ex);
                }
            }
        }
        protected void rbFreeDelivery_CheckedChanged(object sender, EventArgs e)
        {
            txtCashOnDelivery.Enabled = false;

        }

        protected void rbCashOnDelivery_CheckedChanged(object sender, EventArgs e)
        {
            txtCashOnDelivery.Enabled = true;

        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            InsertProducts();
        }


        public void InsertProducts()
        {
                
           
                    shoppNewDOL _shoppNewDOL = new shoppNewDOL()
                    {
                        Products = new Product
                        {
                            PName = txtPName.Text,
                            PPrice = Convert.ToInt32(txtPrice.Text),
                            PSelPrice = Convert.ToInt32(txtSelPrice.Text),
                            PBrandID = Convert.ToInt32(ddlBrands.SelectedItem.Value),
                            PMainCategoryID = Convert.ToInt32(ddlMainCategory.SelectedItem.Value),
                            PCategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value),
                            PSubCategoryID = Convert.ToInt32(ddlSubCategory.SelectedItem.Value),
                            PGenderID = Convert.ToInt32(ddlGender.SelectedItem.Value),
                            PDescription = txtDesc.Text,
                            PProductDetails = txtPDetails.Text,
                            PMaterialCare = txtMatCare.Text,
                            PDateTime = Convert.ToDateTime(txtDeliveryDataTime.Text),
                            Ret30Days = Convert.ToInt32( txtRetun30Days.Text),
                            FreeDelivery = Convert.ToInt32(rbFreeDelivery.Checked),
                            CashOnDelivery = Convert.ToInt32(rbCashOnDelivery.Checked ==true? txtCashOnDelivery.Text : "0".ToString()),
                            DeliveryIn = Convert.ToInt32(cbDIN.Checked),
                            COD = Convert.ToInt32(cbCOD.Checked),
                           
                           
                        }
                    };
                    Int64 PId = _addProductBL.InsertProducts(_shoppNewDOL);
            ProductSizeQuantities(PId);

            SaveImage(PId, fuImg01, fuImg02, fuImg03, fuImg04, fuImg05);
        }

        protected void ProductSizeQuantities(Int64 PId)
        {
            for (int i=0; i < ckblSize.Items.Count; i++)
            {
                shoppNewDOL shoppNewDOL = new shoppNewDOL()
                {
                    ProductSizeQuantities = new ProductSizeQuantity
                    {
                        PID = PId,
                        SizeID = Convert.ToInt64(ckblSize.Items[i].Value),
                        SizeName = ckblSize.Items[i].Text,
                        Quantity = Convert.ToInt32(txtQuantity.Text),
                    }
                };
                _addProductBL.InsertSizes(shoppNewDOL);

            }
        }
        private void SaveImage(Int64 PID, FileUpload fileUpload01, FileUpload fileUpload02, FileUpload fileUpload03, FileUpload fileUpload04, FileUpload fileUpload05)
        {
            if (fileUpload01.HasFile && fileUpload02.HasFile && fileUpload03.HasFile && fileUpload04.HasFile && fileUpload05.HasFile)
            {
                string SavePath01 = Server.MapPath("~/Images/ProductImages/") + PID;
                string PathName = " Images/ProductImages/ " + PID + "/";
                string folderName = Convert.ToString(PID);

                if (!Directory.Exists(SavePath01))
                {
                    Directory.CreateDirectory(SavePath01);
                }

                string extension01 = Path.GetExtension(fileUpload01.PostedFile.FileName);
                string imageName01 = $"{txtPName.Text.Trim()}01{extension01}";
                fileUpload01.SaveAs(Path.Combine(SavePath01, imageName01));


                string SavePath02 = Server.MapPath("~/Images/ProductImages/") + PID;
                if (!Directory.Exists(SavePath02))
                {
                    Directory.CreateDirectory(SavePath02);
                }

                string extension02 = Path.GetExtension(fileUpload02.PostedFile.FileName);
                string imageName02 = $"{txtPName.Text.Trim()}02{extension02}";
                fileUpload01.SaveAs(Path.Combine(SavePath02, imageName02));


                string SavePath03 = Server.MapPath("~/Images/ProductImages/") + PID;
                if (!Directory.Exists(SavePath03))
                {
                    Directory.CreateDirectory(SavePath03);
                }
                string extension03 = Path.GetExtension(fileUpload03.PostedFile.FileName);
                string imageName03 = $"{txtPName.Text.Trim()}03{extension03}";
                fileUpload03.SaveAs(Path.Combine(SavePath03, imageName03));


                string SavePath04 = Server.MapPath("~/Images/ProductImages/") + PID;

                if (!Directory.Exists(SavePath04))
                {
                    Directory.CreateDirectory(SavePath04);
                }

                string extension04 = Path.GetExtension(fileUpload04.PostedFile.FileName);
                string imageName04 = $"{txtPName.Text.Trim()}04{extension04}";
                fileUpload04.SaveAs(Path.Combine(SavePath04, imageName04));


                string SavePath05 = Server.MapPath("~/Images/ProductImages/") + PID;

                if (!Directory.Exists(SavePath05))
                {
                    Directory.CreateDirectory(SavePath05);
                }

                string extension05 = Path.GetExtension(fileUpload05.PostedFile.FileName);
                string imageName05 = $"{txtPName.Text.Trim()}05{extension05}";

                fileUpload05.SaveAs(Path.Combine(SavePath05, imageName05));

                addProductBL addProductBL = new addProductBL();
                addProductBL.InsertImages(PID, folderName, imageName01, imageName02, imageName03, imageName04, imageName05, PathName, extension01);
            }
        }

       
    }
}
//////using (SqlConnection con = new SqlConnection(CS))
//////{
//////    //SqlCommand cmd = new SqlCommand("procInsertProducts", con);
//////cmd.CommandType = CommandType.StoredProcedure;
//////cmd.Parameters.AddWithValue("@PName", txtPName.Text);
//////cmd.Parameters.AddWithValue("@PPrice", txtPrice.Text);
//////cmd.Parameters.AddWithValue("@PSelPrice", txtSelPrice.Text);
//////cmd.Parameters.AddWithValue("@PBrandID", ddlBrands.SelectedItem.Value);
//////cmd.Parameters.AddWithValue("@PCategoryID", ddlCategory.SelectedItem.Value);
//////cmd.Parameters.AddWithValue("@PSubCatID", ddlSubCategory.SelectedItem.Value);
//////cmd.Parameters.AddWithValue("@PGender", ddlGender.SelectedItem.Value);
//////cmd.Parameters.AddWithValue("@PDescription", txtDesc.Text);
//////cmd.Parameters.AddWithValue("@PProductDetails", txtPDetails.Text);
//////cmd.Parameters.AddWithValue("@PMaterialCare", txtMatCare.Text);
//////if (cbFD.Checked == true)
//////{
//////    cmd.Parameters.AddWithValue("@FreeDelivery", 1.ToString());
//////}
//////else
//////{
//////    cmd.Parameters.AddWithValue("@FreeDelivery", 0.ToString());
//////}
//////if (cbDIN.Checked == true)
//////{
//////    cmd.Parameters.AddWithValue("@DeliveryIn", 1.ToString());
//////}
//////else
//////{
//////    cmd.Parameters.AddWithValue("@DeliveryIn", 0.ToString());
//////}
//////if (cb30Ret.Checked == true)
//////{
//////    cmd.Parameters.AddWithValue("@30DayRet", 1.ToString());
//////}
//////else
//////{
//////    cmd.Parameters.AddWithValue("@30DaySRet", 0.ToString());
//////}
//////if (cbCOD.Checked == true)
//////{
//////    cmd.Parameters.AddWithValue("@COD", 1.ToString());
//////}
//////else
//////{
//////    cmd.Parameters.AddWithValue("@COD", 0.ToString());
//////}
//////con.Open();
//////Int64 +PID = Convert.ToInt64(cmd.ExecuteScalar());

//////Insert Size Quantity
//////for (int i = 0; i < cblSize.Items.Count; i++)
//////{
//////    if (cblSize.Items[i].Selected == true)
//////    {
//////        Int64 SizeID = Convert.ToInt64(cblSize.Items[i].Value);
//////        int Quantity = Convert.ToInt32(txtQuantity.Text);


//////        SqlCommand cmd2 = new SqlCommand("insert into tblProductSizeQuantity values('" + PID + "','" + SizeID + "','" + Quantity + "')", con);
//////        cmd2.ExecuteNonQuery();
//////    }
//////}
//////    if (fuImg02.HasFile)
//////    {
//////        string SavePath = Server.MapPath("~/Images/ProductImages/") + PID;
//////        if (!Directory.Exists(SavePath))
//////        {
//////            Directory.CreateDirectory(SavePath);
//////        }
//////        string Extention = Path.GetExtension(fuImg02.PostedFile.FileName);
//////        fuImg02.SaveAs(SavePath + "\\" + txtPName.Text.ToString().Trim() + "02" + Extention);

//////        SqlCommand cmd4 = new SqlCommand("insert into tblProductImages values('" + PID + "','" + txtPName.Text.ToString().Trim() + "02" + "','" + Extention + "')", con);
//////        cmd4.ExecuteNonQuery();
//////    }
//////    if (fuImg03.HasFile)
//////    {
//////        string SavePath = Server.MapPath("~/Images/ProductImages/") + PID;
//////        if (!Directory.Exists(SavePath))
//////        {
//////            Directory.CreateDirectory(SavePath);
//////        }
//////        string Extention = Path.GetExtension(fuImg03.PostedFile.FileName);
//////        fuImg03.SaveAs(SavePath + "\\" + txtPName.Text.ToString().Trim() + "03" + Extention);

//////        SqlCommand cmd5 = new SqlCommand("insert into tblProductImages values('" + PID + "','" + txtPName.Text.ToString().Trim() + "03" + "','" + Extention + "')", con);
//////        cmd5.ExecuteNonQuery();
//////    }
//////    if (fuImg04.HasFile)
//////    {
//////        string SavePath = Server.MapPath("~/Images/ProductImages/") + PID;
//////        if (!Directory.Exists(SavePath))
//////        {
//////            Directory.CreateDirectory(SavePath);
//////        }
//////        string Extention = Path.GetExtension(fuImg04.PostedFile.FileName);
//////        fuImg04.SaveAs(SavePath + "\\" + txtPName.Text.ToString().Trim() + "04" + Extention);

//////        SqlCommand cmd6 = new SqlCommand("insert into tblProductImages values('" + PID + "','" + txtPName.Text.ToString().Trim() + "04" + "','" + Extention + "')", con);
//////        cmd6.ExecuteNonQuery();
//////    }
//////    if (fuImg05.HasFile)
//////    {
//////        string SavePath = Server.MapPath("~/Images/ProductImages/") + PID;
//////        if (!Directory.Exists(SavePath))
//////        {
//////            Directory.CreateDirectory(SavePath);
//////        }
//////        string Extention = Path.GetExtension(fuImg05.PostedFile.FileName);
//////        fuImg05.SaveAs(SavePath + "\\" + txtPName.Text.ToString().Trim() + "05" + Extention);

//////        SqlCommand cmd7 = new SqlCommand("insert into tblProductImages values('" + PID + "','" + txtPName.Text.ToString().Trim() + "05" + "','" + Extention + "')", con);
//////        cmd7.ExecuteNonQuery();
//////    }
//////}
//////}