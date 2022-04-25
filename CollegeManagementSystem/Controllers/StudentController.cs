using CMS.DataModel;
using CMS.DataModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CollegeManagementSystem.Controllers
{
    public class StudentController:Controller
    {
        private readonly IRepository<Student> _repo;

        public StudentController(IRepository<Student> repo)
        {
            _repo = repo;
        }
        public async Task<ActionResult> Index()
        {
            ViewBag.Students = await _repo.GetAllAsync();
            return View();
        }
    }
}