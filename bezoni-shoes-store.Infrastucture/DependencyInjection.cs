using bezoni_shoes_store.Application.Common.Interfaces.Authentication;
using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using bezoni_shoes_store.Application.Common.Interfaces.Services;
using bezoni_shoes_store.Infrastucture.Authentication;
using bezoni_shoes_store.Infrastucture.MongoDB;
using bezoni_shoes_store.Infrastucture.Persistence;
using bezoni_shoes_store.Infrastucture.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Infrastucture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
           ConfigurationManager configuration)
        {
            services.AddAuth(configuration);
            services.Configure<MongoDBSettings>(configuration.GetSection(MongoDBSettings.SectionName));
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
        public static IServiceCollection AddAuth(this IServiceCollection services,
           ConfigurationManager configuration)
        {
            var JwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, JwtSettings);

            services.AddSingleton(Options.Create(JwtSettings));
            services.AddSingleton<IJWTTokenGenerator, JWTTokenGenerator>();

            return services;
        }
    }
}
