using Application.Abstraction.Service.Core.Auth;
using Application.Attributes;
using Application.Exceptions.Main;
using Application.Models.Request.Core.Auth;
using Application.Models.Response.Core;
using Application.Static.Message;
using Domain.Concrete.Core.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistance.EF.DBContext;
using WebApi.Attributes;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [Anonym]
        [HttpPost("login")]
        public async Task<BaseResponseModel<string>> Login(LoginRequest request)
        {
            return await _userService.LoginAsync(request);
        }

        [HttpGet("roles")]
        [RoleSecure("admin")]
        public async Task<BaseResponseModel<List<Role>>> GetRoles()
        {
            return await _userService.GetRolesAsync();
        }
    }
}
