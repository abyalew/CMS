using CMS.Business.Contracts;
using CMS.Business.Dtos;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CollegeManagementSystem.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectBiz _biz;

        public SubjectController(ISubjectBiz biz)
        {
            _biz = biz;
        }
        public async Task<ViewResult> Index()
        {
            return View(await _biz.GetPage());
        }

        [HttpGet]
        public async Task<ViewResult> Edit(int? id)
        {
            if (id.HasValue)
                return View(await _biz.GetById(id.Value));
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Edit(SubjectDto subject)
        {
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