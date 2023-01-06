using CleanArch.Domain.DomainObjects;
using FluentValidation;
using MediatR;

namespace CleanArch.Application.Features.BaseCrud.Commands.CreateEntity
{
    public class CreateEntityCommand<T> : IRequest<Guid>
        where T : EntityBase
    {
        public T Entity { get; private set; }

        public CreateEntityCommand(T entity)
        {
            Entity = entity;
            new CreateEntityCommandValidator<T>().ValidateAndThrow(this);
        }
    }
}
