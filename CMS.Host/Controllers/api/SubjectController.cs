using CMS.Business.Contracts;
using CMS.Business.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace CMS.Host.Controllers.Api
{
    public class SubjectController : ApiController
    {
        private readonly ISubjectBiz _biz;

        public SubjectController(ISubjectBiz biz)
        {
            _biz = biz;
        }
        [HttpGet]
        public async Task<Response<List<SubjectDto>>> GetAll()
        {
            return new SuccessResponse<List<SubjectDto>>(await _biz.GetAll());
        }

        [HttpGet]
        public async Task<Response<SubjectDto>> GetById(int id)
        {
            return new SuccessResponse<SubjectDto>(await _biz.GetById(id));
        }

        [HttpPost]
        public async Task<Response<SubjectDto>> Edit(SubjectDto subject)
        {
            return new SuccessResponse<SubjectDto>(await _biz.Edit(subject));
        }

        [HttpGet]
        public async Task<Response<SubjectDto>> Delete(int id)
        {
            return new SuccessResponse<SubjectDto>(await _biz.Delete(id));
        }
    }
}