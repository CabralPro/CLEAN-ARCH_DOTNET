using CleanArch.Application.BaseMediatR.Commands.BaseDelete;
using FluentValidation;
using MediatR;

namespace CleanArch.Application.BaseMediator.Commands.BaseDelete
{
    public class BaseDeleteCommand<T> : IRequest
    {
        public Guid EntityId { get; private set; }

        public BaseDeleteCommand(Guid entityId)
        {
            EntityId = entityId;
            new BaseDeleteCommandValidator<T>().ValidateAndThrow(this);
        }
    }
}
