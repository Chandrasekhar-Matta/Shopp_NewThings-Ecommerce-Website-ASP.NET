using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DataObjectLayer;

namespace DataAccessLayer
{
    public class addBrandsDAL
    {
        string CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
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
        public DataTable BindBrandGrdView()
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                string storedProcedureString = "sp_Brands";
                using (SqlCommand cmd = new SqlCommand(storedProcedureString, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Select");
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = null;
                        dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        public void InsertNewBrands(shoppNewDOL spNewObj)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                string storedProcedureString = "sp_Brands";
                using (SqlCommand cmd=new SqlCommand(storedProcedureString,con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@BrandName",spNewObj.Brands.BrandName);
                    cmd.Parameters.AddWithValue("@MainCatId", spNewObj.Brands.MainCatId);
                    cmd.Parameters.AddWithValue("@CatId", spNewObj.Brands.CatId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}
