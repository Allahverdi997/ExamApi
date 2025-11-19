namespace Application.Exceptions.Main
{
    [Serializable]
    public class GeneralException : BaseException
    {
        public GeneralException(string key, string message) : base(503, key, message)
        {
            Code = 503;
            Key = key;
            Message = message;
        }

        public GeneralException(string message) : base(503, message)
        {
            Code = 503;
            Message = message;
        }

        protected GeneralException(string message, Exception exception)
            : base(503, message, exception)
        {
            Exception = exception;
            Code = 503;
            Message = message;
        }
    }
}
