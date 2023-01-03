using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Infra.IoC.StartupExtensions
{
    public static class DbConfigStartup
    {
        public static IServiceCollection AddDbConfigs(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(
                    configuration["SqliteConnection:SqliteConnectionString"],
                    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
                )
                .UseLazyLoadingProxies()

            );

            return services;
        }
    }
}
