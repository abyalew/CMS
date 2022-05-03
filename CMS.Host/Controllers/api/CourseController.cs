using CMS.Business.Contracts;
using CMS.Business.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace CMS.Host.Controllers.Api
{
    public class CourseController : ApiController
    {
        private readonly ICourseBiz _biz;

        public CourseController(ICourseBiz biz)
        {
            _biz = biz;
        }

        [HttpGet]
        public async Task<Response<List<CourseViewDto>>> GetAll()
        {
            return new SuccessResponse<List<CourseViewDto>>(await _biz.GetPage());
        }
    }
}