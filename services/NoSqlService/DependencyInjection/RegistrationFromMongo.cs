using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoSqlService.Persistance.Mongo.Repository.Main.WarningRepo;
using NoSqlService.Application.Core.Repository.Main.ErrorLog;
using NoSqlService.Application.Core.Repository.Main.NotificationLog;
using NoSqlService.Application.Core.Repository.Main.WarningLog;
using NoSqlService.Application.Core.UnitOfWork;
using NoSqlService.Persistance.Mongo.Repository.Main.ErrorLogRepo;
using NoSqlServicePersistance.Mongo.Repository.Main.ErrorLogRepo;
using NoSqlService.Persistance.DbContext;
using NoSqlServicePersistance.UnitOfWork;
using NoSqlService.NoSqlService.Persistance.Mongo.Repository.Main.WarningRepo;
using NoSqlServicePersistance.Mongo.Repository.Main.NotificationRepo;
using NoSqlService.Persistance.Mongo.Repository.Main.NotificationRepo;

namespace NoSqlService.DependencyInjection
{
    public static class RegistrationFromMongo
    {
        public static void RegisterServicesFromNoSqlService(this IServiceCollection services,string connection,string database)
        {

            services.AddScoped<IErrorLogReadRepository>(x=>new ErrorLogReadRepository(new MongoDbContext(connection,database)));
            services.AddScoped<IErrorLogWriteRepository>(x => new ErrorLogWriteRepository(new Persistance.DbContext.MongoDbContext(connection, database)));

            services.AddScoped<INotificationLogReadRepository>(x => new NotificationLogReadRepository(new Persistance.DbContext.MongoDbContext(connection, database)));
            services.AddScoped<INotificationLogWriteRepository>(x => new NotificationLogWriteRepository(new Persistance.DbContext.MongoDbContext(connection, database)));

            services.AddScoped<IWarningLogReadRepository>(x => new WarningLogReadRepository(new Persistance.DbContext.MongoDbContext(connection, database)));
            services.AddScoped<IWarningLogWriteRepository>(x => new WarningLogWriteRepository(new Persistance.DbContext.MongoDbContext(connection, database)));

            services.AddScoped<INoSqlUnitOfWork>(x => new NoSqlUnitOfWork(connection, database));
        }
    }
}
