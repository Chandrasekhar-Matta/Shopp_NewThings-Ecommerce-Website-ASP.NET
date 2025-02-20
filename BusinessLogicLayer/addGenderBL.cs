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
    public class addGenderBL
    {
        addGenderDAL _addGenderDAL = new addGenderDAL();
        public DataTable BindGendersRptr()
        {
            return _addGenderDAL.BindGenderRptr();
        }
        public void InsertGenders(shoppNewDOL objdata)
        {
            _addGenderDAL.InsertGender(objdata);
        }
    }
}
