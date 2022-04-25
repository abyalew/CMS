using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Business.Dtos
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string AwardTitle { get; set; }
        //public List<CourseSubject> CourseSubjects { get; set; }
    }

    public class CourseViewDto : CourseDto
    {
        public int NumberOfTeachers { get; set; }
        public int NumberOfStudents { get; set; }
        public decimal AverageGrade { get; set; }
    }
}
