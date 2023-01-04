using FluentValidation;
using MediatR;

namespace CleanArch.Application.Features.Clients.Commands.DeleteClient
{
    public class DeleteClientCommand : IRequest
    {
        public Guid ClientId { get; private set; }

        public DeleteClientCommand(Guid clientId)
        {
            ClientId = clientId;
            new DeleteClientCommandValidator().ValidateAndThrow(this);
        }
    }
}
