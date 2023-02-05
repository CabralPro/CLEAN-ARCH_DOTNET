using AutoMapper;
using CCleanArch.Application.Dtos.Clients;
using CleanArch.Application.BaseMediator.Commands.BaseRemoveInternalDeletedEntities;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Features.Clients.Commands.RemoveInternalDeletedEntitiesClient
{
    public class RemoveInternalDeletedEntitiesClientCommandHandle
        : BaseRemoveInternalDeletedEntitiesCommandHandle<Client, ClientDto>
    {
        public RemoveInternalDeletedEntitiesClientCommandHandle(
            IClientRepository repository,
            IMapper mapper)
            : base(repository, mapper)
        { }
    }
}
