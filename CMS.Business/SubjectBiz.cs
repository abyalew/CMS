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
    public class SubjectBiz : ISubjectBiz
    {
        private readonly IRepository<Subject> _repo;
        private readonly IAutoMap _objectMap;

        public SubjectBiz(IRepository<Subject> repo, IAutoMap objectMap)
        {
            _repo = repo;
            _objectMap = objectMap;
        }

        public async Task<List<SubjectDto>> GetAll()
        {
            var subjects = await _repo.GetAllAsync(s => s.Teacher, s => s.CourseSubjects.Select(cs=>cs.Course.Admissions));
           return  subjects.Select(s =>
            {
                var dto = _objectMap.MapTo<SubjectDto>(s);
                dto.NumberOfStudents = s.CourseSubjects.Sum(cs => cs.Course.Admissions.Count);
                return dto;
            }).ToList();
        }

        public async Task<SubjectDto> GetById(int subjectId)
        {
            var subject = await _repo.FirstAsync(s => s.Id == subjectId);
            return _objectMap.MapTo<SubjectDto>(subject);
        }

        public async Task<SubjectDto> Edit(SubjectDto subject)
        {
            if (string.IsNullOrEmpty(subject.Name))
                throw new Exception("Name is required.");

            if (subject.Name.Length > 100)
                throw new Exception("Name must be less than 100 characters");
            if (subject.Id == 0)
                return await Create(subject);
            else
                return await Update(subject);
        }

        public async Task<SubjectDto> Delete(int subjectId)
        {
            return _objectMap.MapTo<SubjectDto>(await _repo.Delete(await _repo.FirstAsync(s => s.Id == subjectId)));
        }

        private async Task<SubjectDto> Create(SubjectDto subject)
        {
            return _objectMap.MapTo<SubjectDto>(await _repo.Add(_objectMap.MapTo<Subject>(subject)));
        }

        private async Task<SubjectDto> Update(SubjectDto subject)
        {
            return _objectMap.MapTo<SubjectDto>(await _repo.Update(_objectMap.MapTo<Subject>(subject)));
        }

    }
}
