using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.Main
{
    [Serializable]
    public class BadRequestException : BaseException
    {
        public BadRequestException(string key,string message) : base(400,key, message)
        {
            Code = 400;
            Key = key;
            Message = message;
        }

        public BadRequestException(string message) : base(400, message)
        {
            Code = 400;
            Message = message;
        }

        protected BadRequestException(string message, Exception exception) 
            : base(400,message,exception)
        {
            Exception = exception;
            Code = 400;
            Message = message;
        }
    }
}
