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
    public class CategoryController : Controller
    {
        CategoryRep cr = new CategoryRep();
        Result<int> result = new Result<int>();
        // GET: Admin/Category
        public ActionResult List()
        {
            return View(cr.List().ProccessResult);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Create(Category model)
        {
            result = cr.Insert(model);
            if (result.IsSucceed)
                return RedirectToAction("List", "Category");
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            return View(cr.GetT(id).ProccessResult);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(Category model)
        {
            result = cr.Update(model);
            return RedirectToAction("List", "Category");
        }

        public ActionResult Delete(int id)
        {
            result = cr.Delete(id);
            return RedirectToAction("List", "Category");

        }
    }
}