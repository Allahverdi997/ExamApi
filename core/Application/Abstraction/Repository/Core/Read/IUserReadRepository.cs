using Application.Abstraction.Repository;
using Application.Abstraction.Repository.Core;
using Domain.Concrete.Core.Auth;

namespace Application.Abstraction.Repository.Read.Core
{
    public interface IUserReadRepository : ISqlGenericReadRepository<User>
    {
    }
}
