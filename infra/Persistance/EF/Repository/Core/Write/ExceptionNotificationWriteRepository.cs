using Application.Abstraction.Context;
using Application.Abstraction.Core.Repository.Write;
using Domain.Concrete.Core.Application;
using Application.Abstraction.Core.Repository.Write.Core;

namespace Persistance.EF.Repository.Core.Write
{
    public class ExceptionNotificationWriteRepository : SqlGenericWriteRepository<ExceptionNotification>, IExceptionNotificationWriteRepository
    {
        public ExceptionNotificationWriteRepository(ISqlDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
