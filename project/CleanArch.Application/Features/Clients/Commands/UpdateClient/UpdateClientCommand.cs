using CCleanArch.Application.Dtos.Clients;
using CleanArch.Application.BaseMediator.Commands.BaseUpdate;

namespace CleanArch.Application.Features.Clients.Commands.UpdateClient
{
    public class UpdateClientCommand : BaseUpdateCommand<ClientDto>
    {
        public UpdateClientCommand(ClientDto dto)
            : base(dto)
        { }
    }
}
