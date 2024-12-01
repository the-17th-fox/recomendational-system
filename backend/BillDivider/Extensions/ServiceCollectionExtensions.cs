using BillDivider.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BillDivider.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration) 
        {
            AddInfrastructureCollection(services, configuration);
            return services;
        }

        private static IServiceCollection AddInfrastructureCollection(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            services.AddDbContext<BillDividerContext>(context => context.UseSqlServer(connectionString));

            return services;
        }
    }
}
