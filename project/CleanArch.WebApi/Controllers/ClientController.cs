using AutoMapper;
using CleanArch.Application.Dtos;
using CleanArch.Application.Features.Clients.Commands.CreateClient;
using CleanArch.Application.Features.Clients.Commands.DeleteClient;
using CleanArch.Application.Features.Clients.Commands.RemoveInternalDeletedEntitiesClient;
using CleanArch.Application.Features.Clients.Commands.UpdateClient;
using CleanArch.Application.Features.Clients.Queries.GetClientById;
using CleanArch.Application.Features.Clients.Queries.GetClientList;
using CleanArch.Application.ServiceBus;
using CleanArch.WebApi.Controllers.ResponseTypes;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebApi.Controllers
{
    [ApiController]
    [Route("client")]
    public class ClientController : BaseController
    {
        
        public ClientController(
            ILogger<ClientController> logger,
            IMapper mapper,
            IServiceBus serviceBus)
            : base(logger, mapper, serviceBus)
        { }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ClientDto>> GetById([FromQuery] Guid id, CancellationToken cancellation)
        {
            var client = await ServiceBus.Send(new GetClientByIdQuery(id), cancellation);
            return ContentResponse(client);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<ClientDto>> Post([FromBody] ClientDto clientDto, CancellationToken cancellation)
        {
            var client = await ServiceBus.Send(new CreateClientCommand(clientDto), cancellation);
            return CreatedResponse(client);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ClientDto>> Put([FromBody] ClientDto clientDto, CancellationToken cancellation)
        {
            var trackedItem = await ServiceBus.Send(new UpdateClientCommand(clientDto), cancellation);
            var updatedItem = await ServiceBus.Send(new RemoveInternalDeletedEntitiesClientCommand(trackedItem), cancellation);
            return UpdatedResponse(updatedItem);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Delete([FromQuery] Guid id, CancellationToken cancellation)
        {
            await ServiceBus.Send(new DeleteClientCommand(id), cancellation);
            return Ok();
        }

        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PagedContentResponse<ClientDto>>> GetList(
            [FromQuery] int page, [FromQuery] int size, CancellationToken cancellation)
        {
            ValidatePagination(page, size);
            var (clientList, total) = await ServiceBus.Send(new GetClientListQuery(page, size), cancellation);
            return PagedContentResponse(clientList, total);
        }

    }

}