using Application.Abstraction.Context;
using Application.Abstraction.Core.Repository.Write;
using Application.Abstraction.Core.Repository.Write.Core;
using Application.Abstraction.Repository.Read.Core;
using Domain.Concrete.Core.Application;

namespace Persistance.EF.Repository.Core.Write
{
    public class ConfigurationWriteRepository : SqlGenericWriteRepository<Configuration>, IConfigurationWriteRepository
    {
        public ConfigurationWriteRepository(ISqlDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
