using Info.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCNews.Models
{
    public class JournalistNews
    {
        News _nouvelle;
        Journalist _auteur;

        public News Nouvelle
        {
            get { return _nouvelle; }
            set { _nouvelle = value; }
        }

        public Journalist Auteur {
            get { return _auteur; }
            set { _auteur = value; }
        }
    }
}