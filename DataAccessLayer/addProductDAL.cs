using DataObjectLayer;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace DataAccessLayer
{
    public class addProductDAL
    {
        public static String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
        public DataTable BindCatByMainCat(int MainCategoryID)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                string storedProcedureString = "sp_Categories";
                using (SqlCommand cmd = new SqlCommand(storedProcedureString, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "BindCatbyMainCat");
                    cmd.Parameters.AddWithValue("@MainCatId", MainCategoryID);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    DataTable dt = null;
                    if (rdr.HasRows)
                    {
                        dt = new DataTable();
                        dt.Load(rdr);
                        return dt;
                    }
                }
            }
            return null;
        }
        public DataTable BindSubCatByMainCatAndCat(int MainCategoryID, int CategoryID)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                string storedProcedureString = "sp_SubCategories";
                using (SqlCommand cmd = new SqlCommand(storedProcedureString, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "BindSubCatbyMainCat");
                    cmd.Parameters.AddWithValue("@MainCatID", MainCategoryID);
                    cmd.Parameters.AddWithValue("@CatID", CategoryID);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    DataTable dt = null;
                    if (rdr.HasRows)
                    {
                        dt = new DataTable();
                        dt.Load(rdr);
                        return dt;
                    }
                }
            }
            return null;
        }
        public DataTable GetSizesByCategories(int MainCategory, int Category, int SubCategory)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Sizes", con))
                {
                    try
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "BindSizesByMainCatAndCatAndSubCat");
                        cmd.Parameters.AddWithValue("@MainCategoryID", MainCategory);
                        cmd.Parameters.AddWithValue("@CategoryID", Category);
                        cmd.Parameters.AddWithValue("@SubCategoryID", SubCategory);
                        con.Open();
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception, log it, or throw it as needed
                        throw new Exception("Error in GetSizesByCategories", ex);
                    }
                }
            }
        }
        public Int64 InsertProduct(shoppNewDOL objData)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("sp_Products", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Insert");
                cmd.Parameters.AddWithValue("@PName", objData.Products.PName);
                cmd.Parameters.AddWithValue("@PPrice", objData.Products.PPrice);
                cmd.Parameters.AddWithValue("@PSelPrice", objData.Products.PSelPrice);
                cmd.Parameters.AddWithValue("@PBrandID", objData.Products.PBrandID);
                cmd.Parameters.AddWithValue("@PMainCategoryID", objData.Products.PMainCategoryID);
                cmd.Parameters.AddWithValue("@PCategoryID", objData.Products.PCategoryID);
                cmd.Parameters.AddWithValue("@PSubCatID", objData.Products.PSubCategoryID);
                cmd.Parameters.AddWithValue("@PGenderID", objData.Products.PGenderID);
                cmd.Parameters.AddWithValue("@PDescription", objData.Products.PDescription);
                cmd.Parameters.AddWithValue("@PProductDetails", objData.Products.PProductDetails);
                cmd.Parameters.AddWithValue("@PMaterialCare", objData.Products.PMaterialCare);
                cmd.Parameters.AddWithValue("@PDateTime", objData.Products.PDateTime);
                cmd.Parameters.AddWithValue("@Ret30Days", objData.Products.Ret30Days);
               
                if (objData.Products.FreeDelivery == 1)
                {
                    cmd.Parameters.AddWithValue("@FreeDelivery", 1.ToString());
                    cmd.Parameters.AddWithValue("@CashOnDelivery", 0.ToString());

                }
                else 
                {
                    cmd.Parameters.AddWithValue("@FreeDelivery", 0.ToString());
                    cmd.Parameters.AddWithValue("@CashOnDelivery", objData.Products.CashOnDelivery);

                }
                if (objData.Products.DeliveryIn == 1)
                {
                    cmd.Parameters.AddWithValue("@DeliveryIn", 1.ToString());
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DeliveryIn", 0.ToString());
                }
                if (objData.Products.COD == 1)
                {
                    cmd.Parameters.AddWithValue("@COD", 1.ToString());
                }
                else
                {
                    cmd.Parameters.AddWithValue("@COD", 0.ToString());
                }
                con.Open();
                 Int64 PID = Convert.ToInt64(cmd.ExecuteScalar());
                return PID;
            }
        }
        public void InsertProductSizeQuantities(shoppNewDOL _shoppNewDOL)
        {
            //Insert Size Quantity
            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd2 = new SqlCommand("sp_InsertProductSizeQuantity", con);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@PID", _shoppNewDOL.ProductSizeQuantities.PID);
            cmd2.Parameters.AddWithValue("@SizeID", _shoppNewDOL.ProductSizeQuantities.SizeID);
            cmd2.Parameters.AddWithValue("@SizeName", _shoppNewDOL.ProductSizeQuantities.SizeName);
            cmd2.Parameters.AddWithValue("@Quantity", _shoppNewDOL.ProductSizeQuantities.Quantity);
            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();
        }
        public void InsertImages(Int64 PId, string folderName, string imageName01, string imageName02, string imageName03, string imageName04, string imageName05, string SavePath01, string extention)
        {

            //Insert and upload Images
            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd3 = new SqlCommand("sp_InsertProductImages", con);
            cmd3.CommandType = CommandType.StoredProcedure;
            cmd3.Parameters.AddWithValue("@PID", PId);
            cmd3.Parameters.AddWithValue("@FolderName", folderName);
            cmd3.Parameters.AddWithValue("@PImg01Name", imageName01);
            cmd3.Parameters.AddWithValue("@PImg02Name", imageName02);
            cmd3.Parameters.AddWithValue("@PImg03Name", imageName03);
            cmd3.Parameters.AddWithValue("@PImg04Name", imageName04);
            cmd3.Parameters.AddWithValue("@PImg05Name", imageName05);
            cmd3.Parameters.AddWithValue("@PathName", SavePath01);
            cmd3.Parameters.AddWithValue("@Extention", extention);
            con.Open();
            cmd3.ExecuteNonQuery();
            con.Close();
        }
    }
}
