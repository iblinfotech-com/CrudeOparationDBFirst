using Crud_With_DbFirst_StoreProcedure.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud_With_DbFirst_StoreProcedure.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            FirstAprochEntities2 db = new FirstAprochEntities2();
            var data = db.GetAllEmployee().ToList();
            return View(data);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            FirstAprochEntities2 db = new FirstAprochEntities2();
            var data = db.GetAllEmployee().Where(a => a.EmployeeId == id).FirstOrDefault();
            return View(data);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee collection)
        {
            try
            {
                FirstAprochEntities2 db = new FirstAprochEntities2();
                SqlParameter EmpName = new SqlParameter("@EmpName", collection.EmpName);
                SqlParameter BirthofDate = new SqlParameter("@BirthofDate", collection.BirthofDate);
                SqlParameter Gender = new SqlParameter("@Gender", collection.Gender);
                SqlParameter Email = new SqlParameter("@Email", collection.Email);
                SqlParameter Phone = new SqlParameter("@Phone", collection.Phone);
                SqlParameter Address = new SqlParameter("@Address", collection.Address);
                SqlParameter City = new SqlParameter("@City", collection.City);
                SqlParameter Department = new SqlParameter("@Department", collection.Department);
                SqlParameter JoiningDate = new SqlParameter("@joiningDate", collection.JoiningDate);
                var data = db.Database.ExecuteSqlCommand("exec InsertEmployee @EmpName ,@BirthofDate,@Gender,@Email,@Phone,@Address,@City,@Department,@joiningDate",EmpName,BirthofDate,Gender,Email, Phone,Address,City,Department,JoiningDate);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
          
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            FirstAprochEntities2 db = new FirstAprochEntities2();
            var data = db.GetAllEmployee().Where(a => a.EmployeeId == id).FirstOrDefault();
            return View(data);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee collection)
        {
            try
            {
                FirstAprochEntities2 db = new FirstAprochEntities2();
                SqlParameter empid = new SqlParameter("@EmployeeId", id);
                SqlParameter EmpName = new SqlParameter("@EmpName", collection.EmpName);
                SqlParameter BirthofDate = new SqlParameter("@BirthofDate", collection.BirthofDate);
                SqlParameter Gender = new SqlParameter("@Gender", collection.Gender);
                SqlParameter Email = new SqlParameter("@Email", collection.Email);
                SqlParameter Phone = new SqlParameter("@Phone", collection.Phone);
                SqlParameter Address = new SqlParameter("@Address", collection.Address);
                SqlParameter City = new SqlParameter("@City", collection.City);
                SqlParameter Department = new SqlParameter("@Department", collection.Department);
                SqlParameter JoiningDate = new SqlParameter("@joiningDate", collection.JoiningDate);
                var data = db.Database.ExecuteSqlCommand("exec UpdateEmployee @EmployeeId, @EmpName ,@BirthofDate,@Gender,@Email,@Phone,@Address,@City,@Department,@joiningDate", empid, EmpName, BirthofDate, Gender, Email, Phone, Address, City, Department, JoiningDate);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            FirstAprochEntities2 db = new FirstAprochEntities2();
            var data = db.GetAllEmployee().Where(a => a.EmployeeId == id).FirstOrDefault();
            return View(data);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                FirstAprochEntities2 db = new FirstAprochEntities2();
                SqlParameter empid = new SqlParameter("@EmployeeId", id);
                var data = db.Database.ExecuteSqlCommand("exec DeleteEmployee @EmployeeId", empid);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
