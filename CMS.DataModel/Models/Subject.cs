using System.Collections.Generic;

namespace CMS.DataModel
{
    public class Subject
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public decimal CreditPoint { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<StudentGrade> StudentGrades { get; set; }
    }
}
