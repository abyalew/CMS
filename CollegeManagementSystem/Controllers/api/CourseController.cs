using CMS.Business.Contracts;
using CMS.Business.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace CollegeManagementSystem.Controllers.Api
{
    public class CourseController : ApiController
    {
        private readonly ICourseBiz _biz;

        public CourseController(ICourseBiz biz)
        {
            _biz = biz;
        }

        [HttpGet]
        public async Task<List<CourseViewDto>> Index()
        {
            return await _biz.GetPage();
        }
    }
}