using CMS.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollegeManagementSystem.ViewModels
{
    public class CourseEditorViewModel
    {
        public CourseDto Course { get; set; }
        public List<SelectListItem> Subjects { get; set; }
        public List<string> SelectedSubjects { get; set; }
    }
}