using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi.Others
{
    public class ResponseCreator
    {
        public static IActionResult CreateHttpResponseMessage(HttpStatusCode httpStatusCode, object content)
        {
            var response = new ObjectResult(content);
            response.StatusCode = (int)httpStatusCode;

            return response;
        }
    }
}
