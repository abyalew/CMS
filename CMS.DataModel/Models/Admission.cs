using System.Collections.Generic;

namespace CMS.DataModel
{
    public class Admission
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public decimal Grade { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
        public ICollection<StudentGrade> StudentGrades { get; set; }
    }

}
