using Application.Abstraction.Context;
using Application.Abstraction.Core.Repository.Write.Core;
using Domain.Concrete.Core.Exam;

namespace Persistance.EF.Repository.Core.Write
{
    public class TeacherWriteRepository : SqlGenericWriteRepository<Teacher>, ITeacherWriteRepository
    {
        public TeacherWriteRepository(ISqlDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
