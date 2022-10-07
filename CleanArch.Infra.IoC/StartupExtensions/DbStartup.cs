using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Infra.IoC.StartupExtensions
{
    public static class DbStartup
    {
        public static IServiceCollection AddDbConfigs(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(Environment.GetEnvironmentVariable("DB_CONN_STRING"),
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            return services;
        }
    }
}
