using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Interfaces;
using Persistence.Repositories;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaggerDbContext>(options=>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
                    a => a.MigrationsAssembly(typeof(TaggerDbContext).Assembly.FullName)));

            services.AddScoped<ITaggerDbContext>(provider => provider.GetService<TaggerDbContext>());
            services.AddTransient<IAccountRepository, AccountRepository>();

            return services;
        }

        
    }
}
