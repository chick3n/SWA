using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SWA.Application.Common.Interfaces;
using SWA.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWA.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            return services;
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration,
            ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)),
                     serviceLifetime,
                     serviceLifetime);

            if (serviceLifetime == ServiceLifetime.Transient)
            {
                services.AddTransient<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            }
            else
            {
                services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            }

            return services;
        }
    }
}
