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
    public class deleteMainCategoryDAL
    {
        string CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
        public void DeleteMainCategory(shoppNewDOL spNewObj)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                
                using (SqlCommand cmd = new SqlCommand("sp_MainCategories", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action","Delete");
                    cmd.Parameters.AddWithValue("@MainCatID", spNewObj.MainCategories.MainCatID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}
