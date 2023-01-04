
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.Features.Clients.Commands.UpdateClient
{
    public class UpdateClientCommandHandle : IRequestHandler<UpdateClientCommand>
    {
        private readonly IClientRepository _clientRepository;

        public UpdateClientCommandHandle(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Unit> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            await _clientRepository.UpdateAsync(request.Cliente, cancellationToken);
            return Unit.Value;
        }

    }
}
