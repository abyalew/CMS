using CMS.Business.Contracts;
using CollegeManagementSystem.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CollegeManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseBiz _biz;
        private readonly ISubjectBiz _subject;

        public CourseController(ICourseBiz biz, ISubjectBiz subject)
        {
            _biz = biz;
            _subject = subject;
        }

        public async Task<ViewResult> Index()
        {
            return View(await _biz.GetPage());
        }

        [HttpGet]
        public async Task<ViewResult> Edit(int? id)
        {
            var subjects = await _subject.GetPage();
            var viewModel = new CourseEditorViewModel();
            viewModel.Subjects = subjects.Select(s => new SelectListItem { Disabled = false, Text = s.Name, Value = s.Id.ToString() }).ToList();

            if (id.HasValue)
            {
                viewModel.Course = await _biz.GetById(id.Value);
                viewModel.SelectedSubjects = viewModel.Course.Subjects.Select(s => s.Id.ToString()).ToList();
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(CourseEditorViewModel viewModel)
        {
            if (viewModel.SelectedSubjects.Any())
                viewModel.Course.Subjects = viewModel.SelectedSubjects.Select(id => new CMS.Business.Dtos.SubjectDto { Id = Convert.ToInt32(id) }).ToList();
            await _biz.Edit(viewModel.Course);
            return Redirect("/course");
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            await _biz.Delete(id);
            return Redirect("/course");
        }
    }
}