using HaberSitesiBitirmeProjesi.Bussiness;
using HaberSitesiBitirmeProjesi.DataAccess;
using HaberSitesiBitirmeProjesi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaberSitesiBitirmeProjesi.UI.Areas.Admin.Controllers
{
    public class MemberController : Controller
    {
        MemberRep mr = new MemberRep();
        Result<int> result = new Result<int>();
        // GET: Admin/Member
        public ActionResult List()
        {
            return View(mr.List().ProccessResult);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Member model)
        {
            if (ModelState.IsValid)
            {
                result = mr.Insert(model);
            }
            if (result.IsSucceed)
            {
                return RedirectToAction("List", "Member");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            return View(mr.GetT(id).ProccessResult);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Edit(Member model)
        {
            if (ModelState.IsValid)
            {
                result = mr.Update(model);
            }
            return RedirectToAction("List", "Member");
        }

        public ActionResult Delete(int id)
        {
            mr.Delete(id);
            return RedirectToAction("List", "Member");
        }
    }
}