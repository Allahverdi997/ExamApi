using Application.Abstraction.Repository;
using Application.Abstraction.Repository.Core;
using Domain.Concrete.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Repository.Read.Core
{
    public interface IExceptionNotificationReadRepository : ISqlGenericReadRepository<ExceptionNotification>
    {
    }
}
