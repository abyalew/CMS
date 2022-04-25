using CMS.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Business.Contracts
{
    public interface ICourseBusiness
    {
        Task<List<CourseViewDto>> GetPage();
    }
}
