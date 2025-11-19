using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.AppConfig
{
    public interface IExceptionHandler
    {
        Task<IActionResult> HandleException(Exception exception);
    }
}
