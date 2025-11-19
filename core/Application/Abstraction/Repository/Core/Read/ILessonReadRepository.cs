using Application.Abstraction.Repository.Core;
using Domain.Concrete.Core.Exam;

namespace Application.Abstraction.Repository.Read.Core
{
    public interface ILessonReadRepository : ISqlGenericReadRepository<Lesson>
    {
    }
}
