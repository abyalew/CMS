using System.Collections.Generic;

namespace CMS.Business.Dtos
{
    public class AdmissionDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public decimal Grade { get; set; }
        public StudentDto Student { get; set; }
        public CourseDto Course { get; set; }
    }

    public class AdmissionEditorDto : AdmissionDto
    {
        public string StudentName { get; set; }
    }

    public class AdmissionReadDto : AdmissionDto
    {
        public string StudentName { get; set; }
        public string CourseName { get; set; }
        public List<StudentGradeDto> StudentGrades { get; set; }
    }
}
