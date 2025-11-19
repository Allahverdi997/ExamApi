using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EF.DBContext
{
    using Bogus;
    using Domain.Concrete.Core.Exam;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    public static class DbInitializer
    {
        public static void Seed(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (!context.Students.Any())
            {
                var students = SeedData.GenerateStudents();
                context.Students.AddRange(students);

                var lessons = SeedData.GenerateLessons();
                context.Lessons.AddRange(lessons);

                var teachers = SeedData.GenerateTeachers();
                context.Teachers.AddRange(teachers);

                context.SaveChanges();

                var examResults = SeedData.GenerateExamResults(students, lessons);
                context.ExamResults.AddRange(examResults);

                var lessonInfos = SeedData.GenerateLessonInfos(lessons,teachers);
                context.LessonInfos.AddRange(lessonInfos);

                context.SaveChanges();
            }
        }
    }

}
