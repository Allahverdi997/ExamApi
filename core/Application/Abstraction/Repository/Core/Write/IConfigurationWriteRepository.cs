using Application.Abstraction.Repository;
using Application.Abstraction.Repository.Core;
using Domain.Concrete.Core.Application;

namespace Application.Abstraction.Core.Repository.Write.Core
{
    public interface IConfigurationWriteRepository 
        : ISqlGenericWriteRepository<Configuration>
    {
    }
}
