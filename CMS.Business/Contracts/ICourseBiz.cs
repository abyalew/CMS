using CMS.Business.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Business.Contracts
{
    public interface ICourseBiz
    {
        Task<List<CourseViewDto>> GetAll();
        Task<CourseViewDto> GetById(int courseId);
        Task<CourseViewDto> Edit(CourseDto course);
        Task<CourseViewDto> Delete(int courseId);
    }
}
