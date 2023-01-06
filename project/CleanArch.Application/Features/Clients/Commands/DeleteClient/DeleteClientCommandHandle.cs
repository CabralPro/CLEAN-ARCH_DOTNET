
using CleanArch.Application.Features.BaseCrud.Commands.DeleteEntity;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Features.Clients.Commands.DeleteClient
{
    public class DeleteClientCommandHandle : DeleteEntityCommandHandle<Client>
    {
        public DeleteClientCommandHandle(IClientRepository repository)
            : base(repository)
        { }
    }
}
