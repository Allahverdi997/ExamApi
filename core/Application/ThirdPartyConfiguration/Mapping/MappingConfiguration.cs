using Application.ThirdPartyConfiguration.Abstract;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.ThirdPartyConfiguration.Mapping
{
    public static class MappingConfiguration
    {
        public static void MappingConfigure(this IServiceCollection services, IConfiguration configuration)
        {
            var assm = Assembly.GetExecutingAssembly();

            var profiles = assm.GetTypes().Where(t => typeof(Profile).IsAssignableFrom(t)).ToList();

            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

            var mappingConfig = new MapperConfiguration(a => a.AddMaps(assm), loggerFactory);
            
            IMapper mapper = mappingConfig.CreateMapper();
            
            services.AddSingleton(mapper);
        }
    }
}
