using AspNetCore.Identity.MongoDbCore.Extensions;
using AspNetCore.Identity.MongoDbCore.Infrastructure;
using bezoni_shoes_store.Application.Common.Interfaces.Authentication;
using bezoni_shoes_store.Application.Common.Interfaces.Cache;
using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using bezoni_shoes_store.Application.Common.Interfaces.Services;
using bezoni_shoes_store.Domain.Entities;
using bezoni_shoes_store.Infrastucture.Authentication;
using bezoni_shoes_store.Infrastucture.Cache;
using bezoni_shoes_store.Infrastucture.MongoDB;
using bezoni_shoes_store.Infrastucture.Persistence;
using bezoni_shoes_store.Infrastucture.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace bezoni_shoes_store.Infrastucture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
           ConfigurationManager configuration)
        {
            services.AddAuth(configuration);

            // Add configuration MongoDB by section
            services.Configure<MongoDBSettings>(configuration.GetSection(MongoDBSettings.SectionName));


            // Add life time of services
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();

            // Add services cache
            //services.AddMemoryCache();
            services.AddScoped<ICacheService, CacheService>();


            return services;
        }
        public static IServiceCollection AddAuth(this IServiceCollection services,
           ConfigurationManager configuration)
        {
            var JwtSettings = new JwtSettings();
            var mongoDbSettings = new MongoDBSettings();  

            // Add configuration JWT by section
            configuration.Bind(JwtSettings.SectionName, JwtSettings);
            configuration.Bind(MongoDBSettings.SectionName, mongoDbSettings);

            services.AddSingleton(Options.Create(JwtSettings));
            services.AddSingleton(Options.Create(mongoDbSettings));

            services.AddSingleton<IJWTTokenGenerator, JWTTokenGenerator>();

            // Cấu hình MongoDBIdentity
                var mongoDbIdentityConfig = new MongoDbIdentityConfiguration
                {
                    MongoDbSettings = new MongoDbSettings
                    {
                        ConnectionString = mongoDbSettings.ConnectionString,
                        DatabaseName = mongoDbSettings.DatabaseName,
                    },
                    IdentityOptionsAction = options =>
                    {
                        options.Password.RequiredLength = 6;
                        options.Password.RequireLowercase = false;
                        options.Password.RequireUppercase = false;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequireDigit = false;
                        options.User.RequireUniqueEmail = true;
                    }
                };
                services.ConfigureMongoDbIdentity<User, Role, Guid>(mongoDbIdentityConfig)
                    .AddUserManager<UserManager<User>>()
                    .AddSignInManager<SignInManager<User>>()
                    .AddRoleManager<RoleManager<Role>>()
                    .AddDefaultTokenProviders();

                // Authentication
                services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = JwtSettings.Issuer,
                        ValidAudience = JwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.Secret))
                    });


         

            return services;
        }
    }
}
