using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Service.Core
{
    public interface IFilterService
    {
        void AuthenticateUser(string token,string roles="");
    }
}
