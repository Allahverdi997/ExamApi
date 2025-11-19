using Application.Attributes;
using Application.ThirdPartyConfiguration.Concrete;
using Domain.Concrete.Core.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Response.Core.Auth
{
    public class UserRoleResponse:MapFrom<UserRole>
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        [PropertyMap("User.UserName")]
        public string Username { get; set; }

        
        public int RoleId { get; set; }
        [PropertyMap("Role.Name")]
        public string RoleName { get; set; }
        [PropertyMap("Role.Description")]
        public string Description { get; set; }
        public DateTime ExpireDate { get; set; }
    }

    public class UserResponse:MapFrom<User>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string? Description { get; set; }
        public DateTime? ExpiredDate { get; set; }
    }
}
