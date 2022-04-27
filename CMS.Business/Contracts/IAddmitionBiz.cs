using CMS.Business.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Business.Contracts
{
    public interface IAddmitionBiz
    {
        Task<List<AddmitionDto>> GetAll();
        Task<AddmitionDto> Edit(AddmitionEditorDto student);
    }
}
