using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.Adapters;


namespace BusinessLogicLayer
{
    public class ProductsBL
    {
        public DataTable BindProductRepeater(Int64 Sub1CatID, Int64 Sub2CatID )
        {
            ProductsDAL productsDAL = new ProductsDAL();
            return productsDAL.BaindProducts(Sub1CatID, Sub2CatID);
        }
    }
}
