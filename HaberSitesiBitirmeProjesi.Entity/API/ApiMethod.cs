using HaberSitesiBitirmeProjesi.Entity.API;
using HurriyetNet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSitesiBitirmeProjesi.Entity
{
    public class ApiMethod
    {
        
        //haberlerin tamamının listelenmesi
        public void Api(List<string> art,List<ArticleApi> artDes)
        {
            HurriyetConf.ApiKey = "d500daf3de1d4d499521850f317d19e8";
            foreach (var item in Hurriyet.AllArticles)
            {
                art.Add(item.ToString());
            }
            foreach (var item in art)
            {
                artDes.Add(JsonConvert.DeserializeObject<ArticleApi>(item));
            }
        }

        //id e göre haberin çekilme islemi.. haberin textini alabilmek icin yaptım.
        public ArticleApi SingleApi(int id)
        {
            HurriyetConf.ApiKey = "d500daf3de1d4d499521850f317d19e8";
            ArticleApi ap = new ArticleApi();
            string json;
            json = Hurriyet.SingleArticle(id.ToString()).ToString();
            ap = JsonConvert.DeserializeObject<ArticleApi>(json);
            return ap;
        }
    }
}
