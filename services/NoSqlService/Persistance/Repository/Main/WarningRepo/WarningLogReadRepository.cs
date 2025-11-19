using NoSqlService.Application.Core.Repository.Main.WarningLog;
using NoSqlService.Domain.Entities.Main;
using NoSqlService.Persistance.DbContext;
using NoSqlService.Persistance.Mongo.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSqlService.Persistance.Mongo.Repository.Main.WarningRepo
{
    public class WarningLogReadRepository : NoSqlGenericReadRepository<WarningLogs>, IWarningLogReadRepository
    {
        public WarningLogReadRepository(MongoDbContext context) : base(context)
        {

        }
    }
}
