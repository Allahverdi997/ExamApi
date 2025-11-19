using Domain.Concrete.Core.Application;
using Domain.Concrete.Core.Exam;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.EF.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EF.Configurations
{
    public sealed class ExceptionNotificationConfiguration : IEntityTypeConfiguration<ExceptionNotification>
    {
        public void Configure(EntityTypeBuilder<ExceptionNotification> builder)
        {
            builder.ToTable("ExceptionNotifications", "Application")
                .HasData(SeedData.GetSampleExceptionNotifications());
        }
    }
}
