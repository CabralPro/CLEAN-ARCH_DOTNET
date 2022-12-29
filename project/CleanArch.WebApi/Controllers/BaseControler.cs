using CleanArch.Domain.DomainObjects;
using CleanArch.WebApi.Controllers.ResponseTypes;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Text.Json;

namespace CleanArch.WebApi.Controllers
{
    [ApiController]
    [Route("api")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ErrorResponseType), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponseType), StatusCodes.Status500InternalServerError)]
    public abstract class BaseController : ControllerBase
    {
        protected readonly ILogger Logger;

        public BaseController(ILogger logger)
        {
            Logger = logger;
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
            response.StatusCode = statusCode;
            return response;
        }

        [NonAction]
        public ContentResult ContentResponse<T>(T obj, int httpStatusCode = StatusCodes.Status200OK)
        {
            var response = Content(JsonSerializer.Serialize(obj));
            response.StatusCode = httpStatusCode;
            return response;
        }

        [NonAction]
        public ContentResult CreatedResponse<T>(T obj) =>
            ContentResponse(obj, StatusCodes.Status201Created);

        [NonAction]
        public ContentResult UpdatedResponse<T>(T obj) =>
            ContentResponse(obj, StatusCodes.Status200OK);

        [NonAction]
        public void ValidatePagination(int page, int size, int maxPageSize = 10)
        {
            if (page <= 0)
                throw new DomainException("Parametro 'page' é inválido");
            if (size <= 0)
                throw new DomainException("Parametro 'size' é inválido");
            if (size > maxPageSize)
                throw new DomainException($"O parametro 'size' não pode ser maior que {maxPageSize}");
        }

    }
}
