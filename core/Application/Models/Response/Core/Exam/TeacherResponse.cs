using Application.ThirdPartyConfiguration.Concrete;
using Domain.Concrete.Core.Exam;

namespace Application.Models.Response.Core.Exam
{
    public class TeacherResponse : MapFrom<Teacher>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
