using Market.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence
            (this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<MarketDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IMarketDbContext>(provider =>
            provider.GetService<MarketDbContext>());

            return services;
        }

    }
}
