using Info.DAL;
using MVCNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCNews.Areas.Membre.Controllers
{
    public class CrudNewsController : Controller
    {
        //
        // GET: /Membre/CrudNews/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InsererNews() {
            if (SessionTools.Journalist != null)
            {
                return View();
            }
            else {
                return RedirectToRoute(new { controller = "Home", action = "Index", area = "" });
            }
            
        }
        [HttpPost]
        public ActionResult InsererNewsDB(string titreNews, string infoNews, string imageNews)
        {
            int idJournalist = SessionTools.Journalist.IdJournalist;
            News n = new News();
            n.InsererNews( infoNews,titreNews, imageNews, idJournalist);
            return RedirectToRoute(new { controller = "Home", action = "Index", area = "" });
        }

        [HttpGet]
        public ActionResult Modifier(int id)
        {
                News n = News.ChargerUneNews(id);
                return View(n);
        }

        [HttpPost]
        public ActionResult Modifier(News n)
        {
            n.ModifierNews();
            return RedirectToRoute(new { controller = "Home", action = "Index", area = "" });
        }

        //[HttpPost]
        //public ActionResult Supprimer(News n)
        //{
            
        //    return RedirectToRoute(new { controller = "Home", action = "Index", area = "" });
        //}
	}
}