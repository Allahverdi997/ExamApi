using Application.Abstraction.Context;
using Application.Abstraction.Core.Repository.Write.Core;
using Domain.Concrete.Core.Exam;

namespace Persistance.EF.Repository.Core.Write
{
    public class LessonInfoWriteRepository : SqlGenericWriteRepository<LessonInfo>, ILessonInfoWriteRepository
    {
        public LessonInfoWriteRepository(ISqlDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
