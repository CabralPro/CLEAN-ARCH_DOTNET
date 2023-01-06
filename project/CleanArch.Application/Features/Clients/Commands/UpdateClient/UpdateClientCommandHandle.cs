﻿
using AutoMapper;
using CleanArch.Application.BaseMediator.Commands.BaseUpdate;
using CleanArch.Application.Dtos;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Features.Clients.Commands.UpdateClient
{
    public class UpdateClientCommandHandle : BaseUpdateCommandHandle<Client, ClientDto>
    {
        public UpdateClientCommandHandle(
            IClientRepository repository,
            IMapper mapper)
            : base(repository, mapper)
        { }
    }
}
