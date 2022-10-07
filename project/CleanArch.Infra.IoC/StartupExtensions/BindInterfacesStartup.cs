
using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
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
            
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
