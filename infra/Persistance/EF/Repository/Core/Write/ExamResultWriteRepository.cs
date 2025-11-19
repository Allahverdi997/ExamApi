using Application.Abstraction.Context;
using Application.Abstraction.Core.Repository.Write.Core;
using Domain.Concrete.Core.Exam;

namespace Persistance.EF.Repository.Core.Write
{
    public class ExamResultWriteRepository : SqlGenericWriteRepository<ExamResult>, IExamResultWriteRepository
    {
        public ExamResultWriteRepository(ISqlDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
