using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaberSitesiBitirmeProjesi.Bussiness;
using HaberSitesiBitirmeProjesi.DataAccess;
using HaberSitesiBitirmeProjesi.Entity;
using HaberSitesiBitirmeProjesi.Entity.API;
using PagedList;

namespace HaberSitesiBitirmeProjesi.UI.Areas.Admin.Controllers
{
    public class ArticleController : Controller
    {
        ArticleRep ar = new ArticleRep();
        Result<int> result = new Result<int>();
        // GET: Admin/Article
        public ActionResult List(int? SayfaNo)
        {
            int _sayfaNo = SayfaNo ?? 1;
            var articles = ar.ListApi().ProccessResult.OrderByDescending(m => m.Id).ToPagedList<ArticleApi>(_sayfaNo, 10);
            return View(articles);
        }

        //public ActionResult AddArt(int id)
        //{

        //    result = ar.Insert(ar.GetByIdApi(id).ProccessResult);
        //    if (result.IsSucceed)
        //    {
        //        return RedirectToAction("News", "Admin/Article");
        //    }
        //    return RedirectToAction("List", "Admin/Article");
        //}

        public ActionResult News(int? SayfaNo)
        {
            int _sayfaNo = SayfaNo ?? 1;
            var articles = ar.List().ProccessResult.OrderByDescending(m => m.Id).ToPagedList<Articles>(_sayfaNo, 10);
            return View(articles);
        }

        public ActionResult Details(int id)
        {
            Articles a = ar.GetT(id).ProccessResult;
            if (a != null)
            {
                return View(a);
            }
            else
            {
                return View(ar.GetByIdApi(id).ProccessResult);
            }

        }

        //public ActionResult Delete(int id)
        //{
        //    ar.Delete(id);
        //    return RedirectToAction("News", "Admin/Article");
        //}

        [HttpPost]
        public ActionResult Delete(int id)
        {
            result=ar.Delete(id);
            return Json(result.UserMessage);
        }

        [HttpPost]
        public ActionResult Add(int id)
        {
            result = ar.Insert(ar.GetByIdApi(id).ProccessResult);
            return Json(result.UserMessage);

        }
    }
}