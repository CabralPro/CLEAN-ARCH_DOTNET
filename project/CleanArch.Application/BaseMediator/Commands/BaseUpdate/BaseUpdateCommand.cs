using CleanArch.Application.BaseMediatR.Commands.BaseUpdate;
using CleanArch.Domain.DomainObjects;
using FluentValidation;
using MediatR;

namespace CleanArch.Application.BaseMediator.Commands.BaseUpdate
{
    public class BaseUpdateCommand<T> : IRequest<T>
        where T : DtoBase
    {
        public T Dto { get; private set; }

        public BaseUpdateCommand(T dto)
        {
            Dto = dto;
            new BaseUpdateCommandValidator<T>().ValidateAndThrow(this);
        }
    }
}
