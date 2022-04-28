using System.ComponentModel.DataAnnotations;

namespace CMS.Business.Dtos
{
    public class StudentGradeDto
    {
        public int Id { get; set; }
        public int AdmissionId { get; set; }
        public int SubjectId { get; set; }
        [Range(0.0, 4, ErrorMessage = "The field {0} must be greater than 0 and less than 4.")]
        public decimal? Grade { get; set; }
        public SubjectDto Subject { get; set; }
    }
}
