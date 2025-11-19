namespace Application.Exceptions.Main
{
    [Serializable]
    public class AuthenticationException : BaseException
    {
        public AuthenticationException(string key, string message) : base(401, key, message)
        {
            Code = 401;
            Key = key;
            Message = message;
        }

        public AuthenticationException(string message) : base(401, message)
        {
            Code = 401;
            Message = message;
        }

        protected AuthenticationException(string message, Exception exception)
            : base(401, message, exception)
        {
            Exception = exception;
            Code = 401;
            Message = message;
        }
    }
}
