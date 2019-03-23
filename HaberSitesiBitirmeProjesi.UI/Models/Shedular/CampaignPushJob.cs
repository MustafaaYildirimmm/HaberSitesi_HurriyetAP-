using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using HaberSitesiBitirmeProjesi.DataAccess;
using HaberSitesiBitirmeProjesi.Entity.API;
using HaberSitesiBitirmeProjesi.Entity;

namespace HaberSitesiBitirmeProjesi.UI.Models.Shedular
{
    public class CampaignPushJob : IJob
    {
        void IJob.Execute(IJobExecutionContext context)
        {
            var artApi = new ApiMethod();
            var ar = new ArticleRep();
            List<string> art = new List<string>();
            List<ArticleApi> artDes = new List<ArticleApi>();
            int i = 0;
            artApi.Api(art, artDes);
            if (artDes.Count!=0)
            {
                foreach (var item in artDes)
                {
                    ar.Insert(ar.GetByIdApi(item.Id).ProccessResult);
                    i++;
                    if (i == 20)
                        break;
                }
            }
            
        }
    }
}