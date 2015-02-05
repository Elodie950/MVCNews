using Info.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCNews.Models
{
    public class SessionTools
    {
        public static string Login
        {
            get
            {
                try
                {
                    return HttpContext.Current.Session["Login"].ToString();
                }
                catch
                {
                    return null;
                }
            }
            set { HttpContext.Current.Session["Login"] = value; }
        }

        public static Journalist Journalist
        {
            get {

                if (HttpContext.Current.Session["Journalist"] == null)
                {
                    HttpContext.Current.Session["Journalist"] = new Journalist();
                }
                return (Journalist)HttpContext.Current.Session["Journalist"];
            }
            set {
                HttpContext.Current.Session["Journalist"] = value;
            }
 
        }

    }
}