using Application.Abstraction.Repository;
using Application.Abstraction.Repository.Core;
using Domain.Concrete.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Core.Repository.Write.Core
{
    public interface IExceptionNotificationWriteRepository : ISqlGenericWriteRepository<ExceptionNotification>
    {
    }
}
