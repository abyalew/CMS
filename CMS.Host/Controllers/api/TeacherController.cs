using CMS.Business.Contracts;
using CMS.Business.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace CMS.Host.Controllers.Api
{
    public class TeacherController : ApiController
    {
        private readonly ITeacherBiz _biz;

        public TeacherController(ITeacherBiz biz)
        {
            _biz = biz;
        }
        [HttpGet]
        public async Task<Response<List<TeacherDto>>> GetAll()
        {
            return new SuccessResponse<List<TeacherDto>>(await _biz.GetAll());
        }

        [HttpGet]
        public async Task<Response<TeacherDto>> GetById(int id)
        {
            return new SuccessResponse<TeacherDto>(await _biz.GetById(id));
        }

        [HttpPost]
        public async Task<Response<TeacherDto>> Edit(TeacherDto teacher)
        {
            return new SuccessResponse<TeacherDto>(await _biz.Edit(teacher));
        }

        [HttpGet]
        public async Task<Response<TeacherDto>> Delete(int id)
        {
            return new SuccessResponse<TeacherDto>(await _biz.Delete(id));
        }
    }
}