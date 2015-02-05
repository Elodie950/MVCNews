using Info.DAL;
using MVCNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCNews.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            List<News> mesNews = News.ChargerLesdernieresNews();
            return View(mesNews);
        }

        public ActionResult LesNews()
        {
            List<News> toutesMesNews = News.ChargerToutesLesNews();
            return View(toutesMesNews);
        }

        [HttpPost]
        public ActionResult Details(int idNews, int idJournalist)
        {
            JournalistNews jn = new JournalistNews()
            {
                Nouvelle = News.ChargerUneNews(idNews),
                Auteur = Journalist.ChargerUnJournalist(idJournalist),

            };
            return View(jn);
        }
	}
}