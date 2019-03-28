using HaberSitesiBitirmeProjesi.Bussiness;
using HaberSitesiBitirmeProjesi.DataAccess;
using HaberSitesiBitirmeProjesi.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaberSitesiBitirmeProjesi.UI.Areas.Admin.Controllers
{
    public class CommentController : Controller
    {
        Result<int> result = new Result<int>();
        CommentRep cr = new CommentRep();
        // GET: Admin/Comment
        public ActionResult List(int? SayfaNo)
        {
            int _sayfaNo = SayfaNo ?? 1;
            var comment = cr.List().ProccessResult.Where(t=>t.IsCheck==false).OrderByDescending(t => t.Date).ToPagedList<Comment>(_sayfaNo, 10);
            return View(comment);
        }

        public ActionResult ConfComment(int? SayfaNo)
        {
            int _sayfaNo = SayfaNo ?? 1;
            var comment = cr.List().ProccessResult.Where(t => t.IsCheck == true).OrderByDescending(t => t.Date).ToPagedList<Comment>(_sayfaNo, 10);
            return View(comment);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            result = cr.Delete(id);
            return Json(result.UserMessage);
        }

        [HttpPost]
        public ActionResult Confirm(int id)
        {
            result = cr.Update(cr.GetT(id).ProccessResult);
            return Json(result.UserMessage);
        }
    }
}