using Application.Abstraction.Core.Repository.Write;
using Application.Abstraction.Repository;
using Application.Abstraction.Repository.Read;
using Application.Abstraction.Service.Core.Auth;
using Application.Abstraction.Service.Core.Exam;
using HashingService.Abstract;
using Infrastructure.Services.Core.Auth;
using Infrastructure.Services.Core.Exam;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.EF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyResolver
    {
        public static void RegisterServicesFromInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService,UserService>();

            services.AddScoped<ILessonService, LessonService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IExamResultService, ExamResultService>();
            
        }

    }
}
