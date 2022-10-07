using CleanArch.Domain.DomainObjects;
using CleanArch.WebApi.Controllers.ResponseTypes;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CleanArch.WebApi.Controllers
{
    [ApiController]
    [Route("api")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ErrorResponseType), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponseType), StatusCodes.Status500InternalServerError)]
    public abstract class BaseController : ControllerBase
    {
        protected readonly ILogger Logger;

        public BaseController(ILogger logger)
        {
            this.Logger = logger;
        }

        [NonAction]
        public void ValidateRequest()
        {
            throw new NotImplementedException();
        }

        [NonAction]
        public ContentResult MsgResponse(string message, int statusCode)
        {
            var responseObj = new MessageResponseType()
            {
                Message = message
            };

            var response = Content(JsonSerializer.Serialize(responseObj));
            response.ContentType = "application/json";
            response.StatusCode = statusCode;

            return response;
        }

        [NonAction]
        public ContentResult ErrorResponse(Exception ex)
        {
            var responseObj = new ErrorResponseType
            {
                Error = ex.InnerException?.Message ?? ex.Message
                //error = ex is DomainException ? ex.Message : "Internal error"
            };

            var response = Content(JsonSerializer.Serialize(responseObj));
            response.ContentType = "application/json";
            response.StatusCode = ex is DomainException ?
                StatusCodes.Status400BadRequest :
                StatusCodes.Status500InternalServerError;

            return response;
        }

        [NonAction]
        public ContentResult ContentResponse<T>(T obj, int httpStatusCode = StatusCodes.Status200OK)
        {
            var response = Content(JsonSerializer.Serialize(obj));
            response.ContentType = "application/json";
            response.StatusCode = httpStatusCode;
            return response;
        }

        [NonAction]
        public ContentResult CreateResponse<T>(T obj)
        {
            var response = Content(JsonSerializer.Serialize(obj));
            response.ContentType = "application/json";
            response.StatusCode = StatusCodes.Status201Created;
            return response;
        }

    }
}
