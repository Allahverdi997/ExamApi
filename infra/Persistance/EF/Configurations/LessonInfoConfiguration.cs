using Domain.Concrete.Core.Exam;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.EF.DBContext;

namespace Persistance.EF.Configurations
{
    public sealed class LessonInfoConfiguration : IEntityTypeConfiguration<LessonInfo>
    {
        public void Configure(EntityTypeBuilder<LessonInfo> builder)
        {
            builder.ToTable("LessonInfos", "Exam");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Class)
                .IsRequired()
                .HasColumnType("NUMERIC(2,0)");

            builder.Property(x => x.TeacherId)
                .IsRequired();

            // Relations
            builder.HasOne(x => x.Lesson)
                .WithMany(x => x.LessonInfos)
                .HasForeignKey(x => x.LessonId);

            builder.HasOne(x => x.Teacher)
                .WithMany(x => x.LessonInfos)
                .HasForeignKey(x => x.TeacherId);
        }
    }

}
