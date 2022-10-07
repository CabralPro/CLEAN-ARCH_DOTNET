using CleanArch.Infra.IoC.StartupExtensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraDataDependencies(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbConfigs(configuration);
            services.AddBindInterfaces();

            return services;
        }
    }
}
