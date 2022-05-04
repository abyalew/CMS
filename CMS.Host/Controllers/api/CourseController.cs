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
            return new SuccessResponse<List<CourseViewDto>>(await _biz.GetAll());
        }

        [HttpGet]
        public async Task<Response<CourseDto>> GetById(int id)
        {
            return new SuccessResponse<CourseDto>(await _biz.GetById(id));
        }

        [HttpPost]
        public async Task<Response<CourseDto>> Edit(CourseDto course)
        {
            return new SuccessResponse<CourseDto>(await _biz.Edit(course));
        }

        [HttpGet]
        public async Task<Response<CourseDto>> Delete(int id)
        {
            return new SuccessResponse<CourseDto>(await _biz.Delete(id));
        }
    }
}