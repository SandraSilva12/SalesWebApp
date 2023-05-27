using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SalesWebMVC2.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System;

namespace SalesWebMVC2.Controllers
{
    public class DepartmentsController : Controller
    {

        public IActionResult Index()
        {
            List<Department> list = new List<Department>();
            list.Add(new Department { Id = 1, Name = "Electronics" });
            list.Add(new Department { Id = 2, Name = "Fashion" });

            return View(list);
        }
    }
}
