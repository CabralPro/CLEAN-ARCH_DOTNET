
using CleanArch.Application.Features.BaseCrud.Commands.UpdateEntity;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Features.Clients.Commands.UpdateClient
{
    public class UpdateClientCommandHandle : UpdateEntityCommandHandle<Client>
    {
        public UpdateClientCommandHandle(IClientRepository repository)
            : base(repository)
        { }
    }
}
