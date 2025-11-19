using Application.Abstraction.Context;
using Application.Abstraction.Repository.Read.Core;
using Domain.Concrete.Core.Exam;

namespace Persistance.EF.Repository.Core.Read
{
    public class TeacherReadRepository : SqlGenericReadRepository<Teacher>, ITeacherReadRepository
    {
        public TeacherReadRepository(ISqlDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
