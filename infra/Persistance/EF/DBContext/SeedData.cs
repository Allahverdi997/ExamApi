using Application.Static.Message;
using Bogus;
using Domain.Concrete.Base.Entites;
using Domain.Concrete.Core;
using Domain.Concrete.Core.Application;
using Domain.Concrete.Core.Auth;
using Domain.Concrete.Core.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EF.DBContext
{
    public static class SeedData
    {

        public static List<ExceptionNotification> GetSampleExceptionNotifications()
        {
            return new List<ExceptionNotification>
        {
            new ExceptionNotification
            {
                Id = 1,
                Active = true,
                Key = "AuthorizedException",
                Description = "İstifadəçi identifikasiyası uğursuz oldu və ya token etibarsızdır."
            },
            new ExceptionNotification
            {
                Id = 2,
                Active = true,
                Key = "BadRequestException",
                Description = "Göndərilən məlumatlarda sintaksis və ya məntiqi xəta var."
            },
            new ExceptionNotification
            {
                Id = 3,
                Active = true,
                Key = "GeneralException",
                Description = "Gözlənilməyən ümumi bir xəta baş verdi."
            },
            new ExceptionNotification
            {
                Id = 4,
                Active = true,
                Key = "ModelStateException",
                Description = "Modelin validasiyası uğursuz oldu (ModelState invalid)."
            },
            new ExceptionNotification
            {
                Id = 5,
                Active = true,
                Key = "NotFoundException",
                Description = "İstənilən resurs tapılmadı."
            },
            new ExceptionNotification
            {
                Id = 6,
                Active = true,
                Key = "PermissionException",
                Description = "İstifadəçinin bu əməliyyatı yerinə yetirməyə icazəsi yoxdur."
            },
            new ExceptionNotification
            {
                Id = 7,
                Active = true,
                Key = "ServerException",
                Description = "Server daxilində gözlənilməyən bir xəta baş verdi."
            },
            new ExceptionNotification
            {
                Id = 8,
                Active = true,
                Key = "SqlServerException",
                Description = "Məlumat bazası ilə əlaqə və ya sorğu icrası zamanı xəta baş verdi."
            }
        };
        }
        public static List<User> GetSampleUsers()
        {
            return new List<User>
    {
        new User
        {
            Id = 1,
            Active = true,
            UserName = "admin",
            Password = "17UZgL7MirVuqQ0BOVpDCLm/IAD1C5J9+9r1HsdzVas=",
            ExpiredDate = new DateTime(2026, 7, 18),
            UserId = 1,
            Description = "Sistem administratoru"
        },
        new User
        {
            Id = 2,
            Active = true,
            UserName = "user",
            Password = "hRfgvPCqzw6pzRryrHzXVeECUaF+AHbvDj6UL7vCfsE=",
            ExpiredDate = new DateTime(2026, 7, 18),
            UserId = 2,
            Description = "Istifadəçi"
        }
    };
        }

        public static List<Role> GetSampleRoles()
        {
            return new List<Role>
    {
        new Role
        {
            Id = 1,
            Active = true,
            Name = "Admin".ToUpper(),
            Description = "Sistemin tam idarəetmə hüququ olan istifadəçi"
        },
        new Role
        {
            Id = 2,
            Active = true,
            Name = "User".ToUpper(),
            Description = "Istifadəçi Rolu"
        }
    };
        }

        public static List<UserRole> GetSampleUserRoles()
        {
            return new List<UserRole>()
            {
                new UserRole()
                {
                     Id = 1,
                     Active = true,
                     ExpiredDate = new DateTime(2026, 7, 18),
                     UserId = 1,
                     RoleId=1
                },
                new UserRole()
                {
                     Id = 2,
                     Active = true,
                     ExpiredDate = new DateTime(2026, 7, 18),
                     UserId = 2,
                     RoleId=2
                }
            };
        }
        public static List<Configuration> GetConfigurations()
        {
            return new List<Configuration>
    {
        new Configuration
        {
            Id = 1,
            Active = true,
            JWTKey="Exam.Api29051997",
            AzureConnectionString="AzureConnectionString",
            AzureStorageUrl="AzureStorageUrl",
            AzureFileContainer="files"
        }
            };
        }

        public static List<Teacher> GenerateTeachers(int count = 5)
        {
            var teacherFaker = new Faker<Teacher>("az")
                .RuleFor(t => t.Name, f => f.Name.FirstName())
                .RuleFor(t => t.Surname, f => f.Name.LastName());

            return teacherFaker.Generate(count);
        }

        public static List<Lesson> GenerateLessons()
        {
            var lessons = new List<Lesson>
        {
            new Lesson { Code = "MAT", Name = "Riyaziyyat" },
            new Lesson {Code = "FIZ", Name = "Fizika" },
            new Lesson { Code = "KIM", Name = "Kimya" }
        };

            return lessons;
        }

        public static List<Student> GenerateStudents(int count = 20)
        {
            var studentFaker = new Faker<Student>("az")
                .RuleFor(s => s.Number, f => f.Random.Number(10000, 99999))
                .RuleFor(s => s.Name, f => f.Name.FirstName())
                .RuleFor(s => s.Surname, f => f.Name.LastName())
                .RuleFor(s => s.Class, f => f.Random.Number(5, 11));

            return studentFaker.Generate(count);
        }

        public static List<LessonInfo> GenerateLessonInfos(List<Lesson> lessons, List<Teacher> teachers)
        {
            var faker = new Faker<LessonInfo>()
                .RuleFor(li => li.LessonId, f => f.PickRandom(lessons).Id)
                .RuleFor(li => li.TeacherId, f => f.PickRandom(teachers).Id)
                .RuleFor(li => li.Class, f => f.Random.Number(5, 11));

            return faker.Generate(lessons.Count);
        }

        public static List<ExamResult> GenerateExamResults(List<Student> students, List<Lesson> lessons)
        {
            var faker = new Faker<ExamResult>()
                .RuleFor(er => er.StudentId, f => f.PickRandom(students).Id)
                .RuleFor(er => er.LessonId, f => f.PickRandom(lessons).Id)
                .RuleFor(er => er.ExamDate, f => f.Date.Past(1))
                .RuleFor(er => er.ExamValue, f => f.Random.Number(2, 5));

            return faker.Generate(30);
        }
    }
}
