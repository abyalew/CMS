using CMS.Business.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Business.Contracts
{
    public interface IAdmissionBiz
    {
        Task<List<AdmissionReadDto>> GetAll();
        Task<AdmissionDto> Edit(AdmissionEditorDto student);
    }
}
