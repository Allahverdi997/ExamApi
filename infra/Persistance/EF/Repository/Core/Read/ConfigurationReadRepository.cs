using Application.Abstraction.Context;
using Application.Abstraction.Repository.Read;
using Application.Abstraction.Repository.Read.Core;
using Domain.Concrete.Core.Application;
using Persistance.EF.Repository.Core;

namespace Persistance.EF.Repository.Core.Read
{
    public class ConfigurationReadRepository : SqlGenericReadRepository<Configuration>, IConfigurationReadRepository
    {
        public ConfigurationReadRepository(ISqlDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
