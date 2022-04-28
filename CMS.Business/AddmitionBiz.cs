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
        private readonly IAdmissionRepo _AdmissionRepo;
        private readonly IRepository<Student> _studentRepo;
        private readonly IAutoMap _autoMap;
        private readonly IRepository<Subject> _subjectRepo;

        public AdmissionBiz(
            IAdmissionRepo AdmissionRepo,
            IRepository<Student> studentRepo,
            IRepository<Subject> subjectRepo,
            IAutoMap autoMap)
        {
            _AdmissionRepo = AdmissionRepo;
            _studentRepo = studentRepo;
            _autoMap = autoMap;
            _subjectRepo = subjectRepo;
        }

        public async Task<List<AdmissionReadDto>> GetAll()
        {
            var addmissions = await _AdmissionRepo.GetAllAsync(a => a.Student, a => a.Course.CourseSubjects.Select(cs => cs.Subject), a => a.StudentGrades.Select(sg => sg.Subject));

            var result = addmissions.Select(a =>
            {
                return MapToAdmissionReadDto(a);
            }).ToList();
            return result;
        }

        public async Task<AdmissionReadDto> GetById(int admissionId)
        {
            var addmission = await _AdmissionRepo.FirstAsync(a => a.Id == admissionId,
                a => a.Student, a => a.Course.CourseSubjects.Select(cs => cs.Subject),
                a => a.StudentGrades.Select(sg => sg.Subject));
            return MapToAdmissionReadDto(addmission);
        }

        public async Task<AdmissionDto> Edit(AdmissionEditorDto student)
        {
            if (student.Id == 0)
                return await Create(student);
            else
                return await Update(student);
        }

        public async Task<AdmissionReadDto> EditGrade(AdmissionReadDto admission)
        {
            var entity = await _AdmissionRepo.FirstAsync(a => a.Id == admission.Id, a => a.StudentGrades);
            var subjects = await _subjectRepo.Find(s => s.CourseSubjects.Any(sc => sc.CourseId == entity.CourseId));

            decimal total = 0;
            admission.StudentGrades.ForEach(sg =>
            {
                if (sg.Id == 0)
                    entity.StudentGrades.Add(_autoMap.MapTo<StudentGrade>(sg));
                else
                    entity.StudentGrades.First(g => g.Id == sg.Id).Grade = sg.Grade ?? 0;
                var subject = subjects.First(s => s.Id == sg.SubjectId);
                if (sg.Grade.HasValue)
                    total += subject.CreditPoint * sg.Grade.Value;
            });

            entity.Grade = total / subjects.Sum(s => s.CreditPoint);
            return _autoMap.MapTo<AdmissionReadDto>(await _AdmissionRepo.Update(entity));
        }

        private AdmissionReadDto MapToAdmissionReadDto(Admission addmission)
        {
            var result = _autoMap.MapTo<AdmissionReadDto>(addmission);

            foreach (var cs in addmission.Course.CourseSubjects)
            {
                if (!result.StudentGrades.Any(sg => sg.SubjectId == cs.SubjectId))
                    result.StudentGrades.Add(new StudentGradeDto
                    {
                        SubjectId = cs.SubjectId,
                        Subject = _autoMap.MapTo<SubjectDto>(cs.Subject)
                    });
            }

            return result;
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