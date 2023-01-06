using AutoMapper;
using CleanArch.Application.BaseMediator.Queries.BaseGetById;
using CleanArch.Application.Dtos;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Features.Clients.Queries.GetClientById
{
    public class GetClientByIdQueryHandle : BaseGetByIdQueryHandler<Client, ClientDto>
    {
        public GetClientByIdQueryHandle(
            IClientRepository repository,
            IMapper mapper)
            : base(repository, mapper)
        { }
    }
}
