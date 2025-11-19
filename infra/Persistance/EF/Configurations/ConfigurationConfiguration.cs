using Domain.Concrete.Core.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.EF.DBContext;

namespace Persistance.EF.Configurations
{
    public sealed class ConfigurationConfiguration : IEntityTypeConfiguration<Configuration>
    {
        public void Configure(EntityTypeBuilder<Configuration> builder)
        {
            builder.ToTable("Configuration", "Application")
                .HasData(SeedData.GetConfigurations());
        }
    }
}
