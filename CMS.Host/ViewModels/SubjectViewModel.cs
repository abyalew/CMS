using CMS.Business.Dtos;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CMS.Host.ViewModels
{
    public class SubjectViewModel
    {
        public int Id { get; set; }
        public string TeacherId { get; set; }
        public string Name { get; set; }
        public decimal CreditPoint { get; set; }
        public TeacherDto Teacher { get; set; }
        public List<SelectListItem> TeacherSelectList { get; set; }
    }
}