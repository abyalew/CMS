namespace CMS.Business.Dtos
{
    public class AddmitionDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public decimal Grade { get; set; }
    }

    public class AddmitionEditorDto : AddmitionDto
    {
        public string StudentName { get; set; }
    }

    public class AddmitionReadDto : AddmitionDto
    {
        public string StudentName { get; set; }
        public string CourseName { get; set; }
    }
}
