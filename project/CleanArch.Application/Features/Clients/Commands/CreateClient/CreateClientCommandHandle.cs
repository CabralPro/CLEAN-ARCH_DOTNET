using CleanArch.Application.Features.BaseCrud.Commands.CreateEntity;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Features.Clients.Commands.CreateClient
{
    public class CreateClientCommandHandle : CreateEntityCommandHandle<Client>
    {
        public CreateClientCommandHandle(IClientRepository repository)
            : base(repository)
        { }
    }
}
