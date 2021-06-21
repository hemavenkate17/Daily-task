using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DDLtoDDL.Models;

namespace DDLtoDDL.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            AdventureWorks2019Entities entities = new AdventureWorks2019Entities();
            CascadeProducts model = new CascadeProducts();
            foreach (var category in entities.ProductCategories)
            {
                model.Categories.Add(new SelectListItem { Text = category.Name, Value = category.ProductCategoryID.ToString() });
            }
            return View(model);
        }
        [HttpPost]

        public ActionResult Index(int? catId, int? subcatId)
        {
            AdventureWorks2019Entities entities = new AdventureWorks2019Entities();
            CascadeProducts model = new CascadeProducts();
            foreach (var category in entities.ProductCategories)
            {
                model.Categories.Add(new SelectListItem { Text = category.Name, Value = category.ProductCategoryID.ToString() });
            }
            if (catId.HasValue)
            {
                var subcat = (from scat in entities.ProductSubcategories
                              where scat.ProductCategoryID == catId.Value
                              select scat).ToList();
                foreach (var sc in subcat)
                {
                    model.SubCategories.Add(new SelectListItem { Text = sc.Name, Value = sc.ProductSubcategoryID.ToString() });
                    if (subcatId.HasValue)
                    {
                        var pducts = (from prod in entities.Products where prod.ProductSubcategoryID == subcatId.Value select prod).ToList();
                    }
                }
            }
            return View();
        }
    }
}