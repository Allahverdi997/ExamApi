using Application.Abstraction.Models;
using Application.ThirdPartyConfiguration.Abstract;
using Application.ThirdPartyConfiguration.Concrete;
using Domain.Concrete.Core.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request.Core.Exam
{
    public class ExamResultRequest : MapTo<ExamResult>,IRequest
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public int StudentId { get; set; }
        public DateTime ExamDate { get; set; }
        public decimal ExamValue { get; set; }
    }
}
