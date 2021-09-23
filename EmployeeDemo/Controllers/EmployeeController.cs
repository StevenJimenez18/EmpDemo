using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDemo.Services;
using EmployeeDemo.Models;

namespace EmployeeDemo.Controllers
{
    

    public class EmployeeController : Controller
    {
        IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository repository)
        {
            _employeeRepository = repository;
        }

        public ViewResult AllEmployees()
        {
            var employees = _employeeRepository.GetEmployees();
            return View(employees);
        }

        [HttpGet]
        public ViewResult CreateEmployee()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult CreateEmployee(Employee obj)
        {
            if (ModelState.IsValid)
            {
                Employee newEmp = _employeeRepository.AddEmployee(obj);
                return RedirectToAction("AllEmployees");
            }

            return View();
        }


        [HttpGet]
        public ViewResult UpdateEmployee(int id)
        {
            Employee emp = _employeeRepository.GetEmployee(id);
            return View(emp);
        }

        [HttpPost]
        public ViewResult UpdateEmployee(Employee emp, int id)
        {
            emp.Eid = id;
            Employee updatedEmp = _employeeRepository.UpdateEmployee(emp);
            var model = _employeeRepository.GetEmployees();
            return View("AllEmployees", model);
        }


        [HttpGet]
        public IActionResult DeleteEmployee(int id)
        {
            _employeeRepository.DeleteEmployee(id);
            return RedirectToAction("AllEmployees");
        }

        public IActionResult Index()
        {
            ViewBag.Employeenames = new string[] { "Elena", "Sarah", "Logan", "Nathan", "Michael" };
            return View();
        }

        public IActionResult Details(string empname)
        {
            ViewBag.Emp = empname;
            return View();
        }

        public IActionResult GetImage(string empname)
        {
            return File($@"\images\{empname.ToLower()}.png","image/jpg");
        }


    }
}
