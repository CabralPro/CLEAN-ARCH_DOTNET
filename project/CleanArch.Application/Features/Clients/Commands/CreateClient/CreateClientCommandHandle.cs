using AutoMapper;
using CleanArch.Application.BaseMediator.Commands.BaseCreate;
using CleanArch.Application.Dtos;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Features.Clients.Commands.CreateClient
{
    public class CreateClientCommandHandle : BaseCreateCommandHandle<Client, ClientDto>
    {
        public CreateClientCommandHandle(
            IClientRepository repository,
            IMapper mapper)
            : base(repository, mapper)
        { }
    }
}
