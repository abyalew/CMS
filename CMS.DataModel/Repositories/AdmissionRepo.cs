using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.DataModel.Repositories
{
    public class AdmissionRepo : Reposotory<Admission>, IAdmissionRepo
    {
        public AdmissionRepo(CMSDbContext context) : base(context){}

        public override async Task<Admission> Update(Admission entity)
        {
            foreach(var sg in entity.StudentGrades.ToList())
            {
                if (sg.Id == 0)
                    _context.Entry(sg).State = EntityState.Added;
                else
                    _context.Entry(sg).State = EntityState.Modified;
            }
            var entry = _context.Entry(entity);
            entry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entry.Entity;
        }
    }
}
