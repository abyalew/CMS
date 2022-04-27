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
    public class AddmitionBiz : IAddmitionBiz
    {
        private readonly IRepository<Addmition> _addmitionRepo;
        private readonly IRepository<Student> _studentRepo;
        private readonly IAutoMap _autoMap;

        public AddmitionBiz(IRepository<Addmition> addmitionRepo,IRepository<Student> studentRepo, IAutoMap autoMap)
        {
            _addmitionRepo = addmitionRepo;
            _studentRepo = studentRepo;
            _autoMap = autoMap;
        }

        public async Task<List<AddmitionDto>> GetAll()
        {
            return _autoMap.MapTo<List<AddmitionDto>>(await _addmitionRepo.GetAllAsync(a=>a.Student));
        }

        public async Task<AddmitionDto> Edit(AddmitionEditorDto student)
        {
            if (student.Id == 0)
                return await Create(student);
            else
                return await Update(student);
        }

        private async Task<AddmitionDto> Create(AddmitionEditorDto addmition)
        {
            var student = new Student
            {
                Name = addmition.StudentName,
                Addmitions = new List<Addmition> { _autoMap.MapTo<Addmition>(addmition) }
            };

            var addedStudent = await _studentRepo.Add(student);
            return _autoMap.MapTo<AddmitionDto>(addedStudent.Addmitions.First());
        }


        private async Task<AddmitionDto> Update(AddmitionEditorDto addmition)
        {
            var old = await _addmitionRepo.FirstAsync(a => a.Id == addmition.Id);
            old.Grade = addmition.Grade;
            return _autoMap.MapTo<AddmitionDto>(await _addmitionRepo.Update(old));
        }
    }
}
