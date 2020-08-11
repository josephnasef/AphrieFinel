using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aphrie.Project.Bll.Abstract
{
    interface IRepository<TEntity>
    {
        List<TEntity> GetAllBind();
        IQueryable<TEntity> GetAll();
        TEntity GetBy(params object[] Key);
        TEntity Add(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
        bool Save();
    }
}
