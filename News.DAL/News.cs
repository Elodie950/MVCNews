using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info.DAL
{
    public class News
    {
        private int _idNews;
        private string _infoNews;
        private DateTime _dateNews;
        private string _imageNews;
        private string _titreNews;
        private int _idJournalist;

        public int IdNews {
            get { return _idNews; }
            set { _idNews = value; }
        }

        public string InfoNews {
            get { return _infoNews; }
            set { _infoNews = value; }
        }  
        
        public DateTime DateNews {
            get { return _dateNews; }
            set { _dateNews = value; }
        }

        public string ImageNews {
            get { return _imageNews; }
            set { _imageNews = value; }
        }
        
        public string TitreNews {
            get { return _titreNews; }
            set { _titreNews = value; }
        }
      
        public int IdJournalist {
            get { return _idJournalist; }
            set { _idJournalist = value; }
        }

        public static News ChargerUneNews(int idNews)
        {
            List<Dictionary<string, object>> UneNews =
                GestionConnexion.Instance.getData("select * from News where idNews=" + idNews);
            News nvl = Associe(UneNews[0]);
            return nvl;
        }

        public static List<News> ChargerToutesLesNews()
        {
            List<Dictionary<string, object>> lesNews = GestionConnexion.Instance.getData("select * from News order by idNews DESC");
            List<News> maList = new List<News>();
            foreach (Dictionary<string, object> item in lesNews)
            {
                //Journalist jour = Associe(item);
                maList.Add(Associe(item));
            }
            return maList;
        }

        private static News Associe(Dictionary<string, object> item)
        {
            News nvl = new News()
            {
                IdNews = (int)item["idNews"],
                InfoNews = item["InfoNews"].ToString(),
                DateNews = DateTime.Parse(item["DateNews"].ToString()),
                ImageNews = item["ImageNews"].ToString(),
                TitreNews = item["TitreNews"].ToString(),
                IdJournalist = (int)item["idJournalist"],
            };
            return nvl;
        }

        public static List<News> getReviewsFromNews(int idJournalist)
        {
            List<News> retour = new List<News>();
            List<Dictionary<string, object>> DesNews =
            GestionConnexion.Instance.getData("select * from News where idJournalist=" + idJournalist);

            foreach (Dictionary<string, object> item in DesNews)
            {
                News rev = new News()
                {
                IdNews = (int)item["idNews"],
                InfoNews = item["InfoNews"].ToString(),
                DateNews = DateTime.Parse(item["DateNews"].ToString()),
                ImageNews = item["ImageNews"].ToString(),
                TitreNews = item["TitleNews"].ToString(),
                IdJournalist = (int)item["idJournalist"],
                };
                retour.Add(rev);

            }
            return retour;

        }
 
          public static List<News> ChargerLesdernieresNews()
        {
            List<Dictionary<string, object>> lesNews = GestionConnexion.Instance.getData("SELECT TOP 5 * from News ORDER BY idNews DESC ");
            List<News> maList = new List<News>();
            foreach (Dictionary<string, object> item in lesNews)
            {
                //Journalist jour = Associe(item);
                maList.Add(Associe(item));
            }
            return maList;
        }

          public virtual bool InsererNews(string infoNews, string titreNews, string imageNews, int idJournalist)
          {
              DateTime d = DateTime.Now;
              string query = "Insert into News(infoNews, titreNews, imageNews, dateNews, idJournalist) Values (@infoNews, @titreNews, @imageNews, @dateNews, @idJournalist)";

              Dictionary<string, object> valeurs = new Dictionary<string, object>();
              valeurs.Add("infoNews", infoNews);
              valeurs.Add("titreNews", titreNews);
              valeurs.Add("imageNews", imageNews);
              valeurs.Add("dateNews", d);
              valeurs.Add("idJournalist", idJournalist);

              if (GestionConnexion.Instance.saveData(query, GenerateKey.APP, valeurs))
              {
                  return true;
              }
              else {
                  return false;
              }
          }

          public virtual bool ModifierNews()
          {
              News n = News.ChargerUneNews(this.IdNews);

              string query = @"UPDATE News
                                        SET [TitreNews] = @TitreNews,
                                            [InfoNews] = @InfoNews,
                                            [ImageNews] = @ImageNews,
                                            [idJournalist] = @idJournalist,
                                            WHERE [idNews] = @idNews";

              Dictionary<string, object> valeurs = new Dictionary<string, object>();
              valeurs.Add("idNews", this.IdNews);
              valeurs.Add("TitreNews", this.TitreNews);
              valeurs.Add("InfoNews", this.InfoNews);
              valeurs.Add("idJournalist", this.IdJournalist);

              if (GestionConnexion.Instance.saveData(query, GenerateKey.APP, valeurs))
              {
                  return true;
              }
              else
              {
                  return false;
              }
          }
         

    }
}
