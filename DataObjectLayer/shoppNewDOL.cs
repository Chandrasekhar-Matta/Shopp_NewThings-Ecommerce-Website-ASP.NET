using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectLayer
{
    public class shoppNewDOL
    {
        public MainCategory MainCategories { get; set; }
        public Category Categories { get; set; }
        public Brand Brands { get; set; }
        public SubCategory SubCategories { get; set; }
        public Gender Genders { get; set; }
        public Size Sizes { get; set; }
        public Product Products { get; set; }
        public ProductSizeQuantity ProductSizeQuantities { get; set; }

    }
    public class MainCategory
    {
        public Int64 MainCatID { get; set; }
        public string MainCatName { get; set; }
    }
    public class Category
    {
        public Int64 CatID { get; set; }
        public string CatName { get; set; }
        public Int64 MainCatID { get; set; }
    }
    public class Brand
    {
        public Int64 BrandID { get; set; }
        public string BrandName { get; set; }
        public Int64 MainCatId { get; set; }
        public Int64 CatId { get; set; }
    }
   
    public class SubCategory
    {
        public Int64 SubCatID { get; set; }
        public string SubCatName { get; set; }
        public Int64 MainCatID { get; set; }
        public Int64 CatID { get; set; }
    }
    public class Gender
    {
        public int GenderID { get; set; }
        public string GenderName { get; set; }
    }
    public class Size
    {
        public Int64 SizeID { get; set; }
        public string SizeName { get; set; }
        public Int64 MainCategoryID { get; set; }
        public Int64 CategoryID { get; set; }
        public Int64 BrandID { get; set; }
        public Int64 SubCategoryID { get; set; }
        public Int64 GenderID { get; set; }
    }
    public class Product
    {
        public Int64 PID { get; set; }
        public string PName { get; set; }
        public int PPrice { get; set; }
        public int PSelPrice { get; set; }
        public int PBrandID { get; set; }
        public int PMainCategoryID { get; set; }
        public int PCategoryID { get; set; }
        public int PSubCategoryID { get; set; }
        public int PGenderID { get; set; }
        public string PDescription { get; set; }
        public string PProductDetails { get; set; }
        public string PMaterialCare { get; set; }
        public DateTime PDateTime { get; set; }
        public int Ret30Days { get; set; }
        public int FreeDelivery { get; set; }
        public int CashOnDelivery { get; set; }
        public int DeliveryIn { get; set; }
        public int COD { get; set; }
        public ProductImage ProductImages { get; set; }

    }
    public class ProductSizeQuantity
    {
        public Int64 PID { get; set;}
        public Int64 SizeID { get; set;}
        public string SizeName { get; set;}
        public int Quantity { get; set;}
        

    } 
    public class ProductImage
    {
        public Int64 PID { get; set;}
        public string FolderName { get; set; }
        public string PImg01Name { get; set;}
        public string PImg02Name { get; set;}
        public string PImg03Name { get; set;}
        public string PImg04Name { get; set;}
        public string PImg05Name { get; set;}
        public string PathName { get; set;}
        public string Extention { get; set;}
       
    }
}
