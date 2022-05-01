using CMS.DataModel;
using CMS.DataModel.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace CMS.Host.Controllers.Api
{
    public class StudentController : ApiController
    {
        private readonly IRepository<Student> _repo;

        public StudentController(IRepository<Student> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<List<Student>> Index()
        {
            return await _repo.GetAllAsync();
        }
    }
}