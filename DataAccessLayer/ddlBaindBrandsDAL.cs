using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataAccessLayer
{
    public class ddlBaindBrandsDAL
    {

        public DataTable BindBrandsByMainCatAndCat(int MainCategoryID, int CategoryID)
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string storedProcedureString = "sp_Brands";
                using (SqlCommand cmd = new SqlCommand(storedProcedureString, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "BindBrandsbyMainCatAndCat");
                    cmd.Parameters.AddWithValue("@MainCatId", MainCategoryID);
                    cmd.Parameters.AddWithValue("@CatId", CategoryID);
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
    }
}
