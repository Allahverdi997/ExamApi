using NoSqlService.Application.Core.Repository.Main.ErrorLog;
using NoSqlService.Domain.Entities.Main;
using NoSqlService.Persistance.DbContext;
using NoSqlService.Persistance.Mongo.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSqlServicePersistance.Mongo.Repository.Main.ErrorLogRepo
{
    public class ErrorLogWriteRepository : NoSqlGenericWriteRepository<ErrorLogs>, IErrorLogWriteRepository
    {
        public ErrorLogWriteRepository(MongoDbContext context) : base(context)
        {

        }
    }
}
