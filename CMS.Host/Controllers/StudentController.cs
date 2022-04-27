using CMS.Business.Contracts;
using CMS.DataModel;
using CMS.DataModel.Repositories;
using CMS.Host.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CMS.Host.Controllers
{
    public class StudentController : Controller
    {
        private readonly IAddmitionBiz _biz;

        public StudentController(IAddmitionBiz biz)
        {
            _biz = biz;
        }
        public async Task<ActionResult> Index()
        {
            var data = await _biz.GetAll();
            var vm = new List<StudentViewModel>();

            return View(data);
        }
    }
}