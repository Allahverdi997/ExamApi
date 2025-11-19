using Application.Abstraction.Context;
using Application.Abstraction.Repository.Read.Core;
using Domain.Concrete.Core.Exam;

namespace Persistance.EF.Repository.Core.Read
{
    public class LessonReadRepository : SqlGenericReadRepository<Lesson>, ILessonReadRepository
    {
        public LessonReadRepository(ISqlDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
