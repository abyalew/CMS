﻿using CMS.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Business.Contracts
{
    public interface ICourseBiz
    {
        Task<List<CourseViewDto>> GetPage();
        Task<CourseViewDto> GetById(int courseId);
        Task<CourseViewDto> Edit(CourseDto course);
        Task<CourseViewDto> Delete(int courseId);
    }
}