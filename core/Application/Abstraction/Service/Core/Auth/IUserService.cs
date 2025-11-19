using Application.Models.Request.Core.Auth;
using Application.Models.Response.Core;
using Application.Models.Response.Core.Auth;
using Domain.Concrete.Core.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Service.Core.Auth
{
    public interface IUserService
    {
        Task<BaseResponseModel<List<UserRoleResponse>>> GetUserRolesAsync(int userId);

        Task<BaseResponseModel<string>> LoginAsync(LoginRequest request);

        Task<BaseResponseModel<List<UserRoleResponse>>> SetRolesAsync(int userId, List<int> roles);

        Task<BaseResponseModel<List<Role>>> GetRolesAsync();
    }
}
