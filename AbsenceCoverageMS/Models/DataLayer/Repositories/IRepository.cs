using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DataLayer.Repositories
{
    public interface IRepository<T> where T : class
    {
        
        IEnumerable<T> List(QueryOptions<T> options);
        IEnumerable<T> List();
       

        //T Get(QueryOptions<T> options);
        T Get(string id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Save();




    }
}
