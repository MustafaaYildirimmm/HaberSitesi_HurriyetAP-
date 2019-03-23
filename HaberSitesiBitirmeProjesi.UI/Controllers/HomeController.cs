using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaberSitesiBitirmeProjesi.Entity;
using HaberSitesiBitirmeProjesi.Bussiness;
using HaberSitesiBitirmeProjesi.DataAccess;
using System.Diagnostics;

namespace HaberSitesiBitirmeProjesi.UI.Controllers
{
    public class HomeController : Controller
    {

        Result<int> result = new Result<int>();
        ArticleRep ar = new ArticleRep();
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

        public ActionResult Dunya(int id)
        {
            art = ar.List().ProccessResult.Where(t => t.CategoryId == id).ToList();
            return View(art);
        }

        public ActionResult Spor(int id)
        {
            art = ar.List().ProccessResult.Where(t => t.CategoryId == id).ToList();
            return View(art);
        }

        public ActionResult Gundem(int id)
        {
            art = ar.List().ProccessResult.Where(t => t.CategoryId == id).ToList();
            return View(art);
        }

        public ActionResult Ekonomi(int id)
        {
            art = ar.List().ProccessResult.Where(t => t.CategoryId == id).ToList();
            return View(art);
        }

        public ActionResult Kelebek(int id)
        {
            art = ar.List().ProccessResult.Where(t => t.CategoryId == id).ToList();
            return View(art);
        }
    }
}