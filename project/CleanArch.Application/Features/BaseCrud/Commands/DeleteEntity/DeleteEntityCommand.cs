using FluentValidation;
using MediatR;

namespace CleanArch.Application.Features.BaseCrud.Commands.DeleteEntity
{
    public class DeleteEntityCommand<T> : IRequest
    {
        public Guid EntityId { get; private set; }

        public DeleteEntityCommand(Guid entityId)
        {
            EntityId = entityId;
            new DeleteEntityCommandValidator<T>().ValidateAndThrow(this);
        }
    }
}
