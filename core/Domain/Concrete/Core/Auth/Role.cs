using Domain.Concrete.Base.Entites;

namespace Domain.Concrete.Core.Auth
{
    public class Role:BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }


        public ICollection<UserRole> UserRoles { get; set; }
    }
}
