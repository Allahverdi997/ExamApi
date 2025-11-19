using Domain.Concrete.Core.Exam;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.EF.DBContext;

namespace Persistance.EF.Configurations
{
    public sealed class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teachers", "Exam");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("nvarchar(20)");

            builder.Property(x => x.Surname)
                .IsRequired()
                .HasColumnType("nvarchar(20)");

            // Relations
            builder.HasMany(x => x.LessonInfos)
                .WithOne(x => x.Teacher)
                .HasForeignKey(x => x.TeacherId);
        }
    }

}
