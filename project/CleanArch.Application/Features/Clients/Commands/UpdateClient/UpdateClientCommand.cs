using CleanArch.Application.BaseMediator.Commands.BaseUpdate;
using CleanArch.Application.Dtos;

namespace CleanArch.Application.Features.Clients.Commands.UpdateClient
{
    public class UpdateClientCommand : BaseUpdateCommand<ClientDto>
    {
        public UpdateClientCommand(ClientDto dto)
            : base(dto)
        { }
    }
}
