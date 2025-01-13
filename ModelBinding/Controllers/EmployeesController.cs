using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelBinding.Models;

namespace ModelBinding.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: EmployeesController
        public ActionResult Index()
        {
            List<Employee> employee = Employee.GetAllEmployees();
           // Console.WriteLine(employee.ToString());
            return View(employee);
        }



        /****************************************************************************/



        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            Employee employee = Employee.GetSingleEmployee(id);
            return View(employee);
        }


        /****************************************************************************/




        // GET: EmployeesController/Create
        public ActionResult Create()
        {


            return View();
        }



        /****************************************************************************/


        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Employee emp , IFormCollection collection)
        {

            try
            {
                Employee.Insert(emp);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        /****************************************************************************/



        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            Employee emp = Employee.GetSingleEmployee(id);
            return View(emp);
        }



        /****************************************************************************/


        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee obj)
        {
           // Employee emp = Employee.GetSingleEmployee(id);
            try
            {
               

                Employee.Update(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        /****************************************************************************/



        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            Employee emp = Employee.GetSingleEmployee(id);
            return View(emp);
        }


        /****************************************************************************/


        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Employee.Delete(id);    

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
