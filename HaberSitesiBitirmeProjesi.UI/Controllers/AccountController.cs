using HaberSitesiBitirmeProjesi.Bussiness;
using HaberSitesiBitirmeProjesi.DataAccess;
using HaberSitesiBitirmeProjesi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HaberSitesiBitirmeProjesi.UI.Controllers
{
    public class AccountController : Controller
    {
        MemberRep mr = new MemberRep();
        Result<Member> result = new Result<Member>();
        // GET: Account
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult LogIn(Member model)
        {
            if (ModelState.IsValid)
            {
                result= mr.CheckLogIn(model);
                if (result != null)
                {
                    Session["User"] = result.ProccessResult;
                    FormsAuthentication.SetAuthCookie(result.ProccessResult.Name, true);
                    return RedirectToAction("Index", "Home");
                }
                return View(model);
            }
            return View(model);   
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session["User"] = null;
            return RedirectToAction("LogIn", "Account");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Register(Member model)
        {
            if (mr.Insert(model).IsSucceed)
                return RedirectToAction("LogIn", "Account");
            return View(model);
        }
    }
}