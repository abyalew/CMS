﻿namespace CMS.DataModel
{
    public class Addmition
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public decimal Grade { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }

}
