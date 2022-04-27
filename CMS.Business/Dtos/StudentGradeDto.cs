namespace CMS.Business.Dtos
{
    public class StudentGradeDto
    {
        public int Id { get; set; }
        public int AdmissionId { get; set; }
        public int SubjectId { get; set; }
        public decimal? Grade { get; set; }
        public SubjectDto Subject { get; set; }
    }
}
