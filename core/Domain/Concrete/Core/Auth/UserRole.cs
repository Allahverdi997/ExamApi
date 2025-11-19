using Domain.Concrete.Base.Entites;

namespace Domain.Concrete.Core.Auth
{
    public class UserRole : BaseAuditableEntity, IEquatable<UserRole>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public DateTime ExpiredDate { get; set; }

        public User User { get; set; }
        public Role Role { get; set; }

        public bool Equals(UserRole? other)
        {
            if(Id==other.Id)
                return true;

            return false;
        }
    }
}
