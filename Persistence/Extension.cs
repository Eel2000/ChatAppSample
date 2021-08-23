using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using System;
using Persistence.Services;

namespace Persistence
{
    public static class Extension
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LiteMessagingContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("db"),
                    b => b.MigrationsAssembly(typeof(LiteMessagingContext).Assembly.FullName));
                options.EnableDetailedErrors(true);
                options.LogTo(Console.WriteLine);
            });


            #region ServiceRegistration
            services.AddTransient<IUserService, UserService>();
            #endregion
        }
    }
}
