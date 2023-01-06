using MediatR;

namespace CleanArch.WebApi.StartupExtensions
{
    public static class MediatRStartup
    {
        public static IServiceCollection AddMediatRConfig(this IServiceCollection services)
        {
            return services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
