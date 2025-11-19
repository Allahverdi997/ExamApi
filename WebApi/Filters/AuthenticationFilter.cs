using Application.Abstraction.AppConfig;
using Application.Abstraction.Service.Core;
using Application.Attributes;
using Application.Exceptions;
using Application.Models.Data;
using Application.Static.Message;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using NoSqlService.Application.Core.UnitOfWork;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using WebApi.Attributes;
using WebApi.Others;

namespace WebApi.Filters
{
    public class AuthenticationFilter : IAuthorizationFilter
    {
        private readonly IFilterService _filterService;
        private readonly IExceptionHandler _exceptionHandler;
        private readonly INoSqlUnitOfWork _noSqlUnitOfWork;

        public AuthenticationFilter(IFilterService filterService,
                                    IExceptionHandler exceptionHandler,
                                    INoSqlUnitOfWork noSqlUnitOfWork)
        {
            _filterService = filterService;
            _exceptionHandler = exceptionHandler;
            _noSqlUnitOfWork = noSqlUnitOfWork;
        }

        void IAuthorizationFilter.OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                HttpRequest request = context.HttpContext.Request;
                var lang = request.Headers["Language"];

                var roles = "";

                if (context.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
                {
                    var isDefined = controllerActionDescriptor.MethodInfo.GetCustomAttributes(inherit: true)
                        .Any(a => a.GetType().Equals(typeof(AnonymAttribute)));

                    if (isDefined)
                        return;

                    var roleAttribute = controllerActionDescriptor.MethodInfo.GetCustomAttribute(typeof(RoleSecureAttribute)) as RoleSecureAttribute;

                    if (roleAttribute != null)
                        roles = roleAttribute.Name;
                }

                var authorization = request.Headers["AuthenticationToken"];

                _filterService.AuthenticateUser(authorization.ToString(), roles);
            }
            catch (Exception ex)
            {
               context.Result= _exceptionHandler.HandleException(ex).Result;
                _noSqlUnitOfWork.ErrorLogWriteRepository.Add(new NoSqlService.Domain.Entities.Main.ErrorLogs()
                {
                    Class = "AuthenticationFilter",
                    CreateDate = DateTime.Now,
                    Data = ex.Message
                });
            }

        }
    }
}
