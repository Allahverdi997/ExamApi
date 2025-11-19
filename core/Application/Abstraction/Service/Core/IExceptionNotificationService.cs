using Application.Models.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Service.Core
{
    public interface IExceptionNotificationService
    {
        Task<Content> GetByKey(string key);
        Task<string> GetDescription(string key);
    }
}
