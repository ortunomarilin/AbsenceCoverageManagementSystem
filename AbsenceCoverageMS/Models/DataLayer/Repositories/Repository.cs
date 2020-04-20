using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DataLayer.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected readonly AbsenceManagementContext context;
        private DbSet<T> dbSet { get; set; }
        

        
        //Constructor 
        public Repository(AbsenceManagementContext ctx)
        {
            context = ctx;
            dbSet = context.Set<T>(); //Will hold the DbSet<TEntity> 
        }



  
        public IEnumerable<T> List(QueryOptions<T> options)
        {
            IQueryable<T> query = QueryData(options);
            return query.ToList();
        }


        public IEnumerable<T> List()
        {
            return dbSet.ToList();
        }


        public T Get(string id)
        {
            return dbSet.Find(id);
        }

        public virtual T Get(QueryOptions<T> options)
        {
            IQueryable<T> query = QueryData(options);
            return query.FirstOrDefault();
        }



        public void Insert(T entity)
        {
            dbSet.Add(entity);
        }


        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }


        public void Update(T entity)
        {
            dbSet.Update(entity);
        }


        public void Save()
        {
            context.SaveChanges();
        }


        private IQueryable<T> QueryData(QueryOptions<T> options)
        {
            IQueryable<T> query = dbSet;

            //Includes
            if (options.GetIncludes() != null)
            {
                foreach (string include in options.GetIncludes())
                {
                    query = query.Include(include);
                }
            }

            //Where
            if (options.GetWheres() != null)
            {
                foreach (var where in options.GetWheres())
                {
                    query = query.Where(where);
                }
            }

            //OrderBy
            if (options.OrderBy != null)
            {
                query = query.OrderBy(options.OrderBy);
            }


            //Paging 
            if (options.PageNumber > 0 && options.PageSize > 0)
            {
                query = query.Skip((options.PageNumber - 1) * options.PageSize).Take(options.PageSize);
            }

            return query;
        }


    }
}
