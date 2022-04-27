using System.Collections.Generic;

namespace CMS.Business.Dtos
{
    public class CourseDto
    {
        public CourseDto()
        {
            Subjects = new List<SubjectDto>();
        }
        public int Id { get; set; }
        public string AwardTitle { get; set; }
        public List<SubjectDto> Subjects { get; set; }
    }

    public class CourseViewDto : CourseDto
    {
        public int NumberOfTeachers { get; set; }
        public int NumberOfStudents { get; set; }
        public decimal AverageGrade { get; set; }
    }
}
