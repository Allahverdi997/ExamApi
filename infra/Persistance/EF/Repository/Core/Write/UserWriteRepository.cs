using Application.Abstraction.Context;
using Application.Abstraction.Core.Repository.Write;
using Domain.Concrete.Core.Auth;
using Persistance.EF.Repository.Core;
using Application.Abstraction.Repository.Read.Core;
using Application.Abstraction.Core.Repository.Write.Core;

namespace Persistance.EF.Repository.Core.Write
{
    public class UserWriteRepository : SqlGenericWriteRepository<User>, IUserWriteRepository
    {
        public UserWriteRepository(ISqlDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
