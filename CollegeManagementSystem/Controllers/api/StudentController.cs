using CMS.DataModel;
using CMS.DataModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace CollegeManagementSystem.Controllers.api
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