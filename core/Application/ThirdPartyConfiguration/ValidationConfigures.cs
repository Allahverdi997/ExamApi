using Application.Abstraction.AppConfig;
using Application.Abstraction.Service;
using Application.Concrete.AppConfig;
using Application.Concrete.Service;
using Application.Validators.Auth;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ThirdPartyConfiguration
{
    public static class ValidationConfigures
    {
        public static void ValidationConfigure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
        }
    }
}
