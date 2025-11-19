using NoSqlService.Application.Core.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoSqlService.Domain.Entities.Main;

namespace NoSqlService.Application.Core.Repository.Main.ErrorLog
{
    public interface IErrorLogWriteRepository:INoSqlWriteRepository<ErrorLogs>
    {
    }
}
