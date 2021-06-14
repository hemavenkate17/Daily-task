using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CRUDController : Controller
    {
        // GET: CRUD
        public ActionResult Index()
        {
            CRUDModel mdl = new CRUDModel();
            DataTable dt = mdl.DisplayBook();
            return View("Home", dt);
        }
        public ActionResult Insert()
        {
            return View("Create");
        }
        public ActionResult InsertRecord(FormCollection frm, string action)
        {
            if (action == "Submit")
            {
                CRUDModel mdl = new CRUDModel();
                string Title = frm["txtTitle"];
                int aid = Convert.ToInt32(frm["txtAid"]);
                double price = Convert.ToDouble(frm["txtPrice"]);
                int rowIns = mdl.NewBook(Title, aid, price);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        public ActionResult AuthorIndex()
        {
            CRUDModel mdl = new CRUDModel();
            DataTable dt = mdl.DisplayAuthor();
            return View("HomeAuthor", dt);
        }
        public ActionResult CreateAuthor()
        {
            return View();
        }
        public ActionResult InsertAuthor(FormCollection frm, string action)
        {
            if (action == "Submit")
            {
                CRUDModel mdl = new CRUDModel();
                string AuthorName = frm["txtAuthorName"];
                int rowIns = mdl.NewAuthor(AuthorName);
                return RedirectToAction("AuthorIndex");
            }
            else
            {
                return RedirectToAction("AuthorIndex");
            }

        }
    }
}
