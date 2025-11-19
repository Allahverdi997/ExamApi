using Application.Abstraction.Repository;
using Application.Abstraction.Repository.Core;
using Domain.Concrete.Core.Auth;

namespace Application.Abstraction.Core.Repository.Write.Core
{
    public interface IRoleWriteRepository : ISqlGenericWriteRepository<Role>
    {
    }
}
