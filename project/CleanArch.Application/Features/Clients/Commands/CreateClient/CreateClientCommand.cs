using CleanArch.Application.Features.BaseCrud.Commands.CreateEntity;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.Features.Clients.Commands.CreateClient
{
    public class CreateClientCommand : CreateEntityCommand<Client>
    {
        public CreateClientCommand(Client entity)
            : base(entity)
        { }
    }
}
