using CleanArch.Application.BaseMediator.Commands.BaseRemoveInternalDeletedEntities;
using CleanArch.Application.Dtos;

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
