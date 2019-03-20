using HaberSitesiBitirmeProjesi.Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSitesiBitirmeProjesi.DataAccess
{
    public abstract class DataRepository<T>
    {
        public abstract Result<int> Insert(T item);
        public abstract Result<int> Delete(int id);
        public abstract Result<int> Update(T item);
        public abstract Result<T> GetT(int id);
        public abstract Result<List<T>> List();
    }
}
