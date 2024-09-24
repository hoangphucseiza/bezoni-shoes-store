﻿using Mapster;
using MapsterMapper;
using System.Reflection;

namespace bezoni_shoes_store.Server.Common.Mapping
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {

            var config = new TypeAdapterConfig();

            config.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();

            return services;
        }
    }
}
