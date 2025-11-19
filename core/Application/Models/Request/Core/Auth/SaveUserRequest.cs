using Application.Abstraction.Models;
using Application.ThirdPartyConfiguration.Concrete;
using Domain.Concrete.Core.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request.Core.Auth
{
    public class SaveUserRequest:MapTo<User>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Description { get; set; }
    }
}
