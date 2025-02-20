using DataObjectLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BusinessLogicLayer
{
    public class addProductBL
    {
        addProductDAL _addProductDAL = new addProductDAL();
       
        public DataTable BindCatbyMainCat(int MainCategoryID)
        {
            return _addProductDAL.BindCatByMainCat(MainCategoryID);
        }
        public DataTable BindSubCatByMainCatAndcat(int MainCategoryID, int CategoryID)
        {
            return _addProductDAL.BindSubCatByMainCatAndCat(MainCategoryID, CategoryID);
        }

        // Business Logic Layer
        public DataTable GetSizesByCategories( int MainCategory, int Category, int SubCategory)
        {
            return _addProductDAL.GetSizesByCategories( MainCategory, Category, SubCategory);
        }
        public Int64 InsertProducts(shoppNewDOL ObjData)
        {
            return _addProductDAL.InsertProduct(ObjData);
        }
        public void InsertSizes(shoppNewDOL _shoppNewDOL)
        {
            _addProductDAL.InsertProductSizeQuantities(_shoppNewDOL);
        }
        public void InsertImages(Int64 PId, string folderName, string imageName01, string imageName02, string imageName03, string imageName04, string imageName05, string SavePath01, string extention)
        {
            _addProductDAL.InsertImages(PId, folderName, imageName01, imageName02, imageName03, imageName04, imageName05, SavePath01, extention);
        }
    }
}
