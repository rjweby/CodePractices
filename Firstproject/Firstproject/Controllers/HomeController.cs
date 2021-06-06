using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Firstproject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //if (User.Identity.IsAuthenticated)
            //{
                return View();
            //}
            //else
            //{
            //   return Redirect("/User/Login");
            //}
        }
        [Route("/aboutdetail")]
        public ActionResult About()
        {
            ViewBag.Message = "First Project.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
       
    
       
    }
}