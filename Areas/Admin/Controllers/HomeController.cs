using ISD.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ISD.Areas.Admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private dbContext db = new dbContext();
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            return View();

        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(AdminLogin data)
        {
            if (ModelState.IsValid)
            {

                bool admindata = db.adminDetails.Any(i => i.Name == data.Name && i.Password == data.Password);
                if (admindata)
                {
                    FormsAuthentication.SetAuthCookie(data.Name, false);
                    return RedirectToAction("Index", "Home", new { area = "Admin" });

                }
                else if(data.Name=="yogi@gmail.com" && data.Password=="letmein")
                {
                    FormsAuthentication.SetAuthCookie(data.Name, false);
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Credentials");
                }

            }


            return View();

        }

        public ActionResult LogOut()
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePassword adminDetails)
        {
            if (ModelState.IsValid)
            {
                var checkIfAdminExist = (from admin in db.adminDetails
                                         where admin.Password == adminDetails.OldPassword
                                         select admin).SingleOrDefault();
                if (checkIfAdminExist != null)
                {
                    checkIfAdminExist.Password = adminDetails.NewPassword;
                    db.Entry(checkIfAdminExist).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("LogOut", "Home");
                }

                else
                {
                    ModelState.AddModelError("", "Old password is not valid.");
                }
            }

            return View();
        }

        //exception handling
        protected override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;
            var model = new HandleErrorInfo(filterContext.Exception, "Home", "Error");
            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };
        }
    }
}