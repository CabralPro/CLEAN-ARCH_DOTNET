using AutoMapper;
using CCleanArch.Application.Dtos.Clients;
using CleanArch.Application.BaseMediator.Queries.BaseGetList;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Features.Clients.Queries.GetClientList
{
    public class GetClientListQueryHandle : BaseGetListQueryHandler<Client, ClientDto>
    {
        public GetClientListQueryHandle(
            IClientRepository repository,
            IMapper mapper)
            : base(repository, mapper)
        { }
    }
}
