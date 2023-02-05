using CCleanArch.Application.Dtos.Clients;
using CleanArch.Application.BaseMediator.Commands.BaseCreate;

namespace CleanArch.Application.Features.Clients.Commands.CreateClient
{
    public class CreateClientCommand : CreateCommand<ClientDto>
    {
        public CreateClientCommand(ClientDto dto) : base(dto)
        {
        }
    }
}
