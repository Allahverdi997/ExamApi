using Application.Abstraction.Repository.Core;
using Domain.Concrete.Core.Auth;

namespace Application.Abstraction.Repository.Read.Core
{
    public interface IRoleReadRepository 
        : ISqlGenericReadRepository<Role>
    {
    }
}
