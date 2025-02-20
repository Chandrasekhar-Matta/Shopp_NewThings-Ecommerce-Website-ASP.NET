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
    public class upDateSubCategoryDAL
    {
        string CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
        public void UpDateSubCategory(shoppNewDOL spNewObj)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                string storedProcedureString = "sp_SubCategories";
                using (SqlCommand cmd = new SqlCommand(storedProcedureString, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "UpDate");
                    cmd.Parameters.AddWithValue("@SubCatID", spNewObj.SubCategories.SubCatID);
                    cmd.Parameters.AddWithValue("@SubCatName", spNewObj.SubCategories.SubCatName);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}
