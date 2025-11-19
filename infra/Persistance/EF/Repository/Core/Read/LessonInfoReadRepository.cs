using Application.Abstraction.Context;
using Application.Abstraction.Repository.Read.Core;
using Domain.Concrete.Core.Exam;

namespace Persistance.EF.Repository.Core.Read
{
    public class LessonInfoReadRepository : SqlGenericReadRepository<LessonInfo>, ILessonInfoReadRepository
    {
        public LessonInfoReadRepository(ISqlDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
