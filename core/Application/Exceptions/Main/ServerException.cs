namespace Application.Exceptions.Main
{
    [Serializable]
    public class ServerException : BaseException
    {
        public ServerException(string key, string message) : base(500, key, message)
        {
            Code = 500;
            Key = key;
            Message = message;
        }

        public ServerException(string message) : base(500, message)
        {
            Code = 500;
            Message = message;
        }

        protected ServerException(string message, Exception exception) 
            : base(500, message, exception)
        {
            Exception = exception;
            Code = 500;
            Message = message;
        }
    }
}
