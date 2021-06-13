using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using previous_project.Models;
using previous_project.Repository.Db;
using System.Web.Security;

namespace previous_project.Controllers
{
    public class AccountController : Controller
    {
        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Models.Membership model)
        {
            using (var Table = new BadEntities1())
            {
                bool isVAlid = Table.Users.Any(X => X.UserName == model.UserName && X.Password == model.Password);
                if(isVAlid)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, true);
                    return RedirectToAction("Index", "Department");
                }
                ModelState.AddModelError("", "Invalid username and password");
                return View();
            }
               
        }

        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(User model)
        {
            using (var Table = new BadEntities1())
            {
                Table.Users.Add(model);
                Table.SaveChanges();
            }
            return RedirectToAction("Login");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }

}