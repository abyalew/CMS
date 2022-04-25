namespace CMS.DataModel
{
    public class Class
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int AddmitionId { get; set; }
        public Teacher Teacher { get; set; }
        public Addmition Addmition { get; set; }
    }

}
