using DataAccessLayer;
using DataObjectLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class addSubCategoryBL
    {
        addSubCategoryDAL _addSubCategoryDAL = new addSubCategoryDAL();
        public DataTable BindSubCategoryGrdVw()
        {
            return _addSubCategoryDAL.BindSubCategoryGrdView();
        }
        public DataTable BindCatandMainCategory(int MainCategoryID)
        {
            return _addSubCategoryDAL.BindCatByMainCat(MainCategoryID);
        }
        public void InsertSubCategory(shoppNewDOL objData)
        {
            _addSubCategoryDAL.InsertNewSubCategory(objData);
        }

        public void UpDateSubCategory(shoppNewDOL objData)
        {
            upDateSubCategoryDAL _upDateSubCategoryDAL = new upDateSubCategoryDAL();
            _upDateSubCategoryDAL.UpDateSubCategory(objData);
        }
        public void DeleteSubCategory(shoppNewDOL objData)
        {
            deleteSubCategoryDAL _deleteSubCategoryDAL = new deleteSubCategoryDAL();
            _deleteSubCategoryDAL.DeleteSubCategory(objData);
        }
    }
}

