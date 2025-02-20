using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DataObjectLayer;

namespace DataAccessLayer
{
    public class upDateMainCategoryDAL
    {
        string CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
        public void UpDateMainCategory(shoppNewDOL spNewObj)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                string storedProcedureString = "sp_MainCategories";
                using (SqlCommand cmd = new SqlCommand(storedProcedureString, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Update");
                   cmd.Parameters.AddWithValue("@MainCatID", spNewObj.MainCategories.MainCatID);
                    cmd.Parameters.AddWithValue("@MainCatName", spNewObj.MainCategories.MainCatName);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}
