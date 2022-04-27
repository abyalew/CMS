using CMS.Business.Dtos;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CMS.Host.ViewModels
{
    public class CourseEditorViewModel
    {
        public CourseDto Course { get; set; }
        public List<SelectListItem> Subjects { get; set; }
        public List<string> SelectedSubjects { get; set; }
    }
}