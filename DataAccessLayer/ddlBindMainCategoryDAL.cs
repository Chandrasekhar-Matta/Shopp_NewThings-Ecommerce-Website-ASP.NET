using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;



namespace DataAccessLayer
{
    public class ddlBindMainCategoryDAL
    {
        public DataTable DdlBindMainCategory()
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string storedProcedureString = "sp_MainCategories";
                using (SqlCommand cmd = new SqlCommand(storedProcedureString, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Select");
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
