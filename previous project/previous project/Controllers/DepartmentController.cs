using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using previous_project.Repository.Db;

namespace Firstproject.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {

        public ActionResult Index()
        {
            BadEntities1 studentcontext = new BadEntities1();
            List<Department> departments = studentcontext.Departments.ToList();
            return View(departments);
        }
    }
}