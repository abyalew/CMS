using CMS.DataModel;
using CMS.DataModel.Repositories;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CollegeManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly IRepository<Student> _repo;

        public StudentController(IRepository<Student> repo)
        {
            _repo = repo;
        }
        public async Task<ActionResult> Index()
        {
            var data = await _repo.GetAllAsync();
            return View(data);
        }
    }
}