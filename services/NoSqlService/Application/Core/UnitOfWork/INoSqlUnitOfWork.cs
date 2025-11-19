using NoSqlService.Application.Core.Repository.Main.ErrorLog;
using NoSqlService.Application.Core.Repository.Main.NotificationLog;
using NoSqlService.Application.Core.Repository.Main.WarningLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSqlService.Application.Core.UnitOfWork
{
    public interface INoSqlUnitOfWork
    {

        IErrorLogReadRepository ErrorLogReadRepository { get; }
        IErrorLogWriteRepository ErrorLogWriteRepository { get; }
        INotificationLogReadRepository NotificationLogReadRepository { get; }
        INotificationLogWriteRepository NotificationLogWriteRepository { get; }
        IWarningLogReadRepository WarningLogReadRepository { get; }
        IWarningLogWriteRepository WarningLogWriteRepository { get; }
    }
}
