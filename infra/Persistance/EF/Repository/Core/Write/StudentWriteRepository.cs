using Application.Abstraction.Context;
using Application.Abstraction.Core.Repository.Write.Core;
using Domain.Concrete.Core.Exam;

namespace Persistance.EF.Repository.Core.Write
{
    public class StudentWriteRepository : SqlGenericWriteRepository<Student>, IStudentWriteRepository
    {
        public StudentWriteRepository(ISqlDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
