using Application.Abstraction.Context;
using Application.Abstraction.Repository.Read.Core;
using Domain.Concrete.Core.Exam;

namespace Persistance.EF.Repository.Core.Read
{
    public class StudentReadRepository : SqlGenericReadRepository<Student>, IStudentReadRepository
    {
        public StudentReadRepository(ISqlDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
