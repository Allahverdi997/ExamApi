using Domain.Concrete.Core.Exam;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.EF.DBContext;

namespace Persistance.EF.Configurations
{
    public sealed class ExamResultConfiguration : IEntityTypeConfiguration<ExamResult>
    {
        public void Configure(EntityTypeBuilder<ExamResult> builder)
        {
            builder.ToTable("ExamResults", "Exam");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ExamDate)
                .HasColumnType("date");

            builder.Property(x => x.ExamValue)
                .HasColumnType("NUMERIC(1,0)");

            // Relations
            builder.HasOne(x => x.Lesson)
                .WithMany(x => x.ExamResults)
                .HasForeignKey(x => x.LessonId);

            builder.HasOne(x => x.Student)
                .WithMany(x => x.ExamResults)
                .HasForeignKey(x => x.StudentId);
        }
    }

}
