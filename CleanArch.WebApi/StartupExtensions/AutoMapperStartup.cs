using CleanArch.Application.Mappings;

namespace CleanArch.WebApi.StartupExtensions
{
    public static class AutoMapperStartup
    {
        public static void AddAutoMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
