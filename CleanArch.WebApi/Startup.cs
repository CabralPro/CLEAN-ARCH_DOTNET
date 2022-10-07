using CleanArch.Infra.IoC;
using CleanArch.Infra.IoC.StartupExtensions;
using CleanArch.WebApi.StartupExtensions;

namespace CleanArch.WebApi
{
    public partial class Startup
    {
        public void Configureservices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwagger();
            services.AddAutoMapperConfig();
            services.AddInfraDataDependencies();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseRouting();
            app.UseEndpoints(config => config.MapControllers());
        }

    }
}
