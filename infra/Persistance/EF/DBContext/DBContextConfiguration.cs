using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EF.DBContext
{
    public static class DBContextConfiguration
    {
        public static void SetDbConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration
                    .GetConnectionString("DefaultSql"), 
                     b => b.MigrationsAssembly("Persistance"));
                options.EnableSensitiveDataLogging();
            });
        }
    }
}
