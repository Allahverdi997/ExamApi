using Application.Abstraction.Repository.Core;
using Domain.Concrete.Core.Exam;

namespace Application.Abstraction.Repository.Read.Core
{
    public interface IStudentReadRepository : ISqlGenericReadRepository<Student>
    {
    }
}
