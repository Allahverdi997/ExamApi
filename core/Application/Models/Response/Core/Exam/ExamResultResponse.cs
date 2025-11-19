using Application.ThirdPartyConfiguration.Concrete;
using Domain.Concrete.Core.Exam;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Response.Core.Exam
{
    public class ExamResultResponse:MapFrom<ExamResult>
    {
        public int Id { get; set; }
        public LessonResponse Lesson { get; set; }
        public StudentResponse  Student { get; set; }
        public DateTime ExamDate { get; set; }
        public decimal ExamValue { get; set; }
    }
}
