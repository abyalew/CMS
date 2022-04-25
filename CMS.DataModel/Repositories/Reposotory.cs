using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DataModel.Repositories
{
    public class Reposotory<TEntity>: IRepository<TEntity> where TEntity:class
    {
        private readonly DbContext _context;

        public Reposotory(CMSDbContext context)
        {
            _context = context;
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }


    }
}
