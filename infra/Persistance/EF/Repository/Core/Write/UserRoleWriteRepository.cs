using Application.Abstraction.Context;
using Application.Abstraction.Core.Repository.Write;
using Domain.Concrete.Core.Auth;
using Persistance.EF.Repository.Core;
using Application.Abstraction.Core.Repository.Write.Core;

namespace Persistance.EF.Repository.Core.Write
{
    public class UserRoleWriteRepository : SqlGenericWriteRepository<UserRole>, IUserRoleWriteRepository
    {
        public UserRoleWriteRepository(ISqlDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
