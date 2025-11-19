using NoSqlService.Application.Core.Repository.Main.NotificationLog;
using NoSqlService.Domain.Entities.Main;
using NoSqlService.Persistance.DbContext;
using NoSqlService.Persistance.Mongo.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSqlServicePersistance.Mongo.Repository.Main.NotificationRepo
{
    public class NotificationLogWriteRepository : NoSqlGenericWriteRepository<NotificationLogs>, INotificationLogWriteRepository
    {
        public NotificationLogWriteRepository(MongoDbContext context) : base(context)
        {

        }
    }
}
