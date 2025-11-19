namespace Application.Exceptions.Main
{
    [Serializable]
    public class NotFoundException : BaseException
    {
        public NotFoundException(string key, string message) : base(404, key, message)
        {
            Code = 404;
            Key = key;
            Message = message;
        }

        public NotFoundException(string message) : base(404, message)
        {
            Code = 404;
            Message = message;
        }

        public NotFoundException(string message, Exception exception)
            : base(404, message, exception)
        {
            Exception = exception;
            Code = 404;
            Message = message;
        }
    }
}
