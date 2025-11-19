using Domain.Concrete.Core.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.EF.DBContext;

namespace Persistance.EF.Configurations
{
    public sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles", "Auth")
                 .HasData(SeedData.GetSampleRoles());
        }
    }
}
