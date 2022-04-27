namespace CMS.DataModel
{
    public class StudentGrade
    {
        public int Id { get; set; }
        public int AddmitionId { get; set; }
        public int SubjectId { get; set; }
        public Addmition Addmition { get; set; }
        public Subject Subject { get; set; }
    }
}
