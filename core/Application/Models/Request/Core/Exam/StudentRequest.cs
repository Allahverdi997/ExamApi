using Application.Abstraction.Models;
using Application.ThirdPartyConfiguration.Concrete;
using Domain.Concrete.Core.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request.Core.Exam
{
    public class StudentRequest:MapTo<Student>,IRequest
    {
        public int Id { get; set; }
        public decimal Number { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Class { get; set; }
    }
}
