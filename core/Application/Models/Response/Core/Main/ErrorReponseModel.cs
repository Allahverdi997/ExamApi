using Application.Models.Data.Core;
using Application.Models.Response.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Response.Core.Main
{
    public class ErrorReponseModel<T> : BaseResponseModel<T> where T : class
    {
        public ErrorReponseModel(List<Error> errors) : base(default, errors, false)
        {
            Data = default;
            Errors = errors;
            Success = false;
        }
    }
}
