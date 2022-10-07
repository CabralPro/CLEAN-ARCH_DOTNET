using Microsoft.OpenApi.Models;

namespace CleanArch.WebApi.StartupExtensions
{
    public static class SwaggerStartup
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Clean Architecture Project",
                    Description = "An ASP.NET Core Web API for show Clean Architecture",
                    Contact = new OpenApiContact
                    {
                        Name = "Arthur Cabral Lemos",
                        Url = new Uri("https://cabral-tec.web.app/")
                    },
                }));
        }
    }
}
