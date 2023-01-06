using CleanArch.Domain.DomainObjects;
using FluentValidation;
using MediatR;

namespace CleanArch.Application.Features.BaseCrud.Commands.UpdateEntity
{
    public class UpdateEntityCommand<T> : IRequest<Guid>
        where T : EntityBase
    {
        public T Entity { get; private set; }

        public UpdateEntityCommand(T entity)
        {
            Entity = entity;
            new UpdateEntityCommandValidator<T>().ValidateAndThrow(this);
        }
    }
}
