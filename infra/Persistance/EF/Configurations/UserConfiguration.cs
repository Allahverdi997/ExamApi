using Domain.Concrete.Core.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.EF.DBContext;

namespace Persistance.EF.Configurations
{
    public sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "Auth")
                .HasData(SeedData.GetSampleUsers());
        }
    }
}
