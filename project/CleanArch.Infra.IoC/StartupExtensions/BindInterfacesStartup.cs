
using CleanArch.Application.ServiceBus;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Infra.IoC.StartupExtensions
{
    public static class BindInterfacesStartup
    {
        public static IServiceCollection AddBindInterfaces(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IServiceBus, ServiceBus>();

            return services;
        }
    }
}
