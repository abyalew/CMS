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
    public class AdmissionBiz : IAdmissionBiz
    {
        private readonly IRepository<Admission> _AdmissionRepo;
        private readonly IRepository<Student> _studentRepo;
        private readonly IAutoMap _autoMap;

        public AdmissionBiz(
            IRepository<Admission> AdmissionRepo,
            IRepository<Student> studentRepo,
            IAutoMap autoMap)
        {
            _AdmissionRepo = AdmissionRepo;
            _studentRepo = studentRepo;
            _autoMap = autoMap;
        }

        public async Task<List<AdmissionReadDto>> GetAll()
        {
            var addmissions = await _AdmissionRepo.GetAllAsync(a => a.Student, a => a.Course.CourseSubjects.Select(cs => cs.Subject), a => a.StudentGrades.Select(sg => sg.Subject));

            var result = addmissions.Select(a =>
            {
                var x = _autoMap.MapTo<AdmissionReadDto>(a);

                foreach (var cs in a.Course.CourseSubjects)
                {
                    if (!x.StudentGrades.Any(sg => sg.SubjectId == cs.SubjectId))
                        x.StudentGrades.Add(new StudentGradeDto
                        {
                            SubjectId = cs.SubjectId,
                            Subject = _autoMap.MapTo<SubjectDto>(cs.Subject)
                        });
                }
                return x;
            }).ToList();


            
            
            return result;
        }

        public async Task<AdmissionDto> Edit(AdmissionEditorDto student)
        {
            if (student.Id == 0)
                return await Create(student);
            else
                return await Update(student);
        }

        private async Task<AdmissionDto> Create(AdmissionEditorDto admission)
        {
            var student = new Student
            {
                Name = admission.StudentName,
                Birthday = DateTime.Now
            };

            student.Admissions.Add(new Admission
            {
                CourseId = admission.CourseId
            });
            var addedStudent = await _studentRepo.Add(student);
            return _autoMap.MapTo<AdmissionDto>(addedStudent.Admissions.First());
        }


        private async Task<AdmissionDto> Update(AdmissionEditorDto Admission)
        {
            var old = await _AdmissionRepo.FirstAsync(a => a.Id == Admission.Id);
            old.Grade = Admission.Grade;
            return _autoMap.MapTo<AdmissionDto>(await _AdmissionRepo.Update(old));
        }
    }
}
