using CMS.Business.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Business.Contracts
{
    public interface IAdmissionBiz
    {
        Task<List<AdmissionReadDto>> GetAll();
        Task<AdmissionReadDto> GetById(int admissionId);
        Task<AdmissionDto> Edit(AdmissionEditorDto student);
        Task<AdmissionReadDto> EditGrade(AdmissionReadDto admission);
    }
}
