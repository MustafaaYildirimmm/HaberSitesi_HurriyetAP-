using HaberSitesiBitirmeProjesi.Bussiness;
using HaberSitesiBitirmeProjesi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSitesiBitirmeProjesi.DataAccess
{
    public class CommentRep : DataRepository<Comment>
    {
        ResultProccess<Comment> result = new ResultProccess<Comment>();
        private static NewsPaperContext db = Tools.GetConnection();

        public override Result<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Result<Comment> GetT(int id)
        {
            throw new NotImplementedException();
        }

        public override Result<int> Insert(Comment item)
        {
            bool check = db.Comments.Any(t => t.ArticleId == item.ArticleId && t.MemberId == item.MemberId);
            if(check==false)
                db.Comments.Add(item);
            return result.GetResult(db);
        }

        public override Result<List<Comment>> List()
        {
            return result.GetListResult(db.Comments.Where(m => m.IsCheck == true).ToList());
        }

        public override Result<int> Update(Comment item)
        {
            throw new NotImplementedException();
        }
    }
}
