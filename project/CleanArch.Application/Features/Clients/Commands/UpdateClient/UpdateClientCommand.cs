using CleanArch.Application.Features.Clients.Commands.CreateClient;
using CleanArch.Domain.Entities;
using FluentValidation;
using MediatR;

namespace CleanArch.Application.Features.Clients.Commands.UpdateClient
{
    public class UpdateClientCommand : IRequest
    {
        public Client Cliente { get; private set; }

        public UpdateClientCommand(Client cliente)
        {
            Cliente = cliente;
            new UpdateClientCommandValidator().ValidateAndThrow(this);
        }
    }
}
