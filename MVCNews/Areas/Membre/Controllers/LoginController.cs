using Info.DAL;
using MVCNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCNews.Areas.Membre.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Membre/Login/
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult SeLogger()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SeLogger(string txtLogin, string txtPassword)
        {
            if (SessionTools.Login == null)
            {
                Journalist j = Journalist.AuthentifieMoi(txtLogin, txtPassword);
                if (j == null)
                {
                    return View();
                }
                else
                {
                    SessionTools.Login = txtLogin;
                    SessionTools.Journalist = j;
                }
            }
            return RedirectToRoute(new { controller = "Home", action = "Index", area = "" });
        }


        public RedirectToRouteResult Logoff()
        {
            SessionTools.Login = null;
            Session.Abandon();
            return RedirectToRoute(new { controller = "Home", action = "Index", area = "" });
        }
	}
}