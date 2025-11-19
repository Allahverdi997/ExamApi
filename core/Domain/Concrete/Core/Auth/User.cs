using Domain.Abstract.Marker;
using Domain.Concrete.Base.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete.Core.Auth
{
    public class User:BaseAuditableEntity,IAggregateRoot
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public int UserId { get; set; }
        public string? Description { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiration { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
