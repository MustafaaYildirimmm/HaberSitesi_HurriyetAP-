using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaberSitesiBitirmeProjesi.DataAccess;
using HaberSitesiBitirmeProjesi.Entity;
using HaberSitesiBitirmeProjesi.Entity.API;

namespace HaberSitesiBitirmeSitesi.Exe
{
    public class Program
    {
        static void Main(string[] args)
        { 
            ArticleRep ar = new ArticleRep();
            ApiMethod hurriyetApi = new ApiMethod();
            List<string> art = new List<string>();
            List<ArticleApi> desArt = new List<ArticleApi>();
            hurriyetApi.Api(art, desArt);
            int i = 0;
            foreach (var item in desArt)
            {
                i++;
                ar.Insert(ar.GetByIdApi(item.Id).ProccessResult);
                if (i == 20)
                    break;
            }
            Console.ReadLine();
        }
    }
}
