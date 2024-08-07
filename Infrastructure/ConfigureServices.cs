using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddNoSQLInfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDatabaseSettings(configuration);
            services.AddRepositoryServices();

            return services;
        }

        private static void AddDatabaseSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<INoSQLDatabaseSettings>(
                new NoSQLDatabaseSettings(configuration["Connections:DB:NoSQL:DatabaseName"],
                configuration.GetConnectionString("NoSQL")));
        }

        private static void AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
