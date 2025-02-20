using DataObjectLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class addSizeBL
    {
        addSizeDAL _addSizeDAL = new addSizeDAL();

        public DataTable BindCatbyMainCat(int MainCategoryID)
        {
            return _addSizeDAL.BindCatByMainCat(MainCategoryID);
        }
        public DataTable BindSubCatByMainCatAndcat(int MainCategoryID, int CategoryID)
        {
            return _addSizeDAL.BindSubCatByMainCatAndCat( MainCategoryID, CategoryID);
        }

        public void InsertSize(shoppNewDOL objData)
        {
            _addSizeDAL.InsertSize(objData);
        }
        public DataTable BindBrandSize()
        {
            return _addSizeDAL.BindBrandsSize();
        }
    }
}

    
