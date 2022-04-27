using System.Collections.Generic;

namespace CMS.DataModel
{
    public class Course
    {
        public Course()
        {
            CourseSubjects = new List<CourseSubject>();
        }
        public int Id { get; set; }
        public string AwardTitle { get; set; }
        public ICollection<CourseSubject> CourseSubjects { get; set; }
        public ICollection<Admission> Admissions { get; set; }
    }

}
