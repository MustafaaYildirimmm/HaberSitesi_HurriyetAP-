using HaberSitesiBitirmeProjesi.Bussiness;
using HaberSitesiBitirmeProjesi.Entity;
using HurriyetNet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSitesiBitirmeProjesi.DataAccess
{
    public class ArticleRep : DataRepository<Articles>
    {
        ResultProccess<Articles> result = new ResultProccess<Articles>();
        private static NewsPaperContext db = Tools.GetConnection();
        List<string> art = new List<string>();
        List<Articles> artDes = new List<Articles>();

        public override Result<int> Delete(int id)
        {
            db.Files.RemoveRange(db.Files.Where(t => t.Article.Id == id).ToList());
            db.Articles.Remove(db.Articles.SingleOrDefault(t=>t.Id==id));
            return result.GetResult(db);
        }

        public override Result<int> Insert(Articles item)
        {
            db.Articles.Add(item);
            return result.GetResult(db);
        }

        public override Result<List<Articles>> List()
        {
            return result.GetListResult(db.Articles.ToList());            
        }

        public override Result<int> Update(Articles item)
        {
            throw new NotImplementedException();
        }

        public override Result<Articles> GetT(int id)
        {
            Api(art, artDes);
            foreach (var item in artDes)
            {
                if (item.ArtID == id)
                {
                    return result.GetObjByID(item);
                }
            }
            return result.GetObjByID(null);
        }

        public Result<List<Articles>> ListApi()
        {
            Api(art, artDes);
            return result.GetListResult(artDes);
        }

        public void Api(List<string> artt,List<Articles> artDess)
        {
            HurriyetConf.ApiKey = "d500daf3de1d4d499521850f317d19e8";
            foreach (var item in Hurriyet.AllArticles)
            {
                artt.Add(item.ToString());
            }
            foreach (var item in art)
            {
                artDess.Add(JsonConvert.DeserializeObject<Articles>(item));
            }
        }

        public Result<Articles> GetByDb(int id)
        {
            Files a = db.Files.FirstOrDefault(t=>t.Article.Id==id);
            return result.GetObjByID(a.Article);
        }
                              
    }
}
