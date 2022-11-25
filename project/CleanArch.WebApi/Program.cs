
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace CleanArch.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(builder =>
                    builder.UseStartup<Startup>()
                    .ConfigureKestrel(opt => 
                        opt.ConfigureEndpointDefaults(config =>
                            config.Protocols = HttpProtocols.Http1)))
                .Build()
                .Run();
        }
    }
}
