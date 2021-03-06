using System.Data.Entity;

namespace CMS.DataModel
{
    public class CMSDbContext : DbContext
    {
        public CMSDbContext() : base()
        {
            Database.SetInitializer<CMSDbContext>(new CreateDatabaseIfNotExists<CMSDbContext>());
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Grades { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Admission> Admissions { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<CourseSubject> CourseSubjects { get; set; }
        public DbSet<StudentGrade> StudentGrades { get; set; }
    }

}
