using CleanArch.Domain.DomainObjects;
using FluentValidation;
using MediatR;

namespace CleanArch.Application.BaseMediator.Commands.BaseCreate
{
    public abstract class BaseCreateCommand<TResponse, TDto> : IRequest<TResponse>
    {
        public TDto Dto { get; private set; }

        public BaseCreateCommand(TDto dto)
        {
            Dto = dto;
            //new BaseCreateCommandValidator<TDto>().ValidateAndThrow(this);
        }
    }
}
