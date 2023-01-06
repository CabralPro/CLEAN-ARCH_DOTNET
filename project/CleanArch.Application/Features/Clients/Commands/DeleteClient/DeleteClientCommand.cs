using CleanArch.Application.BaseMediator.Commands.BaseDelete;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.Features.Clients.Commands.DeleteClient
{
    public class DeleteClientCommand : BaseDeleteCommand<Client>
    {
        public DeleteClientCommand(Guid entityId)
            : base(entityId)
        { }
    }
}
