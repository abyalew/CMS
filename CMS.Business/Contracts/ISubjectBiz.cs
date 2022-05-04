using CMS.Business.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Business.Contracts
{
    public interface ISubjectBiz
    {
        Task<List<SubjectDto>> GetAll();
        Task<SubjectDto> GetById(int id);
        Task<SubjectDto> Edit(SubjectDto subject);
        Task<SubjectDto> Delete(int subjectId);
    }
}
