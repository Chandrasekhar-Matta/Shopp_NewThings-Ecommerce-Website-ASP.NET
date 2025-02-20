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
    public class addMainCategoryBL
    {
        addMainCategoryDAL _addMainCategoryDAL = new addMainCategoryDAL();
        upDateMainCategoryDAL _upDateMainCategoryDAL = new upDateMainCategoryDAL();
        deleteMainCategoryDAL _deleteMainCategoryDAL = new deleteMainCategoryDAL();
        public DataTable BindMainCategoryGrdViw()
        {
            return _addMainCategoryDAL.BindMainCategoryGrdView();
        }
        public void InsertMainCategory(shoppNewDOL objData)
        {
            _addMainCategoryDAL.InsertMainCategory(objData);
        }
        public void UpDateMainCategory(shoppNewDOL objData)
        {
            _upDateMainCategoryDAL.UpDateMainCategory(objData);
        }
        public void DeleteMainCategory(shoppNewDOL objData)
        {
            _deleteMainCategoryDAL.DeleteMainCategory(objData);
        }
    }
}
