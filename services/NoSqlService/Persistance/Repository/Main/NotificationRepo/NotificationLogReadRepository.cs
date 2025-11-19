using NoSqlService.Application.Core.Repository.Main.NotificationLog;
using NoSqlService.Domain.Entities.Main;
using NoSqlService.Persistance.DbContext;
using NoSqlService.Persistance.Mongo.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSqlService.Persistance.Mongo.Repository.Main.NotificationRepo
{
    public class NotificationLogReadRepository : NoSqlGenericReadRepository<NotificationLogs>, INotificationLogReadRepository
    {
        public NotificationLogReadRepository(MongoDbContext context) : base(context)
        {

        }
    }
}
