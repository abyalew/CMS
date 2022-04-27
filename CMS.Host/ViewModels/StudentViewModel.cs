using System.Collections.Generic;
using System.Web.Mvc;

namespace CMS.Host.ViewModels
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string CourseId { get; set; }
        public int StudentRegistrationNo { get; set; }
        public decimal Grade { get; set; }
        public List<SelectListItem> CourseSelectList { get; set; }
    }
}