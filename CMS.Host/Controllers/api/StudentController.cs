using CMS.Business.Contracts;
using CMS.Business.Dtos;
using CMS.DataModel;
using CMS.DataModel.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace CMS.Host.Controllers.Api
{
    public class StudentController : ApiController
    {
        private readonly IAdmissionBiz _biz;

        public StudentController(IAdmissionBiz biz)
        {
            _biz = biz;
        }

        [HttpGet]
        public async Task<Response<List<AdmissionReadDto>>> GetAll()
        {
            return new SuccessResponse<List<AdmissionReadDto>>(await _biz.GetAll());
        }

        [HttpGet]
        public async Task<Response<AdmissionReadDto>> GetById(int id)
        {
            var admission = await _biz.GetById(id);
            return new SuccessResponse<AdmissionReadDto>(admission);
        }

        [HttpPost]
        public async Task<Response<AdmissionReadDto>> Edit(AdmissionEditorDto admission)
        {
            var result = await _biz.Edit(admission);

            return new SuccessResponse<AdmissionReadDto>(new AdmissionReadDto
            {
                Id = result.Id,
                StudentId = result.StudentId,
                CourseId = result.CourseId,
                Grade = result.Grade,
                StudentName = result.Student.Name,
                Course = result.Course
            });
        }

        [HttpPost]
        public async Task<Response<bool>> EditGrade(AdmissionReadDto admission)
        {
            await _biz.EditGrade(admission);
            return new SuccessResponse<bool>(true);
        }
    }

    public class TeacherController: ApiController
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