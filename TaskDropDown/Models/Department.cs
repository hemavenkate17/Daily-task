using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace TaskDropDown.Models
{
    public class Department
    {
        //public DataTable GetDepartment()
        //{
        //    DataTable dt = new DataTable();
        //    SqlConnection con = new SqlConnection("data source =LAPTOP-FUHQ3D30\\SQLEXPRESS; database = AdventureWorks2019;integrated security =true");
        //    SqlCommand cmd = new SqlCommand("select departmenentid, name from humanResources.department", con);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    da.Fill(dt);
        //    return dt;
        //}
        public List<SelectListItem> Departments { get; set; }
        public int? DepartmentId { get; set; }
        public int? DepartmentName { get; set; }
        public DataTable Dt { get; set; }
        public DataTable DisplayEmployees(int dID)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection("data source =LAPTOP-FUHQ3D30\\SQLEXPRESS; database =AdventureWorks2019;integrated security =true");
            SqlCommand cmd = new SqlCommand("select e.BusinessEntityID,p.FirstName,e.BirthDate,e.MaritalStatus,e.Gender,e.HireDate " +
                            "from HumanResources.EmployeeDepartmentHistory dh join HumanResources.Department d on d.DepartmentID = dh.DepartmentID " +
                            "join HumanResources.Employee e on e.BusinessEntityID = dh.BusinessEntityID " +
                            "join Person.Person p on p.BusinessEntityID = e.BusinessEntityID where d.DepartmentID =" + dID,con);
                           
            
           
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

    }
}