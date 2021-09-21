using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDemo.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Employeenames = new string[] { "Elana", "Sarah", "Logan", "Nathan", "Michael" };
            return View();
        }

        public IActionResult Details(string empname)
        {
            ViewBag.Emp = empname;
            return View();
        }
    }
}
