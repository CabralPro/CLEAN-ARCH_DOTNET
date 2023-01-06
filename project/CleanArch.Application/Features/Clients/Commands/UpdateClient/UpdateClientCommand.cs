using CleanArch.Application.Features.BaseCrud.Commands.UpdateEntity;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.Features.Clients.Commands.UpdateClient
{
    public class UpdateClientCommand : UpdateEntityCommand<Client>
    {
        public UpdateClientCommand(Client entity)
            : base(entity)
        { }
    }
}
