using CMS.Business.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Business.Contracts
{
    public interface ITeacherBiz
    {
        Task<List<TeacherDto>> GetAll();
        Task<TeacherDto> GetById(int techerId);
        Task<TeacherDto> Edit(TeacherDto teacher);
        Task<TeacherDto> Delete(int teacherId);
    }
}
