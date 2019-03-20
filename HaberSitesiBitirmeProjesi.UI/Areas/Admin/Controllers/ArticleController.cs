using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaberSitesiBitirmeProjesi.Bussiness;
using HaberSitesiBitirmeProjesi.DataAccess;
using HaberSitesiBitirmeProjesi.Entity;

namespace HaberSitesiBitirmeProjesi.UI.Areas.Admin.Controllers
{
    public class ArticleController : Controller
    {
        ArticleRep ar = new ArticleRep();
        Result<int> result = new Result<int>();
        // GET: Admin/Article
        public ActionResult List()
        {
            return View(ar.ListApi().ProccessResult);
        }

        public ActionResult AddArt(int id)
        {
            result = ar.Insert(ar.GetT(id).ProccessResult);
            if (result.IsSucceed)
            {
                return RedirectToAction("News", "Admin/Article");
            }
            return RedirectToAction("List", "Admin/Article");
        }

        public ActionResult News()
        {
            return View(ar.List().ProccessResult);
        }

        public ActionResult Details(int id)
        {
            Articles a = ar.GetT(id).ProccessResult;
            if (a!=null)
            {
                return View(a);
            }
            else
            {
                return View(ar.GetByDb(id).ProccessResult);
            }
            
        }

        public ActionResult Delete(int id)
        {
            ar.Delete(id);
            return RedirectToAction("News", "Admin/Article");
        }
    }
}