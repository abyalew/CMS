using CMS.Business.Contracts;
using CMS.Business.Dtos;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CMS.Host.Controllers
{
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