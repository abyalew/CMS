using System.Collections.Generic;

namespace CMS.DataModel
{
    public class Student
    {
        public Student()
        {
            Addmitions = new List<Addmition>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Addmition> Addmitions { get; set; }
    }
}
