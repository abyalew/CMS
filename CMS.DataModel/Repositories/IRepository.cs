using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DataModel.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> First(Expression<Func<TEntity, bool>> filter);
        Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> filter);
        Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> Add(TEntity entity);
    }
}
