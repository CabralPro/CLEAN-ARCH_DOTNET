using CleanArch.Application.BaseMediator.Commands.BaseDelete;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Features.Clients.Commands.DeleteClient
{
    public class DeleteClientCommandHandle : BaseDeleteCommandHandle<Client>
    {
        public DeleteClientCommandHandle(IClientRepository repository)
            : base(repository)
        { }
    }
}
