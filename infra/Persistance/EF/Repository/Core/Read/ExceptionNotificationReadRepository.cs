using Application.Abstraction.Context;
using Application.Abstraction.Repository.Read;
using Domain.Concrete.Core.Application;
using Application.Abstraction.Repository.Read.Core;

namespace Persistance.EF.Repository.Core.Read
{
    public class ExceptionNotificationReadRepository : SqlGenericReadRepository<ExceptionNotification>, IExceptionNotificationReadRepository
    {
        public ExceptionNotificationReadRepository(ISqlDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
