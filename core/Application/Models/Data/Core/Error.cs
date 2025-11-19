using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Data.Core
{
    public class Error
    {
        public Error(Content content, string exceptionMessage)
        {
            Content = content;
            ExceptionMessage = exceptionMessage;
        }

        public Content Content { get; set; }
        public string ExceptionMessage { get; set; }
    }
}
