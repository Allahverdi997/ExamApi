using Application.Abstraction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request.Core.Auth
{
    public class LoginRequest : IRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
    }
}
