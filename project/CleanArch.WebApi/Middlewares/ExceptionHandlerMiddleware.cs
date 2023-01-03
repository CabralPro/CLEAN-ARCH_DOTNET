
using CleanArch.Domain.DomainObjects;
using CleanArch.WebApi.Controllers.ResponseTypes;
using System.Net.Mime;
using System.Text.Json;

namespace CleanArch.WebApi.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next,
            ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.ContentType = MediaTypeNames.Application.Json;

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Message: {ex.Message}; InnerExeption : {ex.InnerException}, StackTrace: {ex.StackTrace}");
                await HandleResponse(context, ex);
            }
        }

        public Task HandleResponse(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = ex is DomainException ?
                StatusCodes.Status400BadRequest :
                StatusCodes.Status500InternalServerError;

            var canReturnErrorMsg = ex is DomainException 
                || ex.InnerException?.Source == "FluentValidation"
                || ex.Source == "Microsoft.EntityFrameworkCore.Relational";

            var responseObj = new ErrorResponseType
            {
                Error = canReturnErrorMsg ?
                    (ex.InnerException?.Message ?? ex.Message) :
                    "Internal error"
            };
            var resultContent = JsonSerializer.Serialize(responseObj);

            return context.Response.WriteAsync(resultContent);
        }

    }
}
