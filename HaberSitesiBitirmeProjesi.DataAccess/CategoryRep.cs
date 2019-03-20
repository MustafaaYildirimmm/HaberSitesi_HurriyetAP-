using HaberSitesiBitirmeProjesi.Bussiness;
using HaberSitesiBitirmeProjesi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSitesiBitirmeProjesi.DataAccess
{
    public class CategoryRep : DataRepository<Category>
    {
        private static NewsPaperContext db = Tools.GetConnection();
        ResultProccess<Category> result = new ResultProccess<Category>();

        public override Result<int> Delete(int id)
        {
            db.Categories.Remove(db.Categories.SingleOrDefault(c => c.ID == id));
            return result.GetResult(db);    
        }

        public override Result<Category> GetT(int id)
        {
            return result.GetObjByID(db.Categories.SingleOrDefault(t => t.ID == id));
        }

        public override Result<int> Insert(Category item)
        {
            db.Categories.Add(item);
            return result.GetResult(db);
        }

        public override Result<List<Category>> List()
        {
            return result.GetListResult(db.Categories.ToList());
        }

        public override Result<int> Update(Category item)
        {
            Category c = db.Categories.SingleOrDefault(t => t.ID == item.ID);
            c.CategoryName = item.CategoryName;
            return result.GetResult(db);
        }
    }
}
