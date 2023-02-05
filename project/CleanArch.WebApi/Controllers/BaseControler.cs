using AutoMapper;
using CleanArch.Application.ServiceBus;
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
    [ProducesResponseType(typeof(MessageResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(MessageResponse), StatusCodes.Status500InternalServerError)]
    public abstract class BaseController : ControllerBase
    {
        protected readonly ILogger Logger;
        protected readonly IMapper Mapper;
        protected readonly IServiceBus ServiceBus;

        protected BaseController(ILogger logger, IMapper mapper, IServiceBus serviceBus)
        {
            Logger = logger;
            Mapper = mapper;
            ServiceBus = serviceBus;
        }

        [NonAction]
        public void ValidateRequest()
        {
            throw new NotImplementedException();
        }

        [NonAction]
        public ContentResult MsgResponse(string message, int statusCode)
        {
            var responseObj = new MessageResponse()
            {
                Message = message
            };

            var response = Content(JsonSerializer.Serialize(responseObj));
            response.ContentType = MediaTypeNames.Application.Json;
            response.StatusCode = statusCode;
            return response;
        }

        [NonAction]
        public ContentResult ContentResponse<T>(T obj, int statusCode = StatusCodes.Status200OK)
        {
            var response = Content(JsonSerializer.Serialize(obj));
            response.ContentType = MediaTypeNames.Application.Json;
            response.StatusCode = statusCode;
            return response;
        }

        [NonAction]
        public ContentResult PagedContentResponse<T>(IEnumerable<T> obj, int total, int statusCode = StatusCodes.Status200OK)
        {
            var responseObj = new PagedContentResponse<T>()
            {
                Items = obj,
                Total = total
            };

            var response = Content(JsonSerializer.Serialize(responseObj));
            response.ContentType = MediaTypeNames.Application.Json;
            response.StatusCode = statusCode;
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
