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

        public async Task<TEntity> First(Expression<Func<TEntity,bool>> filter)
        {
            return  await _context.Set<TEntity>().FirstAsync(filter);
        }


    }
}
