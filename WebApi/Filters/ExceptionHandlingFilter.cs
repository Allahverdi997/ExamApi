using Application.Abstraction.AppConfig;
using Application.Abstraction.Service.Core;
using Application.Exceptions;
using Application.Models.Data;
using Application.Static.Message;
using Microsoft.AspNetCore.Mvc.Filters;
using NoSqlService.Application.Core.UnitOfWork;
using System.Net;
using WebApi.Others;
using Data = Application.Models.Data;

namespace WebApi.Filters
{
    public class ExceptionHandlingFilter : IExceptionFilter
    {
        private readonly IExceptionNotificationService ExceptionNotificationService;
        private readonly IAppSetting AppSettings;
        private readonly IFilterService FilterService;

        private readonly IExceptionHandler _exceptionHandler;

        private readonly INoSqlUnitOfWork _noSqlUnitOfWork;

        public ExceptionHandlingFilter(IExceptionNotificationService exceptionNotificationService,
            IFilterService filterService,
            IAppSetting appSettings,
            IExceptionHandler exceptionHandler,
            INoSqlUnitOfWork noSqlUnitOfWork)
        {
            ExceptionNotificationService = exceptionNotificationService;
            AppSettings = appSettings;
            FilterService = filterService;
            _exceptionHandler = exceptionHandler;
            _noSqlUnitOfWork = noSqlUnitOfWork;
        }

        public void OnException(ExceptionContext context)
        {
            context.Result= _exceptionHandler.HandleException(context.Exception).Result;

            _noSqlUnitOfWork.ErrorLogWriteRepository.Add(new NoSqlService.Domain.Entities.Main.ErrorLogs()
            {
                Class = "AuthenticationFilter",
                CreateDate = DateTime.Now,
                Data = context.Exception.Message
            });
        }
    }
}
