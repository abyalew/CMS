using CMS.Business.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CMS.Host.ViewModels
{
    public class AdmissionViewModel
    {
        public int StudentId { get; set; }
        public string CourseId { get; set; }
        public string StudentName { get; set; }
        public DateTime StudentBirthday { get; set; }
        public string CourseName { get; set; }
        public int RegistrationNo { get; set; }
        public decimal Grade { get; set; }
        public List<StudentGradeDto> StudentGrades { get; set; }
    }

    public class AdmissionEditorViewModel : AdmissionViewModel
    {
        public AdmissionEditorViewModel()
        {
            CourseSelectList = new List<SelectListItem>();
        }

        public List<SelectListItem> CourseSelectList { get; set; }
    }
}