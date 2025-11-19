using NoSqlService.Application.Core.Repository.Base;
using NoSqlService.Domain.Entities.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSqlService.Application.Core.Repository.Main.WarningLog
{
    public interface IWarningLogReadRepository : INoSqlReadRepository<WarningLogs>
    {
    }
}
