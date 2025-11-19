using Application.ThirdPartyConfiguration.Concrete;
using Domain.Concrete.Core.Auth;
using Domain.Concrete.Core.Exam;

namespace Application.Models.Response.Core.Exam
{
    public class LessonResponse : MapFrom<Lesson>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
