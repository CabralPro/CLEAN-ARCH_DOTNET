using CleanArch.Domain.DomainObjects;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace CleanArch.WebApi.Controllers
{
    [Route("api")]
    [ApiController]
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
        public ContentResult MsgResponse(HttpStatusCode statusCode, string message)
        {
            var responseObj = new
            {
                message
            };

            var response = Content(JsonSerializer.Serialize(responseObj));
            response.ContentType = "application/json";
            response.StatusCode = (int)statusCode;

            return response;
        }
        [NonAction]
        public ContentResult ErrorResponse(Exception ex)
        {
            var responseObj = new
            {
                error = ex.InnerException?.Message ?? ex.Message
                //error = ex is DomainException ? ex.Message : "Internal error"
            };

            var response = Content(JsonSerializer.Serialize(responseObj));
            response.ContentType = "application/json";
            response.StatusCode = ex is DomainException ?
                (int)HttpStatusCode.BadRequest :
                (int)HttpStatusCode.InternalServerError;

            return response;
        }

        [NonAction]
        public ContentResult CreatedResponse(string message = "Success")
        {
            var responseObj = new
            {
                message
            };

            var response = Content(JsonSerializer.Serialize(responseObj));
            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode.Created;

            return response;
        }

        [NonAction]
        public ContentResult OkResponse(string message = "Success")
        {
            var responseObj = new
            {
                message
            };

            var response = Content(JsonSerializer.Serialize(responseObj));
            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode.OK;

            return response;
        }

        [NonAction]
        public ContentResult ContentResponse(object obj, string message = "Success", HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            var responseObj = new
            {
                message,
                data = obj
            };

            var response = Content(JsonSerializer.Serialize(responseObj));
            response.ContentType = "application/json";
            response.StatusCode = (int)httpStatusCode;

            return response;
        }

    }
}
