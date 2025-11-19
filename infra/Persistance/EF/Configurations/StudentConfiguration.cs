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
    public sealed class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students", "Exam");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Number)
                .IsRequired()
                .HasColumnType("NUMERIC(5,0)");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("nvarchar(30)");

            builder.Property(x => x.Surname)
                .IsRequired()
                .HasColumnType("nvarchar(30)");

            builder.Property(x => x.Class)
                .HasColumnType("NUMERIC(2,0)");

            builder.HasMany(x => x.ExamResults)
                .WithOne(x => x.Student)
                .HasForeignKey(x => x.StudentId);
        }
    }

}
