using Application.Abstraction.Context;
using Application.Abstraction.Core.Repository.Write;
using Domain.Concrete.Core.Auth;
using Application.Abstraction.Core.Repository.Write.Core;

namespace Persistance.EF.Repository.Core.Write
{
    public class RoleWriteRepository : SqlGenericWriteRepository<Role>, IRoleWriteRepository
    {
        public RoleWriteRepository(ISqlDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
