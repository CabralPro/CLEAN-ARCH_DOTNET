
using AutoMapper;
using CCleanArch.Application.Dtos.Clients;
using CleanArch.Application.BaseMediator.Commands.BaseUpdate;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Features.Clients.Commands.UpdateClient
{
    public class UpdateClientCommandHandle : BaseUpdateCommandHandle<Client, ClientDto, UpdateClientCommand>
    {
        public UpdateClientCommandHandle(
            IClientRepository repository,
            IMapper mapper)
            : base(repository, mapper)
        { }
    }
}
