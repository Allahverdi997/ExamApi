using Application.Abstraction.AppConfig;
using Application.Abstraction.Service.Core;
using Application.Exceptions;
using Application.Models.Data.Core;
using Application.Models.Response.Core.Main;
using Application.Static.Message;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;
using System.Net.Mail;

namespace WebApi.Others
{
    public class ExceptionHandler : IExceptionHandler
    {
        private readonly IExceptionNotificationService _exceptionNotificationService;

        public ExceptionHandler(IExceptionNotificationService exceptionNotificationService)
        {
            _exceptionNotificationService = exceptionNotificationService;
        }

        public async Task<IActionResult> HandleException(Exception ex)
        {
            string key = String.Empty;
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            var code = 0;
            string message = string.Empty;
            Content content;

            if (ex.GetType().IsSubclassOf(typeof(BaseException)))
            {
                var exception = (BaseException)ex;
                httpStatusCode = (HttpStatusCode)exception.Code;

                key = exception.Key;
                code = exception.Code;
                message = exception.Message;

                if (!string.IsNullOrWhiteSpace(key))
                    content = _exceptionNotificationService.GetByKey(key).Result;
                else
                    content = new Content(exception.Message);

                return ResponseCreator.CreateHttpResponseMessage((HttpStatusCode)httpStatusCode,
                                 new ErrorReponseModel<Exception>(new List<Error> { 
                                     new Error(content, ex.Message) }));
            }
            else
                return ResponseCreator.CreateHttpResponseMessage((HttpStatusCode)httpStatusCode,
                                 new ErrorReponseModel<Exception>(new List<Error> { 
                                     new Error(new Content(ex.Message), ex.Message) }));
        }
    }
}
