using Application.Abstraction.Core.Repository.Write;
using Application.Abstraction.Repository;
using Application.Abstraction.Repository.Read;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HashingService.DependencyResolvers;
using JWTService.DependencyResolvers;
using Application.Abstraction;
using Application.Concrete;
using Application.Abstraction.Context;
using Persistance.EF.DBContext;
using Persistance.EF.Repository.Core;
using Persistance.EF.Repository.Core.Write;
using Persistance.EF.Repository.Core.Read;
using Application.Abstraction.Repository.Core;
using Application.Abstraction.Repository.Read.Core;
using Application.Abstraction.Core.Repository.Write.Core;

namespace Persistance
{
    public static class DependencyResolver
    {
        public static void RegisterServicesFromPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(ISqlGenericReadRepository<>), typeof(SqlGenericReadRepository<>));
            services.AddScoped(typeof(ISqlGenericWriteRepository<>), typeof(SqlGenericWriteRepository<>));

            services.AddScoped<ISqlDbContext,ApplicationDbContext>();

            services.AddScoped<IUnitOfWork,UnitOfWork>();

            services.HashingConfiguration(configuration);
            services.JWTConfiguration(configuration);

            #region Read
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserRoleReadRepository, UserRoleReadRepository>();
            
            services.AddScoped<IRoleReadRepository, RoleReadRepository>();
            services.AddScoped<IExceptionNotificationReadRepository, ExceptionNotificationReadRepository>();
            services.AddScoped<IConfigurationReadRepository, ConfigurationReadRepository>();

            services.AddScoped<IExamResultReadRepository, ExamResultReadRepository>();
            services.AddScoped<ILessonReadRepository, LessonReadRepository>();
            services.AddScoped<ILessonInfoReadRepository, LessonInfoReadRepository>();
            services.AddScoped<IStudentReadRepository, StudentReadRepository>();
            services.AddScoped<ITeacherReadRepository, TeacherReadRepository>();
            #endregion

            #region Write
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            services.AddScoped<IUserRoleWriteRepository, UserRoleWriteRepository>();
            
            services.AddScoped<IRoleWriteRepository, RoleWriteRepository>();
            services.AddScoped<IExceptionNotificationWriteRepository, ExceptionNotificationWriteRepository>();
            services.AddScoped<IConfigurationWriteRepository, ConfigurationWriteRepository>();

            services.AddScoped<IExamResultWriteRepository, ExamResultWriteRepository>();
            services.AddScoped<ILessonWriteRepository, LessonWriteRepository>();
            services.AddScoped<ILessonInfoWriteRepository, LessonInfoWriteRepository>();
            services.AddScoped<IStudentWriteRepository, StudentWriteRepository>();
            services.AddScoped<ITeacherWriteRepository, TeacherWriteRepository>();
            #endregion
        }
    }
}
