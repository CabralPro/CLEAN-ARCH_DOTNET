
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.Features.Clients.Commands.DeleteClient
{
    public class DeleteClientCommandHandle : IRequestHandler<DeleteClientCommand>
    {
        private readonly IClientRepository _clientRepository;

        public DeleteClientCommandHandle(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Unit> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            await _clientRepository.RemoveAsync(request.ClientId, cancellationToken);
            return Unit.Value;
        }
    }
}
