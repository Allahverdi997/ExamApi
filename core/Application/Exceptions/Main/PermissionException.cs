namespace Application.Exceptions.Main
{
    [Serializable]
    public class PermissionException : BaseException
    {
        public PermissionException(string key, string message) : base(403, key, message)
        {
            Code = 403;
            Key = key;
            Message = message;
        }

        public PermissionException(string message) : base(403, message)
        {
            Code = 403;
            Message = message;
        }

        protected PermissionException(string message, Exception exception)
            : base(403, message, exception)
        {
            Exception = exception;
            Code = 403;
            Message = message;
        }
    }
}
