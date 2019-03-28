using HaberSitesiBitirmeProjesi.Bussiness;
using HaberSitesiBitirmeProjesi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSitesiBitirmeProjesi.DataAccess
{
    public class MemberRep : DataRepository<Member>
    {
        private static NewsPaperContext db = Tools.GetConnection();
        ResultProccess<Member> result = new ResultProccess<Member>();

        public override Result<int> Delete(int id)
        {
            db.Member.Remove(db.Member.SingleOrDefault(t => t.Id == id));
            return result.GetResult(db);
        }

        public override Result<Member> GetT(int id)
        {
            return result.GetT(db.Member.Find(id));
        }

        public override Result<int> Insert(Member item)
        {
            item.RoleId = 2;
            db.Member.Add(item);
            return result.GetResult(db);
        }

        public override Result<List<Member>> List()
        {
            return result.GetListResult(db.Member.ToList());
        }
               
        public override Result<int> Update(Member item)
        {
            Member m = db.Member.SingleOrDefault(t => t.Id == item.Id);
            m.Name = item.Name;
            m.Surname = item.Surname;
            m.Email = item.Email;
            m.Password = item.Password;
            return result.GetResult(db);
        }

        public Result<Member> CheckLogIn(Member model)
        {
            Member m = db.Member.Where(t => t.Email == model.Email && t.Password == model.Password).FirstOrDefault();
            return result.GetT(m);
        }
    }
}
