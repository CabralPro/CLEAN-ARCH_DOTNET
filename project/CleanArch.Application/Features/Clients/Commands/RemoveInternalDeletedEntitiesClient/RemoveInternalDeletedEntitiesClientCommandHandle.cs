using AutoMapper;
using CleanArch.Application.BaseMediator.Commands.BaseRemoveInternalDeletedEntities;
using CleanArch.Application.Dtos;
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
