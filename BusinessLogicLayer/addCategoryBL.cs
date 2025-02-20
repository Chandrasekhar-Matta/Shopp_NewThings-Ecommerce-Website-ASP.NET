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
    public class addCategoryBL
    {
        addCategoryDAL _addCategoryDAL = new addCategoryDAL();
        public DataTable BindCategoryGrdVw()
        {
            return _addCategoryDAL.BindCategoryGrdView();
        }
        public void InsertCategory(shoppNewDOL objData)
        {
            _addCategoryDAL.InsertNewCategory(objData);
        }
        public void UpDateCategory(shoppNewDOL objData)
        {
            upDateCategoryDAL _upDateCategoryDAL = new upDateCategoryDAL();
            _upDateCategoryDAL.UpDateCategory(objData);
        }
        public void DeleteCategory(shoppNewDOL objData)
        {
            deleteCategoryDAL _deleteSubCategoryDAL= new deleteCategoryDAL();
            _deleteSubCategoryDAL.DeleteCategory(objData);
        }
    }
}
