using AutoMapper;
using CleanArch.Application.Dtos;
using CleanArch.Application.Features.BaseCrud.Queries.GetEntityList;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Features.Clients.Queries.GetClientList
{
    public class GetClientListQueryHandler : GetEntityListQueryHandler<Client, ClientDto>
    {
        public GetClientListQueryHandler(
            IClientRepository repository,
            IMapper mapper)
            : base(repository, mapper)
        { }
    }
}
