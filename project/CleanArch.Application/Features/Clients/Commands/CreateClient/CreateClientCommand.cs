using CleanArch.Application.BaseMediator.Commands.BaseCreate;
using CleanArch.Application.Dtos;

namespace CleanArch.Application.Features.Clients.Commands.CreateClient
{
    public class CreateClientCommand : BaseCreateCommand<ClientDto>
    {
        public CreateClientCommand(ClientDto entity)
            : base(entity)
        { }
    }
}
