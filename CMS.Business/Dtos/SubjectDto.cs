namespace CMS.Business.Dtos
{
    public class SubjectDto
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public decimal CreditPoint { get; set; }
        public TeacherDto Teacher { get; set; }

        public int NumberOfStudents { get; set; }
    }
}
