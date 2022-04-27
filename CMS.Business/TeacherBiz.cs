using CMS.Business.Contracts;
using CMS.Business.Dtos;
using CMS.DataModel;
using CMS.DataModel.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Business
{
    public class TeacherBiz : ITeacherBiz
    {
        private readonly IRepository<Teacher> _repo;
        private readonly IAutoMap _autoMap;

        public TeacherBiz(IRepository<Teacher> repo,IAutoMap autoMap)
        {
            _repo = repo;
            _autoMap = autoMap;
        }

        public async Task<List<TeacherDto>> GetAll()
        {
            return _autoMap.MapTo<List<TeacherDto>>(await _repo.GetAllAsync());
        }

        public async Task<TeacherDto> GetById(int techerId)
        {
            return _autoMap.MapTo<TeacherDto>(await _repo.FirstAsync(t=>t.Id == techerId));
        }

        public async Task<TeacherDto> Edit(TeacherDto teacher)
        {
            var entity = _autoMap.MapTo<Teacher>(teacher);
            if (entity.Id == 0)
                return _autoMap.MapTo<TeacherDto>(await _repo.Add(entity));
            else
                return _autoMap.MapTo<TeacherDto>(await _repo.Update(entity));
        }

        public async Task<TeacherDto> Delete(int teacherId)
        {
            var teacher = await _repo.FirstAsync(t => t.Id == teacherId);
            return _autoMap.MapTo<TeacherDto>(await _repo.Delete(teacher));
        }
    }
}