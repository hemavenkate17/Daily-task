using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDLtoDDL.Models
{
    public class CascadeProducts
    {
        public CascadeProducts()
        {
            this.Categories = new List<SelectListItem>();
            this.SubCategories = new List<SelectListItem>();
            this.Products = new List<SelectListItem>();

        }

        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> SubCategories { get; set; }
        public List<SelectListItem> Products{ get; set; }

        public int ProductCategoryID { get; set; }
        public int ProductSubCategoryID { get; set; }
        public int ProductID { get; set; }



    }

}