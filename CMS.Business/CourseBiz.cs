using CMS.Business.Contracts;
using CMS.Business.Dtos;
using CMS.DataModel;
using CMS.DataModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Business
{
    public class CourseBiz : ICourseBiz
    {
        private readonly ICourseRepo _repo;
        private readonly IAutoMap _objectMap;

        public CourseBiz(ICourseRepo repo, IAutoMap objectMap)
        {
            _repo = repo;
            _objectMap = objectMap;
        }

        public async Task<List<CourseViewDto>> GetAll()
        {
            var courses = await _repo.GetAllAsync(c =>
                                c.Admissions.Select(a => a.Student),
                                c => c.CourseSubjects.Select(sbj => sbj.Subject.Teacher));
            return courses.Select(c =>
            {
                var totalGrade = c.Admissions.Sum(a => a.Grade);
                var averageGrade = totalGrade == 0 ? 0 : totalGrade / c.Admissions.Count;
                var teachers = c.CourseSubjects.Select(sbj => sbj.Subject.Teacher).Distinct();

                return new CourseViewDto
                {
                    Id = c.Id,
                    AwardTitle = c.AwardTitle,
                    AverageGrade = averageGrade,
                    NumberOfStudents = c.Admissions.Count,
                    NumberOfTeachers = teachers.Count()
                };
            }).ToList();
        }

        public async Task<CourseViewDto> GetById(int courseId)
        {
            var course = await _repo.FirstAsync(c => c.Id == courseId, c => c.CourseSubjects.Select(cs => cs.Subject));
            var courseDto = _objectMap.MapTo<CourseViewDto>(course);
            foreach (var cs in course.CourseSubjects)
            {
                courseDto.Subjects.Add(_objectMap.MapTo<SubjectDto>(cs.Subject));
            }
            return courseDto;
        }


        public async Task<CourseViewDto> Edit(CourseDto course)
        {
            Validate(course);

            if (course.Id == 0)
                return await Create(course);
            else
                return await Update(course);
        }

        public async Task<CourseViewDto> Delete(int courseId)
        {
            return _objectMap.MapTo<CourseViewDto>(await _repo.Delete(courseId));
        }

        private async Task<CourseViewDto> Create(CourseDto course)
        {
            var newCourse = _objectMap.MapTo<Course>(course);

            course.Subjects.ForEach(s => newCourse.CourseSubjects.Add(new CourseSubject { SubjectId = s.Id }));
            var addedCourse = await _repo.Add(newCourse);


            return _objectMap.MapTo<CourseViewDto>(addedCourse);
        }

        private async Task<CourseViewDto> Update(CourseDto course)
        {
            var courseToUpdate = _objectMap.MapTo<Course>(course);
            course.Subjects.ForEach(s => courseToUpdate.CourseSubjects.Add(new CourseSubject { SubjectId = s.Id }));
            var updatedResult = await _repo.Update(courseToUpdate);

            return _objectMap.MapTo<CourseViewDto>(updatedResult);
        }

        private void Validate(CourseDto course)
        {
            if (string.IsNullOrEmpty(course.AwardTitle))
            {
                throw new Exception("Award Title Is Required.");
            }
            if (course.AwardTitle.Length > 100)
                throw new Exception("Award Title Lenght Mult Be Less Than 100.");
            if (!course.Subjects.Any())
                throw new Exception("atleast on subject is required.");
        }
    }
}
