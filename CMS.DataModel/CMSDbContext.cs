using System.Data.Entity;

namespace CMS.DataModel
{
    public class CMSDbContext : DbContext
    {
        public CMSDbContext() : base()
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Grades { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Addmition> Addmitions { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<CourseSubject> CourseSubjects { get; set; }
    }

}
