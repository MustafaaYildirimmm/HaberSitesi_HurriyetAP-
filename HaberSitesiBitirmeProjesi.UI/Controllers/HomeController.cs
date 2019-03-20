using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaberSitesiBitirmeProjesi.Entity;
using HaberSitesiBitirmeProjesi.Bussiness;

namespace HaberSitesiBitirmeProjesi.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}