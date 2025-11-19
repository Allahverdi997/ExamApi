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
    public class LessonInfoRequest : MapTo<LessonInfo>, IRequest
    {
        public int Id { get; set; }
        public LessonRequest Lesson { get; set; }
        public TeacherRequest Teacher { get; set; }
        public int Class { get; set; }
    }

    public class LessonRequest : MapTo<Lesson>,IRequest
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class TeacherRequest : MapTo<Teacher>,IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
