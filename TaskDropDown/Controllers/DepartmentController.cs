using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskDropDown.Models;

namespace TaskDropDown.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            Department dep = new Department();
            dep.Departments = PopulateDepartments();
            return View(dep);
        }
        [HttpPost]
        public ActionResult Index(Department dep,string action)
        {
            dep.Departments = PopulateDepartments();
            var selectedItem = dep.Departments.Find(p => p.Value == dep.DepartmentId.ToString());
            if (selectedItem != null && action == "Submit")
            {
                dep.Dt = dep.DisplayEmployees(Convert.ToInt32(selectedItem.Value));
            }
            return View(dep);
        }

        private static List<SelectListItem> PopulateDepartments()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            string constr = "data source = LAPTOP-FUHQ3D30\\SQLEXPRESS; database =AdventureWorks2019; integrated security = true";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "select DepartmentID, Name from HumanResources.Department";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            items.Add(new SelectListItem
                            {
                                Text = sdr["Name"].ToString(),
                                Value = sdr["DepartmentID"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }
            return items;
        }

       
    }
}
