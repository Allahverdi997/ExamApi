using Application.Abstraction.Repository;
using Application.Abstraction.Repository.Core;
using Domain.Concrete.Core.Application;

namespace Application.Abstraction.Repository.Read.Core
{
    public interface IConfigurationReadRepository : ISqlGenericReadRepository<Configuration>
    {
    }
}
