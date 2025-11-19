using Application.Abstraction.Context;
using Application.Abstraction.Core.Repository.Write.Core;
using Domain.Concrete.Core.Exam;

namespace Persistance.EF.Repository.Core.Write
{
    public class LessonWriteRepository : SqlGenericWriteRepository<Lesson>, ILessonWriteRepository
    {
        public LessonWriteRepository(ISqlDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
