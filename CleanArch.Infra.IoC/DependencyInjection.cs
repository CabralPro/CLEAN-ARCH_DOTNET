using CleanArch.Infra.IoC.StartupExtensions;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraDataDependencies(this IServiceCollection services)
        {
            services.AddDbConfigs();
            services.AddBindInterfaces();

            return services;
        }
    }
}
