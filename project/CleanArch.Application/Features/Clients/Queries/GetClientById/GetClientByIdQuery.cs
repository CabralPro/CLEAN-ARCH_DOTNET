using CleanArch.Application.Dtos;
using MediatR;

namespace CleanArch.Application.Features.Clients.Queries.GetClientById
{
    public class GetClientByIdQuery : IRequest<ClientDto>
    {
        public Guid ClientId { get; private set; }

        public GetClientByIdQuery(Guid clientId)
        {
            ClientId = clientId;
        }
    }
}
