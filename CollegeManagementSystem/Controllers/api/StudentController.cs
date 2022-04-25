using CMS.DataModel;
using CMS.DataModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<Student> Index()
        {
            return _repo.GetAll();
        }
    }
}