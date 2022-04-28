﻿namespace CMS.DataModel
{
    public class CourseSubject
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public Course Course { get; set; }
    }

}
