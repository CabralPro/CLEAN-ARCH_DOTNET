using CleanArch.WebApi.Middlewares;

namespace CleanArch.WebApi.StartupExtensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
