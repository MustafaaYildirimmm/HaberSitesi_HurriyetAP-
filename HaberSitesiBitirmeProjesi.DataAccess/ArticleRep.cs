using HaberSitesiBitirmeProjesi.Bussiness;
using HaberSitesiBitirmeProjesi.Entity;
using HaberSitesiBitirmeProjesi.Entity.API;
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

        private static NewsPaperContext db = Tools.GetConnection();

        ResultProccess<ArticleApi> resultApi = new ResultProccess<ArticleApi>();
        ResultProccess<Articles> result = new ResultProccess<Articles>();
        
        List<string> art = new List<string>();
        List<ArticleApi> artDes = new List<ArticleApi>();
        ApiMethod HurriyetApi = new ApiMethod();

        public override Result<int> Delete(int id)
        {
            db.Articles.Remove(db.Articles.SingleOrDefault(t => t.Id == id));
            return result.GetResult(db);
        }

        public override Result<int> Insert(Articles item)
        {
            bool check = db.Articles.Any(t => t.ArticleId == item.ArticleId);
            if(check==false&&item.CategoryId!=null)
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
            return result.GetT(db.Articles.SingleOrDefault(t => t.Id == id));
        }

        public Result<List<ArticleApi>> ListApi()
        {
            HurriyetApi.Api(art, artDes);
            return resultApi.GetListResult(artDes);
        }

        public Result<Articles> GetByIdApi(int id)
        {
            ArticleApi item=HurriyetApi.SingleApi(id);
            CategoryRep cr = new CategoryRep();
            Articles a = new Articles();          
            a.Title = item.Title;
            a.Description = item.Description;
            a.NewsDate = item.ModifiedDate;
            a.ArticleId = item.Id;
            a.Text = item.Text;
            if (item.Files!=null)
            {
                foreach (var photo in item.Files)
                {
                    a.Photo = photo.FileUrl;
                    break;
                }
            }
            if (item.Path!=null)
            {
                foreach (var cat in cr.List().ProccessResult)
                {
                    if (item.Path.ToLower().Contains(cat.CategoryName.Replace("ü", "u").ToLower()))
                        a.CategoryId = cat.ID;
                }
            }
            
            return result.GetT(a);
        }

        public Result<List<Articles>> GetByIdLatestNews(int Quantity)
        {
            return result.GetListResult(db.Articles.OrderByDescending(t => t.Id).Take(Quantity).ToList());
        }
    }
}
