using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFwithDropDList.Models;

namespace EFwithDropDList.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            using(MoviesEntities mentity = new MoviesEntities())
            {
                var dataEF = new SelectList(mentity.Movies.ToList(), "No", "Movies");
                ViewData["MovEF"] = dataEF;
            }
            return View();
        }
       

    }
}