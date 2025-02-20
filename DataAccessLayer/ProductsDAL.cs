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
    public class ProductsDAL
    {
        String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
      

        public DataTable BaindProducts(Int64 PCatID, Int64 PSubCatID)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("BindAllProducts", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (PCatID > 0)
                    {
                        cmd.Parameters.AddWithValue("@PCategoryID", PCatID);
                    }
                    if (PSubCatID > 0)
                    {
                        cmd.Parameters.AddWithValue("@PSubCatID", PSubCatID);
                    }
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dtBrands = null;
                      
                            dtBrands = new DataTable();
                            sda.Fill(dtBrands);
                            
                        return dtBrands;
                    }
                }

            }
        }
    }
}
