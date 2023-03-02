using Identity.Backend.Data;
using Identity.Backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Identity.Backend
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence
               (this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<AuthDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IAuthDbContext>(provider =>
            provider.GetService<AuthDbContext>());

            return services;
        }
    }
}
