using Application.Abstraction.Context;
using Application.Abstraction.Repository.Read.Core;
using Domain.Concrete.Core.Auth;
using Persistance.EF.Repository.Core;

namespace Persistance.EF.Repository.Core.Read
{
    public class RoleReadRepository : SqlGenericReadRepository<Role>, IRoleReadRepository
    {
        public RoleReadRepository(ISqlDbContext appDbContext) : base(appDbContext)
        {
        }
    }


}
