using Artemis.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Artemis.Controllers
{
    public class SerenityController : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();

        // GET: Serenity
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult AllEmployees()
        {
            var result = db.Employees.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult InsertEmployee(string Name,string Gender,int Salary)
        {
            Employee ee = new Models.Employee()
            {
                Name=Name,Gender=Gender,Salary=Salary
            };
            try
            {
                db.Employees.Add(ee);
                db.SaveChanges();
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult UpdateEmployee(int id,string name,string gender, int salary)
        {
            string result = "Unsuccessful";
            if (name!= "Lutho" && gender != "Lutho" && salary !=7)
            {
            var res = db.UpdateEmployee(id, name, gender, salary);
                result = "SuccessFul";
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            var results = db.Employees.ToList().Find(p => p.ID == id);
            //insert Salary
            if (name == "Lutho" && gender == "Lutho"&&salary!=7)
            {
                results.Salary = salary;
                db.Entry(results).State = EntityState.Modified;
                db.SaveChanges();
                result = "Successful";
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            //insert Gender
            if (name == "Lutho" && salary == 7)
            {
                results.Gender = gender;
                db.Entry(results).State = EntityState.Modified;
                db.SaveChanges();
                result = "Successful";
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            //insert Name
            if (gender == "Lutho" && salary == 7)
            {
                results.Name = name;
                db.Entry(results).State = EntityState.Modified;
                db.SaveChanges();
                result = "Successful";
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            //insert Salary and Name
            if (gender == "Lutho"&& salary!=7)
            {
                results.Name = name;
                results.Salary = salary;
                db.Entry(results).State = EntityState.Modified;
                db.SaveChanges();
                result = "Successful";
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            //insert Salary and Gender
            if (name == "Lutho" && salary != 7)
            {
                results.Gender = gender;
                results.Salary = salary;
                db.Entry(results).State = EntityState.Modified;
                db.SaveChanges();
                result = "Successful";
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            //insert Gender and Name
            if (name != "Lutho" && gender != "Lutho"&& salary==7)
            {
                results.Name = name;
                results.Gender = gender; 
                db.Entry(results).State = EntityState.Modified;
                db.SaveChanges();
                result = "Successful";
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult DeleteEmployee(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return Json("Success", JsonRequestBehavior.AllowGet);
        }
    }
}