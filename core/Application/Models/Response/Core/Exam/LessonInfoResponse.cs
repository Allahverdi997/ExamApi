using Application.ThirdPartyConfiguration.Concrete;
using Domain.Concrete.Core.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Response.Core.Exam
{
    public class LessonInfoResponse : MapFrom<LessonInfo>
    {
        public int Id { get; set; }
        public LessonResponse Lesson { get; set; }
        public int Class { get; set; }
        public TeacherResponse Teacher { get; set; }
    }
}
