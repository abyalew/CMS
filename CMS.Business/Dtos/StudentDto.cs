using System.Collections.Generic;

namespace CMS.Business.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
        public List<AddmitionDto> Addmitions { get; set; }
    }
}
