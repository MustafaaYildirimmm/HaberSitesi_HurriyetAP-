using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaberSitesiBitirmeProjesi.Entity;

namespace HaberSitesiBitirmeProjesi.Bussiness
{
    public class Tools
    {
        public static NewsPaperContext db = null;
     
        public static NewsPaperContext GetConnection()
        {
            if (db == null)
            {
              
                db = new NewsPaperContext();
            }
               return db;
               
        }
    }
}
