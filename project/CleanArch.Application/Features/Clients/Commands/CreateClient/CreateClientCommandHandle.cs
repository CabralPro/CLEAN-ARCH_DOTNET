using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.Features.Clients.Commands.CreateClient
{
    public class CreateClientCommandHandle : IRequestHandler<CreateClientCommand, Guid>
    {
        private readonly IClientRepository _clientRepository;

        public CreateClientCommandHandle(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Guid> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            await _clientRepository.AddAsync(request.Cliente, cancellationToken);
            return request.Cliente.Id;
        }
    }
}
