namespace Application.Exceptions.Main
{
    [Serializable]
    public class SqlServerException : BaseException
    {
        public SqlServerException(string key, string message) 
            : base(500, key, message)
        {
            Code = 500;
            Key = key;
            Message = message;
        }

        public SqlServerException(string message) : base(500, message)
        {
            Code = 500;
            Message = message;
        }

        protected SqlServerException(string message, Exception exception)
            : base(500, message, exception)
        {
            Exception = exception;
            Code = 501;
            Message = message;
        }
    }
}
