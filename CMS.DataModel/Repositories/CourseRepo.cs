using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.DataModel.Repositories
{
    public class CourseRepo : Reposotory<Course>, ICourseRepo
    {
        public CourseRepo(CMSDbContext context):base(context)
        {

        }

        public override async Task<Course> Update(Course entity)
        {
            var old = await FirstAsync(c => c.Id == entity.Id, c=>c.CourseSubjects);
            old.AwardTitle = entity.AwardTitle;
            foreach(var cs in entity.CourseSubjects)
            {
                if(!old.CourseSubjects.Any(s=>s.SubjectId == cs.SubjectId))
                    old.CourseSubjects.Add(cs);
            }
            foreach (var cs in old.CourseSubjects.ToList())
            {
                var isDeleted = !entity.CourseSubjects.Any(s => s.SubjectId == cs.SubjectId);

                if (isDeleted)
                    _context.Entry(cs).State = EntityState.Deleted;
            }
                var entry = _context.Entry(old);
            entry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<Course> Delete(int courseId)
        {
            var courseToDelete = await FirstAsync(c => c.Id == courseId, c => c.CourseSubjects);
            foreach(var cs in courseToDelete.CourseSubjects.ToList())
                _context.Set<CourseSubject>().Remove(cs);

            var removedEntity = _context.Set<Course>().Remove(courseToDelete);
            await _context.SaveChangesAsync();
            return removedEntity;
        }
    }
}
