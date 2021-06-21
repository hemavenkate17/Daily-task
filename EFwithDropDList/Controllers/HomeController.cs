using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFwithDropDList.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.MyTime = DateTime.Now.ToString();
            return View("GoHome", "Home");
        }
        public ActionResult GoHome()
        {
            ViewBag.MyTime = DateTime.Now.ToString();
            ViewData["MyTime1"] = DateTime.Now.ToString();
            TempData["TempTime"] = DateTime.Now.ToString();

            return View("Home");
        }
    }
}