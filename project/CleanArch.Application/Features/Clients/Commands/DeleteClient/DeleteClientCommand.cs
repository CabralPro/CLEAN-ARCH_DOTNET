using CleanArch.Application.Features.BaseCrud.Commands.DeleteEntity;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.Features.Clients.Commands.DeleteClient
{
    public class DeleteClientCommand : DeleteEntityCommand<Client>
    {
        public DeleteClientCommand(Guid entityId)
            : base(entityId)
        { }
    }
}
