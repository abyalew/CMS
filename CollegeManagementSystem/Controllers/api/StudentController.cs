using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CollegeManagementSystem.Controllers.api
{
    public class StudentController : ApiController
    {
        [HttpGet]
        public string Index()
        {
            return "wellcom to student cotroller";
        }
    }
}