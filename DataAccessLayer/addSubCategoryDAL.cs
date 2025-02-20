using DataObjectLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class addSubCategoryDAL
    {
        string CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
        public DataTable BindSubCategoryGrdView()
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("sp_SubCategories", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "BindSubCatAndCatAndMainCat");
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dtBrands = new DataTable();
                        sda.Fill(dtBrands);
                        return dtBrands;
                    }

                }
            }
        }
        public DataTable BindCatByMainCat(int MainCategoryID)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                string storedProcedureString = "sp_Categories";
                using (SqlCommand cmd = new SqlCommand(storedProcedureString, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "BindCatbyMainCat");
                    cmd.Parameters.AddWithValue("@MainCatID", MainCategoryID);
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

       
        public void InsertNewSubCategory(shoppNewDOL spNewObj)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                string storedProcedureString = "sp_SubCategories ";
                using (SqlCommand cmd = new SqlCommand(storedProcedureString, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action","Insert");
                    cmd.Parameters.AddWithValue("@SubCatName", spNewObj.SubCategories.SubCatName);
                    cmd.Parameters.AddWithValue("@MainCatID", spNewObj.SubCategories.MainCatID);
                    cmd.Parameters.AddWithValue("@CatID", spNewObj.SubCategories.CatID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}
