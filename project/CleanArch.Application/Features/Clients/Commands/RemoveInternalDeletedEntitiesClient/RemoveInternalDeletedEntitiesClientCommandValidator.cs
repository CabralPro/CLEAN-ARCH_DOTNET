using CCleanArch.Application.Dtos.Clients;
using CleanArch.Application.BaseMediator.Commands.BaseRemoveInternalDeletedEntities;

namespace CleanArch.Application.Features.Clients.Commands.RemoveInternalDeletedEntitiesClient
{
    public class RemoveInternalDeletedEntitiesClientCommandValidator
        : BaseRemoveInternalDeletedEntitiesCommandValidator<ClientDto>
    {
        public RemoveInternalDeletedEntitiesClientCommandValidator()
        {
            // MY VALIDATIONS
        }
    }
}
