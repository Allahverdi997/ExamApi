using NoSqlService.Domain.Abstract;
using NoSqlService.Domain.Entities.Base;
using NoSqlService.Domain.Entities.Main;
using NoSqlService.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSqlServiceDomain.Factory
{
    public static class NoSqlEntityFactory
    {
        public static BaseNoSqlEntity Get(this NoSqlEntityEnum @enum)
        {
            switch (@enum)
            {
                case NoSqlEntityEnum.ErrorLog:
                    return new ErrorLogs();
                    break;
                case NoSqlEntityEnum.NotificationLog:
                    return new NotificationLogs();
                    break;
                case NoSqlEntityEnum.WarningLog:
                    return new WarningLogs();
                    break;
                default:
                    return null;
                    break;
            }
        }
    }
}
