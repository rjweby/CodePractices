using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Firstproject.Models;
using Firstproject.Repository.Db;

namespace Firstproject.Controllers
{
    public class DepartmentController : Controller
    {
        
        public ActionResult Index(int DepartmentId)
        {
            BadEntities studentcontext = new BadEntities();
            List<Department> departments = studentcontext.Departments.ToList();
            return View(departments);
        }
        
    }
}