using Application.Abstraction.Context;
using Application.Abstraction.Repository.Read;
using Application.Abstraction.Repository.Read.Core;
using Domain.Concrete.Core.Auth;
using Persistance.EF.Repository.Core;

namespace Persistance.EF.Repository.Core.Read
{
    public class UserReadRepository : SqlGenericReadRepository<User>, IUserReadRepository
    {
        public UserReadRepository(ISqlDbContext appDbContext) : base(appDbContext)
        {
        }
    }


}
