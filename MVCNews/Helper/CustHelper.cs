using Info.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCNews.Helper
{
    public static class CustHelper
    {

        public static MvcHtmlString GenererNews(this HtmlHelper origin, IEnumerable<News> lesNews)
        {
            
                TagBuilder principal = new TagBuilder("div");
                principal.Attributes.Add("id", "contentNews");
            foreach (News item in lesNews) {
                TagBuilder div = new TagBuilder("div");
                div.Attributes.Add("id", "divNews");

                TagBuilder titre = new TagBuilder("h3");
                TagBuilder photo = new TagBuilder("img");
                TagBuilder info = new TagBuilder("p");
                TagBuilder date = new TagBuilder("p");

                div.InnerHtml += titre.ToString();
                div.InnerHtml += photo.ToString();
                div.InnerHtml += info.ToString();
                div.InnerHtml += date.ToString();

                principal.InnerHtml += div.ToString();
                
            }
         
            return new MvcHtmlString(principal.ToString());
        }
    }
}