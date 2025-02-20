using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using DataObjectLayer;

namespace DataAccessLayer
{
    public class upDateBrandsDAL
    {
        string CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
        public void UpDateBrand(shoppNewDOL spNewObj)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                string storedProcedureString = "sp_Brands";
                using (SqlCommand cmd = new SqlCommand(storedProcedureString, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action","UpDate");
                    cmd.Parameters.AddWithValue("@BrandID", spNewObj.Brands.BrandID);
                    cmd.Parameters.AddWithValue("@BrandName", spNewObj.Brands.BrandName);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}
