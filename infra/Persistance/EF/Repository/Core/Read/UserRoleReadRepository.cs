using Application.Abstraction.Context;
using Application.Abstraction.Repository.Read;
using Application.Abstraction.Repository.Read.Core;
using Domain.Concrete.Core.Auth;
using Persistance.EF.Repository.Core;

namespace Persistance.EF.Repository.Core.Read
{
    public class UserRoleReadRepository : SqlGenericReadRepository<UserRole>, IUserRoleReadRepository
    {
        public UserRoleReadRepository(ISqlDbContext appDbContext) : base(appDbContext)
        {
        }
    }


}
