using Application.Abstraction.Context;
using Application.Abstraction.Repository.Read.Core;
using Domain.Concrete.Core.Exam;

namespace Persistance.EF.Repository.Core.Read
{
    public class ExamResultReadRepository : SqlGenericReadRepository<ExamResult>, IExamResultReadRepository
    {
        public ExamResultReadRepository(ISqlDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
