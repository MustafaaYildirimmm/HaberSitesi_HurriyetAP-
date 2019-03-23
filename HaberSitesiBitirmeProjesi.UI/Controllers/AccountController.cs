using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaberSitesiBitirmeProjesi.UI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult LogIn()
        {
            
            return View();
        }

        public ActionResult LogOut()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}