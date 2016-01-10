using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFormCollection.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/
        public ActionResult Index()
        {
            DataAccessLib db = new DataAccessLib();
            return View(db.GetEmployees);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult formCollection(FormCollection formCollection)
        {
            Employee emp = new Employee();
            DataAccessLib db = new DataAccessLib();
            emp.Name = formCollection["Name"];
            emp.Designation = formCollection["Designation"];
            emp.Gender = formCollection["Gender"];
            emp.Salary = Convert.ToDouble(formCollection["Salary"]);
            emp.City = formCollection["City"];
            emp.State = formCollection["State"];
            emp.Zip = formCollection["Zip"];

            db.AddEmployees(emp);

            return RedirectToAction("Index");
        }

        //[HttpPost]
        //[ActionName("Create2")]
        //public ActionResult employeeObject(Employee emp)
        //{
        //    DataAccessLib db = new DataAccessLib();
        //    db.AddEmployees(emp);
        //    return RedirectToAction("Index");
        //}

        //[HttpPost]
        //[ActionName("Create3")]
        //public ActionResult usingParameter(string name, string designation, string gender, double salary, string city, string state, string zip)
        //{
        //    Employee emp = new Employee();
        //    DataAccessLib db = new DataAccessLib();
        //    emp.Name = name;
        //    emp.Designation = designation;
        //    emp.Gender = gender;
        //    emp.Salary = salary;
        //    emp.City = city;
        //    emp.State = state;
        //    emp.Zip = zip;
        //    db.AddEmployees(emp);

        //    return RedirectToAction("Index");
        //}
	}
}