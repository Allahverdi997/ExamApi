using Domain.Concrete.Core.Exam;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.EF.DBContext;

namespace Persistance.EF.Configurations
{
    public sealed class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.ToTable("Lessons", "Exam");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Code)
                .IsRequired()
                .HasColumnType("char(3)");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("nvarchar(30)");

            // Relations
            builder.HasMany(x => x.LessonInfos)
                .WithOne(x => x.Lesson)
                .HasForeignKey(x => x.LessonId);

            builder.HasMany(x => x.ExamResults)
                .WithOne(x => x.Lesson)
                .HasForeignKey(x => x.LessonId);
        }
    }

}
