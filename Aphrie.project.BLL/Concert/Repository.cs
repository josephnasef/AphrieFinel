using Aphrie.Project.Bll.Abstract;
using Aphrie.Project.DAL.SQLServer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aphrie.Project.Bll.Concert
{
  public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private AphrieContext Context;
        private DbSet<TEntity> _set;
        public Repository()
        {
            Context = new AphrieContext();
            _set = Context.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            _set.Add(entity);
            Save();
            return entity;
        }

        public bool Delete(TEntity entity)
        {
            _set.Remove(entity);

            return Save();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _set;
        }

        public List<TEntity> GetAllBind()
        {
            return GetAll().ToList();
        }

        public TEntity GetBy(params object[] Key)
        {
            return _set.Find(Key);
        }

        public bool Save()
        {
            return Context.SaveChanges() > 0 ? true : false;
        }

        public bool Update(TEntity entity)
        {
            _set.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            return Save();
        }

    }
}
