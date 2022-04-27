using System;
using System.Collections.Generic;

namespace CMS.DataModel
{
    public class Student
    {
        public Student()
        {
            Admissions = new List<Admission>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public ICollection<Admission> Admissions { get; set; }
    }
}
