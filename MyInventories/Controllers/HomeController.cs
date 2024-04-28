using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyInventories.Models;
using MyInventories.Repository;
using MyInventories.Utils;
using System.Web.Security;

namespace MyInventories.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(String username, String password, String ReturnUrl)
        {
            if (_usermanager.SignIn(username, password, ref ErrorMessage) == ErrorCode.Success)
            {
                var user = _usermanager.GetUserByUsername(username);

                if (user.status != (Int32)Status.Active)
                {
                    TempData["username"] = username;
                    return RedirectToAction("Verify");
                }
                //
                FormsAuthentication.SetAuthCookie(username, false);
                //
                if (!String.IsNullOrEmpty(ReturnUrl))
                    return Redirect(ReturnUrl);

                switch (user.role.rolename)
                {
                    case Constant.Role_Customer:
                        return RedirectToAction("Index");
                    case Constant.Role_Staff:
                        return RedirectToAction("Index", "");
                    default:
                        return RedirectToAction("Index");
                }
            }
            ViewBag.Error = ErrorMessage;

            return View();
        }
        
        public ActionResult SignUp()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult SignUp(useraccount ua, String ConfirmPass)
        {
            if (!ua.password.Equals(ConfirmPass))
            {
                ModelState.AddModelError(String.Empty, "Password not match");
                ViewBag.Role = Utilities.ListRole;
                return View(ua);
            }

            if (_usermanager.SignUp(ua, ref ErrorMessage) != ErrorCode.Success)
            {
                ModelState.AddModelError(String.Empty, ErrorMessage);

                ViewBag.Role = Utilities.ListRole;
                return View(ua);
            }
            TempData["username"] = ua.username;
            return RedirectToAction("Verify");
        }


    }
}