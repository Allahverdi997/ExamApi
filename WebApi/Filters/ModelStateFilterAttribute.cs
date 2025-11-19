using Application.Abstraction.AppConfig;
using Application.Abstraction.Service.Core;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using WebApi.Others;

namespace WebApi.Filters
{
    public class ModelStateFilterAttribute : ResultFilterAttribute
    {
        private readonly IExceptionNotificationService _exceptionNotificationService;
        private readonly IAppSetting AppSettings;
        private readonly IFilterService FilterService;

        public ModelStateFilterAttribute(IExceptionNotificationService exceptionNotificationService,
            IFilterService filterService,
            IAppSetting appSettings)
        {
            _exceptionNotificationService = exceptionNotificationService;
            AppSettings = appSettings;
            FilterService = filterService;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var modelState = context.ModelState;

            if (!modelState.IsValid)
            {
                var messageCodes = new List<string>();
                var errorMessages = new List<string>();

                foreach (var field in modelState)
                {
                    string messageTamplate = _exceptionNotificationService.GetDescription(field.Value.Errors.First().ErrorMessage).Result;

                    if (messageTamplate != null)
                        messageCodes.Add(messageTamplate);
                    else
                        messageCodes.Add(field.Key);

                    var key = field.Key;
                    Type type = key.GetType();

                    if (field.Key != null)
                    {
                        errorMessages.Add(messageTamplate + field.Key);
                        messageCodes.Add(field.Key);
                    }
                    else
                        errorMessages.Add(string.Format(messageTamplate));
                }

                object content = new { Data = default(Nullable), Error = new { Content = new { Key = messageCodes, Description = string.Join(", ", errorMessages) }, ExceptionMessage = modelState }, Success = false };
                context.Result = ResponseCreator.CreateHttpResponseMessage(HttpStatusCode.BadRequest, content);
            }
        }
    }
}
