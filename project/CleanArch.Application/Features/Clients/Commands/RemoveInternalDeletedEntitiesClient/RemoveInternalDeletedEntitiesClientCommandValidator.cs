using CleanArch.Application.BaseMediator.Commands.BaseRemoveInternalDeletedEntities;
using CleanArch.Application.Dtos;

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
