using CMS.Business.Contracts;
using CMS.Business.Dtos;
using CMS.Host.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CMS.Host.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectBiz _biz;
        private readonly ITeacherBiz _teacherBiz;

        public SubjectController(ISubjectBiz biz,ITeacherBiz teacherBiz)
        {
            _biz = biz;
            _teacherBiz = teacherBiz;
        }
        public async Task<ViewResult> Index()
        {
            return View(await _biz.GetAll());
        }

        [HttpGet]
        public async Task<ViewResult> Edit(int? id)
        {
            var teachers = await _teacherBiz.GetAll();
            var vm = new SubjectViewModel
            {
                TeacherSelectList = teachers.Select(t => 
                                new SelectListItem { 
                                    Disabled = false, 
                                    Text = t.Name, 
                                    Value = t.Id.ToString() 
                                }).ToList()
            };
            if (id.HasValue)
            {
                var subject = await _biz.GetById(id.Value);
                vm.Id = subject.Id;
                vm.Name = subject.Name;
                vm.Teacher = subject.Teacher;
                vm.TeacherId = subject.TeacherId.ToString();
                vm.CreditPoint = subject.CreditPoint;
                return View(vm);
            }
            return View(vm);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(SubjectViewModel vm)
        {
            var subject = new SubjectDto
            {
                Id = vm.Id,
                Name = vm.Name,
                TeacherId = Convert.ToInt32(vm.TeacherId),
                CreditPoint = vm.CreditPoint
            };
            await _biz.Edit(subject);
            return Redirect("/subject");
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            await _biz.Delete(id);
            return Redirect("/subject");
        }


    }
}