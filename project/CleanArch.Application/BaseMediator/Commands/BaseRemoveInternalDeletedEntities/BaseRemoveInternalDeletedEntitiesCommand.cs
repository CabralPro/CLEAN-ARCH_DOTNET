using CleanArch.Application.BaseMediatR.Commands.BaseDelete;
using CleanArch.Domain.DomainObjects;
using FluentValidation;
using MediatR;

namespace CleanArch.Application.BaseMediator.Commands.BaseRemoveInternalDeletedEntities
{
    public class BaseRemoveInternalDeletedEntitiesCommand<T> : IRequest<T>
        where T : DtoBase
    {
        public T Dto { get; private set; }

        public BaseRemoveInternalDeletedEntitiesCommand(T dto)
        {
            Dto = dto;
            new BaseRemoveInternalDeletedEntitiesCommandValidator<T>().ValidateAndThrow(this);
        }
    }
}
