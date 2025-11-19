using System.Net;

namespace Application.Exceptions.Main
{
    [Serializable]
    public class ModelStateException : BaseException
    {
        public ModelStateException(string key, string message) 
            : base(422, key, message)
        {
            Code = 422;
            Key = key;
            Message = message;
        }

        public ModelStateException(string message) : base(422, message)
        {
            Code = 422;
            Message = message;
        }

        protected ModelStateException(string message, Exception exception)
            : base(422, message, exception)
        {
            Exception = exception;
            Code = 422;
            Message = message;
        }
    }
}
