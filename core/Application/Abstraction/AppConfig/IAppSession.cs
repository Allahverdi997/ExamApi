using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.AppConfig
{
    public interface IAppSession
    {
        public string SecretKey { get; set; }
        public string Token { get; set; }
    }
}
