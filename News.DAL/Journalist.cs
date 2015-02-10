using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info.DAL
{
    public class Journalist
    {
        private int _idJournalist;
        private string _nameJournalist;
        private string _firstNameJournalist;
        private string _loginJournalist;
        private string _passwordJournalist;
        //private List<News> _listNews;

        public int IdJournalist {
            get { return _idJournalist; }
            set { _idJournalist = value; }
        }

        public string NameJournalist {
            get { return _nameJournalist; }
            set { _nameJournalist = value; }
        }

        public string FirstNameJournalist {
            get { return _firstNameJournalist; }
            set { _firstNameJournalist = value; }
        }

        public string LoginJournalist {
            get { return _loginJournalist; }
            set { _loginJournalist = value; }
        }

        public string PasswordJournalist {
            get { return _passwordJournalist; }
            set { _passwordJournalist = value; }
        }

        //private List<News> ListNews
        //{
        //    get
        //    {
        //        if (_listNews == null)
        //        {
        //            _listNews = ChargerLesNews();
        //        }
        //        return _listNews;
        //    }
        //    set { _listNews = value; }
        //}


        public static Journalist ChargerUnJournalist(int idJourn)
        {
            List<Dictionary<string, object>> UnJournalist =
                GestionConnexion.Instance.getData("select * from Journalist where idJournalist="+ idJourn);
            Journalist jou = Associe(UnJournalist[0]);
            return jou;
        } 
        
        public static List<Journalist> ChargerTousLesJournalist() 
        {
            List<Dictionary<string, object>> lesJourn = GestionConnexion.Instance.getData("select * from Journalist");
            List<Journalist> maList = new List<Journalist>();
            foreach (Dictionary<string, object> item in lesJourn)
            {
                //Journalist jour = Associe(item);
                maList.Add(Associe(item));
            }
            return maList;
        }

        private static Journalist Associe(Dictionary<string, object> item)
        {
            Journalist jou =  new Journalist()
            {
                IdJournalist = (int)item["idJournalist"],
                NameJournalist = item["NameJournalist"].ToString(),
                FirstNameJournalist = item["FirstNameJournalist"].ToString(),
                LoginJournalist = item["LoginJournalist"].ToString(),
                PasswordJournalist = item["PasswordJournalist"].ToString(),
            };
            return jou;
        }

        private List<News> ChargerLesNews() {
          
             return News.getReviewsFromNews(this.IdJournalist);
         
            //string query = @"select * from News where idJournalist=" + this.IdJournalist;
            //List<News> retour = new List<News>();
            //List<Dictionary<string, object>> MesNews = GestionConnexion.Instance.getData(query);
            //foreach (Dictionary<string, object> item in MesNews)
            //{
            //    News n = new News();
            //    n.IdNews = (int)item["idNews"];
            //    n.TitleNews = item["TitleNews"].ToString();
            //    n.InfoNews = item["InfoNews"].ToString();
            //    n.PhotoNews = item["PhotoNews"].ToString();
            //}
            //return retour;
        }

        public static Journalist AuthentifieMoi(string login, string password)
        {
            List<Dictionary<string, object>> infoJournalist = GestionConnexion.Instance.getData("Select * from Journalist where LoginJournalist='" + login + "' and PasswordJournalist='" + password + "'");
            Journalist retour = null;
            if (infoJournalist.Count > 0)
            {
                int idJournalist = (int)infoJournalist[0]["idJournalist"];
                retour = Journalist.ChargerUnJournalist(idJournalist);
            }
            return retour;
        }
       

    }
}

