using Application.Abstraction.AppConfig;
using Application.Abstraction.Service.Core;
using Application.Concrete.AppConfig;
using Application.Concrete.Service;
using Application.ThirdPartyConfiguration;
using Application.ThirdPartyConfiguration.Mapping;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application
{

    public static class DependencyResolver
    {
        public static void RegisterServicesFromApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IAppSession, AppSession>();
            services.AddScoped<IAppSetting, AppSetting>();
            services.AddScoped<IFilterService, FilterService>();
            services.AddScoped<IMemoryCacheService, MemoryCacheService>();
            services.AddScoped<IExceptionNotificationService, ExceptionNotificationService>();
            //services.AddScoped<IFileCloudStorageService, FileCloudStorageService>();

            services.MappingConfigure(configuration);

            services.ValidationConfigure(configuration);

            //services.AddStackExchangeRedisCache(opt =>
            //{
            //    opt.Configuration = "localhost:5002";
            //    opt.InstanceName = "RedisDemo_";
            //    opt.ConfigurationOptions = new ConfigurationOptions()
            //    {
            //        KeepAlive = 0,
            //        AllowAdmin = true,
            //        EndPoints = { { "127.0.0.1", 6379 } },
            //        ConnectTimeout = 5000,
            //        ConnectRetry = 5,
            //        SyncTimeout = 5000,
            //        AbortOnConnectFail = false,
            //    };
            //});
        }
    }

}
