using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DataModel.Repositories
{
    public class Reposotory<TEntity>: IRepository<TEntity> where TEntity:class
    {
        private readonly CMSDbContext _context;

        public Reposotory(CMSDbContext context)
        {
            _context = context;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
        public async Task<List<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            return await Include(_context.Set<TEntity>(),includes).ToListAsync();
        }

        public async Task<TEntity> FirstAsync(Expression<Func<TEntity,bool>> filter)
        {
            return  await _context.Set<TEntity>().FirstAsync(filter);
        }

        public async Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> filter)
        {
           return await _context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            return await Include(_context.Set<TEntity>().Where(filter), includes).ToListAsync();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            var addedEntity =_context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return addedEntity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            var entry = _context.Entry(entity);
            entry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<TEntity> Delete(TEntity entity)
        {
            var removedEntity = _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return removedEntity;
        }

        protected static IQueryable<TEntity> Include(IQueryable<TEntity> query,
            params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> queryable = query;
            foreach (var include in includes)
            {
                queryable = queryable.Include(include);
            }
            return queryable;
        }
    }
}
