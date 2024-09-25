using bezoni_shoes_store.Server.Common.Mapping;

namespace bezoni_shoes_store.Server
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            // Add Mapping
            services.AddMappings();

            return services;
        }
    }
}
