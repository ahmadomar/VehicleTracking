using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using VehicleTracking.DataMS.DataContext;

namespace VehicleTracking.DataMS.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        #region Properties

        private VehicleDBContext dataContext;
        private DbSet<T> dbSet;
        
        #endregion

        public RepositoryBase(VehicleDBContext dataContext)
        {
            this.dataContext = dataContext;
            dbSet = dataContext.Set<T>();
        }


        #region Implementation

        public virtual EntityEntry<T> Add(T entity)
        {
            return dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T,bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbSet.Remove(obj);
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual T GetById(string id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> Take(int top, Func<T, object> OrderByColumn)
        {
            return dbSet.OrderByDescending(OrderByColumn).Take(top);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T,bool>> where)
        {
            return dbSet.Where(where).ToList();
        }
        
        public T Get(Expression<Func<T,bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault<T>();
        }
        #endregion

    }
}
