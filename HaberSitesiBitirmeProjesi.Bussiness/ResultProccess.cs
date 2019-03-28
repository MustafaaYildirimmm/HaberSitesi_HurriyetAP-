using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaberSitesiBitirmeProjesi.Entity;

namespace HaberSitesiBitirmeProjesi.Bussiness
{
    public class ResultProccess<T>
    {
        public Result<int> GetResult(NewsPaperContext db)
        {
            Result<int> result = new Result<int>();
            int sonuc=db.SaveChanges();
            if (sonuc>0)
            {
                result.UserMessage = "Başarili";
                result.IsSucceed = true;
                result.ProccessResult = sonuc;
            }
            else
            {
                result.UserMessage = "Başarisiz";
                result.IsSucceed = false;
                result.ProccessResult = sonuc;
            }
            return result;
        }

        public Result<List<T>> GetListResult(List<T> data)
        {
            Result<List<T>> result = new Result<List<T>>();
            if (data!=null)
            {
                result.UserMessage = "Başarili";
                result.IsSucceed=true;
                result.ProccessResult = data;
            }
            else
            {
                result.UserMessage = "Başarisiz";
                result.IsSucceed = false;
                result.ProccessResult = data;
            }
            return result;
        }

        public Result<T> GetT(T data)
        {
            Result<T> result = new Result<T>();
            if (data!=null)
            {
                result.UserMessage = "Başarili";
                result.IsSucceed = true;
                result.ProccessResult = data;
            }
            else
            {
                result.UserMessage = "Başarisiz";
                result.IsSucceed = false;
                result.ProccessResult = data;
            }
            return result;
        }
    }
}
