using DataObjectLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccessLayer
{
    public class ProductViewDAL
    {
        String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;

        public DataTable BindProductDetails(Int64 PID)
        {

            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("Select * From tblProducts Where PID = " + PID + "", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        public DataTable BindProductImages(Int64 PID)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("Select * From tblProductImages Where PID = " + PID + "", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda1 = new SqlDataAdapter(cmd))
                    {

                        DataTable dt1 = new DataTable();
                        sda1.Fill(dt1);
                      return dt1;   
                    }
                }
            }
        }

        public DataTable  rptrProductSizeDetails(Int64 PID)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                //using (SqlCommand cmd = new SqlCommand("select * from tblSizes where BrandID=" + BrandID +
                //    " and CategoryID=" + CatID + " and SubCategoryID=" + SubCatID +
                //    " and GenderID=" + GenderID + "", con))
                using (SqlCommand cmd = new SqlCommand("select * from tblProductSizeQuantity where PID=" + PID + "", con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;

                }
            }
        }
       
    }
}
