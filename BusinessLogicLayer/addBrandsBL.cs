using DataObjectLayer;
using DataAccessLayer;
using System.Data;

namespace BusinessLogicLayer
{
    public class addBrandsBL
    {
        addBrandsDAL addBrandDAL = new addBrandsDAL();
        upDateBrandsDAL upDateBrands = new upDateBrandsDAL();
        deleteBrandsDAL deleteBrandsDAL = new deleteBrandsDAL();
        ddlBindMainCategoryDAL ddlBindMainCategoryDAL = new ddlBindMainCategoryDAL();
        public DataTable BindCatByMainCat(int MainCategoryID)
        {
            return addBrandDAL.BindCatByMainCat(MainCategoryID);
        }
        public DataTable BindBrandGrdV()
        {
            return addBrandDAL.BindBrandGrdView();
        }
        public DataTable BindMainCategortes()
        {
            return ddlBindMainCategoryDAL.DdlBindMainCategory();
        }
        public void ADDBrands(shoppNewDOL objData)
        {
            addBrandDAL.InsertNewBrands(objData);
        }
        public void UPDateBrands(shoppNewDOL objData)
        {
            upDateBrands.UpDateBrand(objData);
        }
        public void DeleteBrands(shoppNewDOL objData)
        {
            deleteBrandsDAL.DeleteBrand(objData);
        }
    }
}
