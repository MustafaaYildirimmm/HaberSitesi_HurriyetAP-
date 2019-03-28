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
            Comment c = db.Comments.Find(id);
            db.Comments.Remove(c);
            return result.GetResult(db);
        }

        public override Result<Comment> GetT(int id)
        {
            return result.GetT(db.Comments.Find(id));
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
            return result.GetListResult(db.Comments.ToList());
        }

        public override Result<int> Update(Comment item)
        {
            Comment c = db.Comments.Find(item.Id);
            c.IsCheck = true;
            return result.GetResult(db);
        }
    }
}
