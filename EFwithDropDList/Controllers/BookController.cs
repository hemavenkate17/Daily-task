using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFwithDropDList.Models;

namespace EFwithDropDList.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            using (MoviesDbEntities bentity = new MoviesDbEntities())
            {
                var dataEF = new SelectList(bentity.tbl_Books.ToList(), "BookId", "Title");
                ViewData["BookEF"] = dataEF;
            }
            return View();
        }

        //public ActionResult Linq()
        //{
        //    SqlConnection con = new SqlConnection("data source =LAPTOP-FUHQ3D30\\SQLEXPRESS; database = BookDb;integrated security =true");
           
        //    SqlCommand cmd = new SqlCommand(str, con);
        //    return View();
        //}
    }
}