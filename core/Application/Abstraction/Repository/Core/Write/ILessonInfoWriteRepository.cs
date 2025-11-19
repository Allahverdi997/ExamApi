using Application.Abstraction.Repository.Core;
using Domain.Concrete.Core.Exam;

namespace Application.Abstraction.Core.Repository.Write.Core
{
    public interface ILessonInfoWriteRepository : ISqlGenericWriteRepository<LessonInfo>
    {
    }
}
