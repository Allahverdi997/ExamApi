using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    [Serializable]
    public abstract class BaseException:Exception
    {
        public int Code { get; set; }
        public string Key { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }


        protected BaseException(int code,string message, Exception exception) : base(message)
        {
            Exception = exception;
            Code=code;
            Message = message;
        }

        protected BaseException(int code, string message) : base(message)
        {
            Message = message;
            Code = code;
        }

        protected BaseException(int code,string key, string message) : base(message)
        {
            Code= code;
            Key = key;
            Message=message;
        }
    }
}
