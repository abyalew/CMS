using CMS.Business.Contracts;
using CMS.Business.Dtos;
using CMS.DataModel;
using CMS.DataModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Business
{
    public class CourseBusiness : ICourseBusiness
    {
        private readonly IRepository<Course> _repo;
        private readonly IAutoMap _objectMap;

        public CourseBusiness(IRepository<Course> repo, IAutoMap objectMap)
        {
            _repo = repo;
            _objectMap = objectMap;
        }

        public async Task<List<CourseViewDto>> GetPage()
        {
            var courses = await _repo.GetAllAsync(c => 
                                c.Addmitions.Select(a=>a.Student),
                                c=>c.CourseSubjects.SelectMany(sbj=> sbj.Subject.SubjectTeachers.Select(st=>st.Teacher)));
            courses.Select(c => {
                var totalGrade = c.Addmitions.Sum(a => a.Grade);
                var averageGrade = totalGrade == 0 ? 0 : totalGrade / c.Addmitions.Count;
                var teachers = c.CourseSubjects.SelectMany(sbj => sbj.Subject.SubjectTeachers.Select(st => st.Teacher)).Distinct();

                return new CourseViewDto
                {
                    Id = c.Id,
                    AwardTitle = c.AwardTitle,
                    AverageGrade = averageGrade,
                    NumberOfStudents = c.Addmitions.Count,
                    NumberOfTeachers = teachers.Count()
                };
            });
            return _objectMap.MapTo<List<CourseViewDto>> (await _repo.GetAllAsync());
        }

        public async Task<CourseViewDto> Create(CourseDto course)
        {
            if (string.IsNullOrEmpty(course.AwardTitle))
            {
                throw new Exception("Award Title Is Required.");
            }
            if (course.AwardTitle.Length > 100)
                throw new Exception("Award Title Lenght Mult Be Less Than 100.");
            //todo add validation for couse subjects

            var addedCourse = await _repo.Add(_objectMap.MapTo<Course>(course));


            return _objectMap.MapTo<CourseViewDto>(addedCourse);
        }


    }
}
