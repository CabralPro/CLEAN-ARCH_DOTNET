using CleanArch.Application.Dtos;
using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebApi.Controllers
{
    [ApiController]
    [Route("client")]
    public class ClientController : BaseController
    {
        private readonly IClientService _clientService;

        public ClientController(
            ILogger<ClientController> logger,
            IClientService clientService)
            : base(logger)
        {
            _clientService = clientService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ClientDto>> GetById([FromQuery] Guid id, CancellationToken cancellation)
        {
            var clients = await _clientService.GetByIdAsync(id, cancellation);
            return ContentResponse(clients);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<ClientDto>> Post([FromBody] ClientDto ClientDto, CancellationToken cancellation)
        {
            var clientResult = await _clientService.AddAsync(ClientDto, cancellation);
            return CreatedResponse(clientResult);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ClientDto>> Put([FromBody] ClientDto ClientDto, CancellationToken cancellation)
        {
            var clientResult = await _clientService.UpdateAsync(ClientDto, cancellation);
            return UpdatedResponse(clientResult);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Delete([FromQuery] Guid id, CancellationToken cancellation)
        {
            await _clientService.RemoveAsync(id, cancellation);
            return Ok();
        }

        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ClientDto>>> GetList(
            [FromQuery] int page, [FromQuery] int size, CancellationToken cancellation)
        {
            ValidatePagination(page, size);
            var clients = await _clientService.ListAsync(page, size, cancellation);
            return ContentResponse(clients);
        }

    }
}