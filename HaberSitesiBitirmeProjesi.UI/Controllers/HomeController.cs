using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaberSitesiBitirmeProjesi.Entity;
using HaberSitesiBitirmeProjesi.Bussiness;
using HaberSitesiBitirmeProjesi.DataAccess;
using System.Diagnostics;
using PagedList;

namespace HaberSitesiBitirmeProjesi.UI.Controllers
{
    public class HomeController : Controller
    {

        Result<int> result = new Result<int>();
        ArticleRep ar = new ArticleRep();
        CategoryRep catRep = new CategoryRep();
        CommentRep cr = new CommentRep();
        List<Articles> art = new List<Articles>();
        // GET: Home
        public ActionResult Index()
        {
            //string path = @"C:\Users\msft_\source\repos\HaberSitesi_HurriyetAPı\HaberSitesiBitirmeSitesi.Exe\obj\Debug\HaberSitesiBitirmeSitesi.Exe.exe";
            //Process.Start(path);
            return View();
        }

        public ActionResult Details(int id)
        {
            Articles a = ar.GetT(id).ProccessResult;
            return View(a);
        }

        public ActionResult GetByCat(int id,int? SayfaNo)
        {
            int _sayfaNo = SayfaNo ?? 1;
            return View(ar.List().ProccessResult.Where(t=>t.CategoryId==id).ToPagedList<Articles>(_sayfaNo,10));
        }
     
        [HttpPost]
        public JsonResult CommentAdd(int id,string message)
        {
            Member m = (Member)Session["User"];
            Comment c = new Comment();
            if (m!=null)
            {
                c.Date = DateTime.Now.ToLocalTime();       
                c.MemberId = m.Id;
                c.ArticleId = id;
                c.IsCheck = false;
                c.Message = message;
            }
            result = cr.Insert(c);
            return Json(result.UserMessage);
        }
    }
}