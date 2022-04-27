namespace CMS.DataModel
{
    public class StudentGrade
    {
        public int Id { get; set; }
        public int AdmissionId { get; set; }
        public int SubjectId { get; set; }
        public decimal Grade { get; set; }
        public Admission Admission { get; set; }
        public Subject Subject { get; set; }
    }
}
