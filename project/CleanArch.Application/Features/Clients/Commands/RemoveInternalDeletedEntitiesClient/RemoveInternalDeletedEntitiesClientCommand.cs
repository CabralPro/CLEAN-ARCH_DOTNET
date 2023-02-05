using CCleanArch.Application.Dtos.Clients;
using CleanArch.Application.BaseMediator.Commands.BaseRemoveInternalDeletedEntities;

namespace CleanArch.Application.Features.Clients.Commands.RemoveInternalDeletedEntitiesClient
{
    public class RemoveInternalDeletedEntitiesClientCommand
        : BaseRemoveInternalDeletedEntitiesCommand<ClientDto>
    {
        public RemoveInternalDeletedEntitiesClientCommand(ClientDto dto)
            : base(dto)
        { }
    }
}
