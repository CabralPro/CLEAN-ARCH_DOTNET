using CleanArch.Domain.DomainObjects;
using FluentValidation;
using MediatR;

namespace CleanArch.Application.BaseMediator.Commands.BaseCreate
{
    public class BaseCreateCommand<T> : IRequest<T>
        where T : DtoBase
    {
        public T Dto { get; private set; }

        public BaseCreateCommand(T dto)
        {
            Dto = dto;
            new BaseCreateCommandValidator<T>().ValidateAndThrow(this);
        }
    }
}
