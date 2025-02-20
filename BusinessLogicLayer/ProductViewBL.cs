using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer;
using System.Net;

namespace BusinessLogicLayer
{
    public class ProductViewBL
    {
        ProductViewDAL productViewDAL = new ProductViewDAL();        
        public DataTable BindProductDetails(Int64 PID)
        {
            return productViewDAL.BindProductDetails(PID);
        }
        public DataTable BindProductImages(Int64 PID)
        {
            return productViewDAL.BindProductImages(PID);
        }
        public DataTable rptrProductSizesDetails(Int64 PID)
        {
            return productViewDAL.rptrProductSizeDetails(PID);
        }
       
    }
}
