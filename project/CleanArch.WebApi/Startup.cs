using CleanArch.Infra.IoC;
using CleanArch.WebApi.StartupExtensions;

namespace CleanArch.WebApi
{
    public partial class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configureservices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwagger();
            services.AddAutoMapperConfig();
            services.AddInfraDataDependencies(Configuration);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseCustomExceptionHandler();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(config => config.MapControllers());
        }

    }
}
