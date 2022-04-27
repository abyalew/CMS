using CMS.Business.Contracts;
using CMS.Business.Dtos;
using CMS.DataModel;
using CMS.DataModel.Repositories;
using CMS.Host.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CMS.Host.Controllers
{
    public class StudentController : Controller
    {
        private readonly IAdmissionBiz _biz;
        private readonly ICourseBiz _courseBiz;

        public StudentController(IAdmissionBiz biz,ICourseBiz courseBiz)
        {
            _biz = biz;
            _courseBiz = courseBiz;
        }

        public async Task<ActionResult> Index()
        {
            var data = await _biz.GetAll();
            var vm = data.Select(a =>
                new AdmissionViewModel
                {
                    RegistrationNo = a.Id,
                    CourseName = a.Course.AwardTitle,
                    StudentName = a.Student.Name,
                    Grade = a.Grade,
                    StudentGrades = a.StudentGrades
                }
            ).ToList();

            return View(vm);
        }

        [HttpGet]
        public async Task<ViewResult> Edit(int? id)
        {
            var courses = await _courseBiz.GetPage();

            var vm = new AdmissionEditorViewModel
            {
                CourseSelectList = courses.Select(c => new SelectListItem { Disabled = false, Text = c.AwardTitle, Value = c.Id.ToString() }).ToList()
            };

            return View(vm);
        }

        [HttpGet]
        public async Task<ViewResult> EditGrade(int id)
        {
            var a = await _biz.GetById(id);
            var vm = new AdmissionViewModel
            {
                CourseId = a.CourseId.ToString(),
                CourseName = a.Course.AwardTitle,
                RegistrationNo = a.Id,
                StudentGrades = a.StudentGrades,
                StudentId = a.StudentId,
                StudentName = a.Student.Name,
                StudentBirthday = a.Student.Birthday
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(AdmissionEditorViewModel viewModel)
        {

            var admission = new AdmissionEditorDto
            {
                CourseId = Convert.ToInt32(viewModel.CourseId),
                StudentName = viewModel.StudentName,
                Student = new StudentDto
                {
                    Name = viewModel.StudentName,
                }
            };
            await _biz.Edit(admission);
            return Redirect("/student");
        }
        
        [HttpPost]
        public async Task<ActionResult> EditGrade(AdmissionViewModel viewModel)
        {

            var admission = new AdmissionReadDto
            {
                Id = viewModel.RegistrationNo,
                StudentGrades = viewModel.StudentGrades
            };

            await _biz.EditGrade(admission);
            return Redirect("/student");
        }
    }

    public class TeacherController : Controller
    {
        private readonly ITeacherBiz _biz;

        public TeacherController(ITeacherBiz biz)
        {
            _biz = biz;
        }
        public async Task<ActionResult> Index()
        {
            var data = await _biz.GetAll();

            return View(data);
        }

        [HttpGet]
        public async Task<ViewResult> Edit(int? id)
        {
            if (id.HasValue)
                return View(await _biz.GetById(id.Value));
            else
                return View();
        }

        [HttpPost]
        public async Task<ActionResult> Edit(TeacherDto teacher)
        {
            await _biz.Edit(teacher);
            return Redirect("/Teacher");
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            await _biz.Delete(id);
            return Redirect("/Teacher");
        }
    }
}