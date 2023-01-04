using CleanArch.Domain.Entities;
using FluentValidation;
using MediatR;

namespace CleanArch.Application.Features.Clients.Commands.CreateClient
{
    public class CreateClientCommand : IRequest<Guid>
    {
        public Client Cliente { get; private set; }

        public CreateClientCommand(Client cliente)
        {
            Cliente = cliente;
            new CreateClientCommandValidator().ValidateAndThrow(this);
        }
    }
}
