using AutoMapper;
using CleanArch.Application.Dtos;
using CleanArch.Application.Features.Clients.Commands.CreateClient;
using CleanArch.Application.Features.Clients.Commands.DeleteClient;
using CleanArch.Application.Features.Clients.Commands.UpdateClient;
using CleanArch.Application.Features.Clients.Queries.GetClientById;
using CleanArch.Application.Features.Clients.Queries.GetClientList;
using CleanArch.Application.ServiceBus;
using CleanArch.Domain.Entities;
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
        public async Task<ActionResult<ClientDto>> Post([FromBody] ClientDto ClientDto, CancellationToken cancellation)
        {
            var client = Mapper.Map<Client>(ClientDto);
            var clientId = await ServiceBus.Send(new CreateClientCommand(client), cancellation);
            var createdClient = await ServiceBus.Send(new GetClientByIdQuery(clientId), cancellation);
            return CreatedResponse(createdClient);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ClientDto>> Put([FromBody] ClientDto ClientDto, CancellationToken cancellation)
        {
            var client = Mapper.Map<Client>(ClientDto);
            await ServiceBus.Send(new UpdateClientCommand(client), cancellation);
            var updatedClient = await ServiceBus.Send(new GetClientByIdQuery(client.Id), cancellation);
            return UpdatedResponse(updatedClient);
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