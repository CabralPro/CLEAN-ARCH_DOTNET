using AutoMapper;
using CCleanArch.Application.Dtos.Clients;
using CleanArch.Application.BaseMediator.Commands.BaseCreate;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Features.Clients.Commands.CreateClient
{
    public class CreateClientCommandHandle : CreateCommandHandler<Client, CreateClientCommand, ClientDto>
    {
        public CreateClientCommandHandle(
            IClientRepository repository,
            IMapper mapper)
            : base(repository, mapper)
        { }
    }
}
