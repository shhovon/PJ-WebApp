using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getAllEmployee()
        {
            using (CRUDEntities dbcon = new CRUDEntities())
            {
                var lstEmp = dbcon.Emp_Info.ToList().OrderBy(ein => ein.EmpName);
                return new JsonResult { Data = new { lstEmployee = lstEmp }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        public ActionResult createEmp(int RegID, string EmpID, string EmpName, string DepartmentName, string SectionName, string Designation, int Salary)
        {
            using (CRUDEntities dbcon = new CRUDEntities())
            {
                Emp_Info emp_Info = new Emp_Info();
                emp_Info.RegID = RegID;
                emp_Info.EmpID = EmpID;
                emp_Info.EmpName = EmpName;
                emp_Info.DepartmentName = DepartmentName;
                emp_Info.SectionName = SectionName;
                emp_Info.Designation = Designation;
                emp_Info.Salary = Salary;

                dbcon.Emp_Info.Add(emp_Info);
                dbcon.SaveChanges();
            }
            return null;
        }

        public ActionResult createEmployee()
        {
          
            return View();
        }
         public ActionResult showEmployee()
        {
          
            return View();
        }


        public ActionResult createEmpp()
        {
            return View();
            // return RedirectToAction("ViewEmp");

        }
        public ActionResult ViewEmp()
        {
            return View();
        }
        public ActionResult editEmp(int RegID, string EmpID, string EmpName, string DepartmentName, string SectionName, string Designation, int Salary)
        {
            using (CRUDEntities dbcon = new CRUDEntities())
            {
                var emp_Info = dbcon.Emp_Info.Where(ein => ein.RegID == RegID).FirstOrDefault();
                emp_Info.EmpID = EmpID;
                emp_Info.EmpName = EmpName;
                emp_Info.DepartmentName = DepartmentName;
                emp_Info.SectionName = SectionName;
                emp_Info.Designation = Designation;
                emp_Info.Salary = Salary;

                dbcon.Emp_Info.Add(emp_Info);
                dbcon.Entry(emp_Info).State = EntityState.Modified;
                dbcon.SaveChanges();
            }
            return null;
        }

        public ActionResult editEmpp()
        {
            ViewBag.Message = "Edit Employee";

            return View();
        }
          public ActionResult editEmployee()
        {
            ViewBag.Message = "Edit Employee";

            return View();
        }


        public ActionResult deleteEmp(int RegID)
        {
            using (CRUDEntities dbcon = new CRUDEntities())
            {
                var emp_Info = dbcon.Emp_Info.Where(ein => ein.RegID == RegID).FirstOrDefault();

                dbcon.Emp_Info.Remove(emp_Info);
                dbcon.SaveChanges();
            }
            return null;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}