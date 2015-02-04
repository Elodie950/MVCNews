using Info.DAL;
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
	}
}