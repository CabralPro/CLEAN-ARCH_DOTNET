using AutoMapper;
using CleanArch.Application.Dtos;
using CleanArch.Application.Features.BaseCrud.Queries.GetEntityById;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Features.Clients.Queries.GetClientById
{
    public class GetClientByIdQueryHandler : GetEntityByIdQueryHandler<Client, ClientDto>
    {
        public GetClientByIdQueryHandler(
            IClientRepository repository,
            IMapper mapper)
            : base(repository, mapper)
        { }
    }
}
