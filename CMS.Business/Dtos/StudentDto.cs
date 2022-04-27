using System;
using System.Collections.Generic;

namespace CMS.Business.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public List<AdmissionDto> Admissions { get; set; }
    }
}
