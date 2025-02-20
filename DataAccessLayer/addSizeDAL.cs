using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer;

namespace DataAccessLayer
{
    public class addSizeDAL
    {
        String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;


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
        public void InsertSize(shoppNewDOL objData)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Sizes", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@SizeName", objData.Sizes.SizeName);
                    cmd.Parameters.AddWithValue("@BrandID", objData.Sizes.BrandID);
                    cmd.Parameters.AddWithValue("@MainCategoryID", objData.Sizes.MainCategoryID);
                    cmd.Parameters.AddWithValue("@CategoryID", objData.Sizes.CategoryID);
                    cmd.Parameters.AddWithValue("@SubCategoryID", objData.Sizes.SubCategoryID);
                    cmd.Parameters.AddWithValue("@GenderID", objData.Sizes.GenderID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        public DataTable BindBrandsSize()
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Sizes", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "BindSizesAndMainCatAndCatAndBrandsAndSubCatAndGender");
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dtBrands = new DataTable();
                        sda.Fill(dtBrands);
                        return dtBrands;
                    }
                }
            }
        }
    }
}
