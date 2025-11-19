using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.Main
{
    [Serializable]
    public class AuthorizationException : BaseException
    {
        public AuthorizationException(string key, string message) : base(403, key, message)
        {
            Code = 403;
            Key = key;
            Message = message;
        }

        public AuthorizationException(string message) : base(403, message)
        {
            Code = 403;
            Message = message;
        }

        protected AuthorizationException(string message, Exception exception)
            : base(403, message, exception)
        {
            Exception = exception;
            Code = 403;
            Message = message;
        }
    }
}